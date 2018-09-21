using Phoera.Framework;
using Phoera.Framework.Utils;
using Phoera.Network;
using Phoera.Network.Actions;
using Phoera.Network.Packets;
using Phoera.Network.Variables;
using ProtoBuf;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.Game.Entities;
using Sandbox.Game.EntityComponents;
using Sandbox.Game.Weapons;
using Sandbox.ModAPI;
using SpaceEngineers.Game.ModAPI;
using System;
using System.Collections.Generic;
using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.ObjectBuilders;
using VRage.Utils;
using static Phoera.Network.NetworkHandlerSystem;

namespace Phoera.Persistance
{
    public abstract class SyncedGameLogicComponent : MyGameLogicComponent
    {
        private readonly Guid _saveGuid;
        Dictionary<ulong, NetworkVar> variables = new Dictionary<ulong, NetworkVar>();

        [ProtoContract]
        struct Data
        {
            [ProtoMember(1)]
            public Dictionary<ulong, byte[]> Raws;
        }

        protected SyncedGameLogicComponent(Guid saveGuid)
        {
            _saveGuid = saveGuid;
        }

        public struct DisposablePause : IDisposable
        {
            Network.Variables.NetworkVar.DisposablePause[] pausers;
            private SyncedGameLogicComponent _syncedGameLogic;

            internal DisposablePause(Dictionary<ulong, NetworkVar>.ValueCollection vars, SyncedGameLogicComponent syncedGameLogic)
            {
                pausers = new NetworkVar.DisposablePause[vars.Count];
                int i = 0;
                foreach (var val in vars)
                {
                    pausers[i] = val.Pause();
                    i++;
                }

                _syncedGameLogic = syncedGameLogic;
            }

            void IDisposable.Dispose()
            {
                if (pausers != null)
                {
                    for (int i = 0; i < pausers.Length; i++)
                    {
                        pausers[i].Dispose();
                    }
                    pausers = null;
                    _syncedGameLogic.ForceSync();
                    _syncedGameLogic = null;

                }
            }
        }

        protected DisposablePause PauseSync()
        {
            return new DisposablePause(variables.Values, this);
        }
        protected void ForceSync()
        {
            if (variables.Count > 0)
            {
                var packet = new PacketNetworkVarBatchUpdate();
                packet.Entity = Entity.EntityId;
                packet.Data = new Dictionary<ulong, byte[]>();
                foreach (var var in variables)
                {
                    packet.Data[var.Key] = var.Value.GetValue();
                }
                if (!IsServer)
                {
                    CoreBase.Instance.Network.SendMessageToServer(packet);
                }
                CoreBase.Instance.Network.SendMessageToOthers(packet);
            }
        }
        class VarCreatorWrapper : NetworkVarExtensions.IVariableCreator
        {
            NetworkVarExtensions.IVariableCreator _creator;
            private readonly Dictionary<ulong, byte[]> _raws;
            private readonly SyncedGameLogicComponent _source;

            public VarCreatorWrapper(NetworkVarExtensions.IVariableCreator creator, Dictionary<ulong, byte[]> _raws, SyncedGameLogicComponent source)
            {
                _creator = creator;
                this._raws = _raws;
                _source = source;
            }


            public NetworkVar<T> Create<T>(T value = default(T), bool serverOnly = true, ulong syncPeriod = 1, bool defer = false, IEqualityComparer<T> comparer = null, bool haveOwner = false, ulong owner = 0, Action<NetworkVar<T>> valueUpdated = null)
            {
                var res = _creator.Create(value, serverOnly, syncPeriod, defer, comparer, haveOwner, owner, valueUpdated);
                byte[] data;
                if (_raws.TryGetValue(res.Key, out data))
                {
                    try
                    {
                        res.UpdateValue(data);
                        //res.Value.Log();
                    }
                    catch (Exception e)
                    {
                        e.Log(true);
                    }
                }
                _source.variables[res.Key] = res;
                return res;
            }

