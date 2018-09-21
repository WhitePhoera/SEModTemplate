using Phoera.Framework;
using Phoera.Framework.Utils;
using Phoera.Network.Packets;
using Phoera.Network.Variables;
using ProtoBuf;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using static Phoera.Network.NetworkHandlerSystem;

namespace Phoera.Network
{
    public static class NetworkVarExtensions
    {
        public interface IVariableCreator : IDisposable
        {
            Variables.NetworkVar<T> Create<T>(T value = default(T), bool serverOnly = true, ulong syncPeriod = 1, bool defer = false, IEqualityComparer<T> comparer = null, bool haveOwner = false, ulong owner = 0, Action<NetworkVar<T>> valueUpdated = null);
        }
        class EntityVariableCreator : IVariableCreator
        {
            NetworkHandlerSystem nhs;
            long entityId;
            ulong counter = 0;

            public EntityVariableCreator(NetworkHandlerSystem nhs, long entityId)
            {
                if (nhs != null)
                {
                    this.nhs = nhs;
                }
                else
                {
                    throw new Exception(nameof(nhs));
                }
                this.entityId = entityId;
            }

            public NetworkVar<T> Create<T>(T value = default(T), bool serverOnly = true, ulong syncPeriod = 1, bool defer = false, IEqualityComparer<T> comparer = null, bool haveOwner = false, ulong owner = 0, Action<NetworkVar<T>> valueUpdated = null)
            {
                var res = new NetworkVar<T>(nhs, counter++, entityId, value, serverOnly, syncPeriod, defer, comparer, haveOwner, owner, valueUpdated);
                nhs.RegisterVariable(res);
                return res;
            }

            public void Dispose()
            {
            }

            internal void OnEntityClose(IMyEntity obj)
            {
                nhs.RemoveEntityVariables(obj.EntityId);
                obj.OnClose -= OnEntityClose;
            }
        }

        public static IVariableCreator CreateEntityVariables(this NetworkHandlerSystem nhs, IMyEntity entity)
        {
            if (entity == null)
                throw new Exception(nameof(entity));
            var res = new EntityVariableCreator(nhs, entity.EntityId);
            entity.OnClose += res.OnEntityClose;
            return res;
        }

        public static IVariableCreator CreateIdentityVariables(this NetworkHandlerSystem nhs, IMyPlayer player)
        {
            if (player == null)
                throw new Exception(nameof(player));
            return new EntityVariableCreator(nhs, player.IdentityId);

            //TODO: clear when identity destroyed
        }
        public static IVariableCreator CreateGlobalVariables(this NetworkHandlerSystem nhs)
        {
            return new EntityVariableCreator(nhs, 0);
        }
    }
    namespace Variables
    {
        public abstract class NetworkVar
        {
            public struct DisposablePause
            {
                NetworkVar source;
                internal DisposablePause(NetworkVar networkVar)
                {
                    source = networkVar;
                }
                public void Dispose()
                {
                    source?.Resume();
                    source = null;
                }
            }

            protected readonly ulong _key;
            protected bool haveOwner;
            protected ulong owner;
            protected uint pauseCounter;

            public DisposablePause Pause()
            {
                pauseCounter++;
                return new DisposablePause(this);
            }

            void Resume()
            {
                pauseCounter--;
            }

            public ulong Key
            {
                get
                {
                    return _key;
                }
            }

            protected NetworkHandlerSystem _nhs;
            protected readonly long _entity;

            public long Entity
            {
                get
                {
                    return _entity;
                }
            }

            protected NetworkVar(NetworkHandlerSystem nhs, ulong key, long entity, bool haveOwner, ulong owner)
            {
                _nhs = nhs;
                _key = key;
                _entity = entity;
                this.haveOwner = haveOwner;
                ulong id = MyAPIGateway.Multiplayer.MyId;
                if (haveOwner && IsServer && owner == id)
                {
                    owner = 0;
                }
                this.owner = owner;
            }