            public void Dispose()
            {
                _creator.Dispose();
            }
        }

        protected virtual void BeforeSave()
        {

        }
        public override sealed bool IsSerialized()
        {
            if (Entity.Storage != null)
            {
                BeforeSave();
                if (variables.Count == 0)
                {
                    Entity.Storage[_saveGuid] = "";
                }
                else
                {
                    var dat = new Data { Raws = new Dictionary<ulong, byte[]>() };
                    foreach (var d in variables)
                    {
                        dat.Raws[d.Key] = d.Value.GetValue();
                    }
                    var str = dat.ToBinary().ToBase64();
                    str.Log(true);
                    Entity.Storage[_saveGuid] = str;
                }
            }
            return false;
        }

        protected abstract void InitVariables(NetworkVarExtensions.IVariableCreator creator);

        public sealed override void Init(MyComponentDefinitionBase definition)
        {
            base.Init(definition);
        }
        public override sealed void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
        }
        bool inited = false;
        bool ainited = false;

        public override sealed void OnAddedToContainer()
        {
            base.OnAddedToContainer();
            if (!ainited)
            {
                ainited = true;
                ComponentInit();
            }
            if (Entity.InScene)
            {
                OnAddedToScene();
            }
        }

        public override sealed void OnRemovedFromScene()
        {
            base.OnRemovedFromScene();
            if (inited)
            {
                CoreBase.Instance.Network.RemoveEntityVariables(Entity.EntityId);
                EntityDeinit();
                inited = false;
            }
        }

        public override sealed void OnBeforeRemovedFromContainer()
        {
            if (Entity.InScene || inited)
            {
                OnRemovedFromScene();
            }
            if (ainited)
            {
                ComponentDeinit();
            }
            base.OnBeforeRemovedFromContainer();
        }

        public override sealed void OnAddedToScene()
        {
            base.OnAddedToScene();
            if (!inited)
            {
                inited = true;
                Dictionary<ulong, byte[]> raws = null;
                if (Entity.Storage == null)
                {
                    Entity.Storage = new MyModStorageComponent()
                    {
                        [_saveGuid] = ""
                    };
                }
                else
                {
                    if (Entity.Storage.ContainsKey(_saveGuid))
                    {
                        try
                        {
                            raws = Entity.Storage[_saveGuid].FromBase64().FromBinary<Data>().Raws;
                            raws.Count.Log();
                            foreach (var raw in raws)
                            {
                                raw.Key.Log();
                                raw.Value?.Length.Log();
                            }
                            Entity.Storage[_saveGuid].Log();
                        }
                        catch (Exception e)
                        {
                            e.Log(true);
                            Entity.Storage[_saveGuid] = "";
                        }
                    }
                    else
                    {
                        Entity.Storage[_saveGuid] = "";
                    }
                }
                using (var creator = new VarCreatorWrapper(CoreBase.Instance.Network.CreateEntityVariables(Entity), raws ?? new Dictionary<ulong, byte[]>(), this))
                {
                    InitVariables(creator);
                }
                EntityInit();
            }
        }

        /// <summary>
        /// standalone component init, entity is assigned, but may be not fully initialized. must be used for component own data, caches, entity definition(it's valid) casted entity storing, etc.
        /// may happen outside of main thread and before entity id is assigned(good place for resources, etc), called before EntityInit
        /// </summary>
        protected virtual void ComponentInit() { }
        /// <summary>
        /// must be used for entity binded data, mostly data binded to entity id.
        /// must be on gamethread and entity id is correct(in theory may be recalled on torch), variable init called before this one.
        /// </summary>
        protected virtual void EntityInit() { }
        /// <summary>
        /// just pair to ComponentInit
        /// </summary>
        protected virtual void ComponentDeinit() { }
        /// <summary>
        /// must be on gamethread and entity id is correct(in theory may be recalled on torch), variables unregistered before this call
        /// </summary>
        protected virtual void EntityDeinit() { }

    }
}