            protected abstract void UpdateRawValue(byte[] data);
            public void UpdateValue(byte[] data)
            {
                UpdateRawValue(data);
                cached = data;
            }
            protected abstract byte[] GetRawValue();
            protected byte[] cached;
            public byte[] GetValue()
            {
                var cache = cached;
                if (cache != null)
                    return cache;
                return cached = GetRawValue();
            }

            public abstract void SentTo(ulong target);
        }
        public class NetworkVar<T> : NetworkVar
        {
            public override string ToString()
            {
                return _value?.ToString() ?? "";
            }
            [ProtoContract]
            public struct ValStruct
            {
                [ProtoMember(1)]
                public T Val { get; set; }
            }

            public event Action<NetworkVar<T>> ValueUpdated;
            T _value;
            private ActionTickLimiter _limiter;
            private readonly bool _serverOnly;
            private readonly IEqualityComparer<T> comparer;
            bool inUpdate = false;
            private readonly bool _defer;

            public T Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    if (!inUpdate && !comparer.Equals(value, _value))
                    {
                        if (pauseCounter == 0 && IsMultiplayer)
                        {
                            if (_serverOnly)
                            {
                                if (IsServer)
                                {
                                    if (_defer)
                                    {
                                        if (!_deferred)
                                        {
                                            _deferred = true;
                                            CoreBase.Instance.AddDelayedActionInTicks(DoDeferedSync, 1);
                                        }
                                    }
                                    else
                                    {
                                        _limiter.DoAction();
                                    }
                                }
                            }
                            else
                            {
                                if (_defer)
                                {
                                    if (!_deferred)
                                    {
                                        CoreBase.Instance.AddDelayedActionInTicks(DoDeferedSync, 1);
                                    }
                                }
                                else
                                {
                                    _limiter.DoAction();
                                }
                            }
                        }
                        _value = value;
                        cached = null;
                        inUpdate = true;
                        ValueUpdated?.Invoke(this);
                        inUpdate = false;
                    }
                }
            }
            bool _deferred = false;
            void DoDeferedSync(IDisposable obj)
            {
                _deferred = false;
                _limiter.DoAction();
            }
            public static implicit operator T(NetworkVar<T> var)
            {
                return var.Value;
            }

            public NetworkVar(NetworkHandlerSystem nhs, ulong key, long entity, T value, bool serverOnly, ulong syncPeriod, bool defer, IEqualityComparer<T> comparer, bool haveOwner, ulong owner, Action<NetworkVar<T>> valueUpdated = null) : base(nhs, key, entity, haveOwner, owner)
            {
                _serverOnly = serverOnly;
                this.comparer = comparer ?? EqualityComparer<T>.Default;
                _value = value;
                _limiter = new ActionTickLimiter(DoSync, syncPeriod, true);
                _defer = defer;
                if (valueUpdated != null)
                    ValueUpdated += valueUpdated;
            }

            private void DoSync()
            {
                var data = GetValue();
                var val = new ValStruct { Val = _value }.ToBinary();
                if (haveOwner)
                {
                    if (owner != 0 && IsServer)
                    {
                        SentTo(owner);
                    }
                }
                else
                {
                    if (!IsServer)
                    {
                        _nhs.SendMessageToServer(new PacketNetworkVarUpdate() { Variable = _key, Entity = _entity, Data = val });
                    }
                    _nhs.SendMessageToOthers(new PacketNetworkVarUpdate() { Variable = _key, Entity = _entity, Data = val });
                }

            }

            protected override void UpdateRawValue(byte[] data)
            {
                _value = data.FromBinary<ValStruct>().Val;
                ValueUpdated?.Invoke(this);
            }

            protected override byte[] GetRawValue()
            {
                return new ValStruct { Val = _value }.ToBinary();
            }

            public override void SentTo(ulong target)
            {
                if (IsServer)
                {
                    var data = GetValue();
                    _nhs.SendMessageTo(new PacketNetworkVarUpdate() { Variable = _key, Entity = _entity, Data = new ValStruct { Val = _value }.ToBinary() }, target);
                }
            }
        }
    }
}
