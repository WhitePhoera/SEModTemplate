#line 2
using Phoera.Framework;
using Phoera.Framework.Interfaces;
using Phoera.Framework.Utils;
using Phoera.Network.Packets;
using Phoera.Network.Variables;
using ProtoBuf;
using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using VRage;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRageMath;

/// <summary>
/// This file not public, you cannot copy it or use it parts without my permission.
/// Copyright - Phoera - 2016
/// </summary>
namespace Phoera.Network
{
    public class NetworkHandlerSystem : IComponent
    {

        readonly StringHasher _hasher = new StringHasher();
        ulong _modId;

        bool _initDone = false;
        private ushort _networkId;
        Dictionary<ulong, IMyPlayer> players = new Dictionary<ulong, IMyPlayer>();
        ConcurrentDictionary<ulong, Action<ulong, byte[]>> actionHandlers = new ConcurrentDictionary<ulong, Action<ulong, byte[]>>();
        ulong lastUsedActionHandler = 1;
        public IMyPlayer GetPlayer(ulong steamId)
        {
            IMyPlayer res = null;
            players.TryGetValue(steamId, out res);
            return res;
        }
        Dictionary<ulong, long> player2Identity = new Dictionary<ulong, long>();
        Dictionary<long, ulong> identity2Player = new Dictionary<long, ulong>();
        internal ulong RegisterActionHandler(Action<ulong, byte[]> handler)
        {
            ulong res = lastUsedActionHandler++;
            actionHandlers.AddOrUpdate(res, handler, (k, o) => { throw new Exception("Handler registered twice"); });
            return res;
        }
        internal void HandleActionPacket(ulong id, byte[] data, ulong sender)
        {
            actionHandlers[id](sender, data);
        }
        List<IMyPlayer> playerForId = new List<IMyPlayer>(1);
        internal void RegisterPlayer(ulong playerId)
        {
            try
            {
                playerForId.Clear();
                MyAPIGateway.Multiplayer.Players.GetPlayers(playerForId, p => p.SteamUserId == playerId);
                var player = playerForId.Count > 0 ? playerForId[0] : null;
                playerForId.Clear();
                players[playerId] = player;
                PlayerConnected?.Invoke(playerId, player);
                player.IdentityChanged += Player_IdentityChanged;
                Player_IdentityChanged(player, player.Identity);
            }
            catch
            {

            }
        }

        public void RemoveEntityVariables(long entity)
        {
            ConcurrentDictionary<ulong, NetworkVar> res;
            entityVariables?.TryRemove(entity, out res);
        }

        private void Player_IdentityChanged(IMyPlayer arg1, IMyIdentity arg2)
        {
            $"{arg1.SteamUserId} => {arg2?.IdentityId ?? 0}".Log(true);
            //TODO: watch identities
        }

        HashSet<long> _identities = new HashSet<long>();

        internal void RegisterVariable(NetworkVar variable)
        {
            ConcurrentDictionary<ulong, NetworkVar> vars;
            if (variable.Entity == 0)
            {
                vars = globalVariables;
            }
            else
            {
                vars = entityVariables.GetOrAdd(variable.Entity, new ConcurrentDictionary<ulong, NetworkVar>());
            }
            vars.AddOrUpdate(variable.Key, variable, (k, o) => { throw new Exception("WTF?"); });
            if (!IsServer)
            {
                SendMessageToServer(new PacketNetworkVarRequest { Entity = variable.Entity, Variable = variable.Key });
            }
        }

        internal void DeregisterPlayer(ulong playerId)
        {
            IMyPlayer player;
            if (players.TryGetValue(playerId, out player))
            {
                players.Remove(playerId);
                player.IdentityChanged -= Player_IdentityChanged;
            }
            PlayerDisconnected?.Invoke(playerId, player);
        }
        public event Action<ulong, IMyPlayer> PlayerConnected;
        public event Action<long, IMyIdentity> OnNewIdentity;
        public event Action<long, IMyIdentity> OnIdentityRemoved;
        public event Action<long, IMyIdentity, IMyPlayer> OnPlayerChangedIdentity;
        public event Action<ulong, IMyPlayer> PlayerDisconnected;
        ConcurrentDictionary<ulong, NetworkVar> globalVariables = new ConcurrentDictionary<ulong, NetworkVar>();
        ConcurrentDictionary<long, ConcurrentDictionary<ulong, NetworkVar>> entityVariables = new ConcurrentDictionary<long, ConcurrentDictionary<ulong, NetworkVar>>();

        void IComponent.Init() { }

        public NetworkHandlerSystem()
        {
            (MyAPIUtilities.Static as IMyUtilities).InvokeOnGameThread(() =>
            {
                $"NHS INIT".Log(true);
                if (!_initDone)
                {
                    new PacketBase().ToBinary().FromBinary<PacketBase>(); // bug fix for protobuf-net serializer generation.
                    _modId = CoreBase.Instance.ModId;
                    string str = _modId.ToString();
                    if (!ushort.TryParse(str.GetLastChars(5), out _networkId))
                    {
                        _networkId = ushort.Parse(str.GetLastChars(4));
                    }
                    MyAPIGateway.Multiplayer.RegisterMessageHandler(_networkId, MPMessageHandler);
                    _initDone = true;
                    if (IsClient)
                    {
                        if (IsServer)
                        {
                            RegisterPlayer(MyAPIGateway.Multiplayer.MyId);
                        }
                        else
                        {
                            SendMessageToServer(new PacketHello());
                        }
                    }
                    if (IsServer)
                    {
                        MyVisualScriptLogicProvider.PlayerConnected += PlayerConnectedHandler;
                        MyVisualScriptLogicProvider.PlayerDisconnected += PlayerDisconnectedHandler;
                        //TODO: make fallback(loop by players, once per something)
                        //TODO: plan identity cleanup, once per something check identities fo removed ones
                    }
                }
            }, nameof(NetworkHandlerSystem));
        }

        public void SetVariableValue(long entity, ulong key, byte[] value)
        {
            ConcurrentDictionary<ulong, NetworkVar> vars;
            if (entity == 0)
            {
                vars = globalVariables;
            }
            else if (!entityVariables.TryGetValue(entity, out vars))
            {
                return;
            }
            NetworkVar var;
            if (vars.TryGetValue(key, out var))
            {
                var.UpdateValue(value);
            }
        }
        public void SendVariableValue(long entity, ulong key, ulong target)
        {
            ConcurrentDictionary<ulong, NetworkVar> vars;
            if (entity == 0)
            {
                vars = globalVariables;
            }
            else if (!entityVariables.TryGetValue(entity, out vars))
            {
                return;
            }
            NetworkVar var;
            if (vars.TryGetValue(key, out var))
            {
                var.SentTo(target);
            }
        }

        private void PlayerDisconnectedHandler(long playerId)
        {
            var steamId = MyAPIGateway.Multiplayer.Players.TryGetSteamId(playerId);
            if (steamId != 0)
                DeregisterPlayer(steamId);
        }

        private void PlayerConnectedHandler(long playerId)
        {
            var steamId = MyAPIGateway.Multiplayer.Players.TryGetSteamId(playerId);
            if (steamId != 0)
                RegisterPlayer(steamId);
        }
        public void MPMessageHandler(byte[] data)
        {
            PacketBase packet = null;
            try
            {
                packet = data.FromBinary<PacketBase>();
            }
            catch (Exception e)
            {
                $"MPMessageHandler FromBinary Exception: {e}".Log(true);
                return;
            }
            if (packet != null && packet.ModId == _modId)
            {
                try
                {
                    packet.HandlePacket(this);
                }
                catch (Exception e)
                {
                    $"MPMessageHandler Exception: {e}".Log(true);
                }
            }
        }

        public void Dispose()
        {
            MyAPIGateway.Multiplayer.UnregisterMessageHandler(_networkId, MPMessageHandler);
            MyVisualScriptLogicProvider.PlayerConnected -= PlayerConnectedHandler;
            MyVisualScriptLogicProvider.PlayerDisconnected -= PlayerDisconnectedHandler;
            globalVariables.Clear();
            entityVariables.Clear();
            player2Identity.Clear();
            identity2Player.Clear();
            players.Clear();
            _identities.Clear();
            playerForId.Clear();
            toOthersLock.Dispose();
            toOthersList.Clear();
        }

        internal void SendMessageToServer(PacketBase data)
        {
            if (IsServer)
            {
                data.Sender = MyAPIGateway.Multiplayer.MyId;
                data.HandlePacket(this);
            }
            else
            {
                var res = PreparePacket(data, SendTarget.ToServer, 0, null, false);
                if (res != null)
                    MyAPIGateway.Multiplayer.SendMessageToServer(_networkId, res);
            }
        }
        internal void SendMessageTo(PacketBase data, ulong target)
        {
            if (!IsServer)
            {
                var targets = new[] { target };
                var res = PreparePacket(data, SendTarget.Proxy, 0, targets, false);
                if (res != null)
                    SendMessageToServer(new PacketProxy { Data = res, Targets = targets, IsBroadcast = false });
            }
            else
            {
                var id = MyAPIGateway.Multiplayer.MyId;
                if (target == id)
                {
                    data.Sender = id;
                    data.HandlePacket(this);
                }
                else
                {
                    var res = PreparePacket(data, SendTarget.ToTarget, target, null, false);
                    if (res != null)
                        SendMessageTo(res, target);
                }
            }
        }

        internal void SendMessageTo(byte[] data, ulong target)
        {
            MyAPIGateway.Multiplayer.SendMessageTo(_networkId, data, target);
        }

        internal void SendMessageTo(PacketBase data, params ulong[] targets)
        {
            if (targets.Length == 0)
                return;
            if (!IsServer)
            {
                var res = PreparePacket(data, SendTarget.Proxy, 0, targets, false);
                if (res != null)
                    SendMessageToServer(new PacketProxy { Data = res, Targets = targets, IsBroadcast = false });
            }
            else
            {
                var bytes = PreparePacket(data, SendTarget.ToTargets, 0, targets, false);
                if (bytes != null)
                    SendMessageTo(bytes, targets);
            }
        }

        internal void SendMessageTo(byte[] data, ulong[] targets)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                MyAPIGateway.Multiplayer.SendMessageTo(_networkId, data, targets[i]);
            }
        }

        internal void SendMessageToOthers(PacketBase data)
        {
            if (!IsServer)
            {
                var res = PreparePacket(data, SendTarget.Proxy, 0, null, true);
                if (res != null)
                    SendMessageToServer(new PacketProxy { Data = res, IsBroadcast = true });
            }
            else
            {
                var res = PreparePacket(data, SendTarget.ToOthers, 0, null, false);
                if (res != null)
                {
                    SendMessageToOthers(res);
                }
            }
        }
        enum SendTarget
        {
            ToOthers,
            ToOthersExcluding,
            ToServer,
            ToTarget,
            ToTargets,
            Proxy
        }
        byte[] PreparePacket(PacketBase packet, SendTarget type, ulong target, ulong[] targets, bool isBroadcast)
        {
            packet.Sender = MyAPIGateway.Multiplayer.MyId;
            packet.ModId = _modId;
            var res = packet.ToBinary();
            if (!(packet is PacketProxy) && res.Length >= 1024 * 64)
            {
                MyAPIGateway.Parallel.Start(() =>
                {
                    var pack = new PacketGZip
                    {
                        Data = res.Compress(),
                        Sender = packet.Sender,
                        ModId = _modId
                    };
                    switch (type)
                    {
                        case SendTarget.ToOthers:
                            SendMessageToOthers(pack);
                            break;
                        case SendTarget.ToOthersExcluding:
                            SendMessageToOthers(pack, targets);
                            break;
                        case SendTarget.ToServer:
                            SendMessageToServer(pack);
                            break;
                        case SendTarget.ToTarget:
                            SendMessageTo(pack, target);
                            break;
                        case SendTarget.ToTargets:
                            SendMessageTo(pack, targets);
                            break;
                        case SendTarget.Proxy:
                            SendMessageToServer(new PacketProxy { Data = pack.ToBinary(), IsBroadcast = isBroadcast, Targets = targets });
                            break;
                        default:
                            throw new Exception("WTF?");
                    }
                });
                return null;
            }
            return res;
        }
        internal FastResourceLock toOthersLock = new FastResourceLock();
        internal List<IMyPlayer> toOthersList = new List<IMyPlayer>();
        internal void SendMessageToOthers(PacketBase data, params ulong[] excluding)
        {
            if (!IsServer)
            {
                var res = PreparePacket(data, SendTarget.Proxy, 0, excluding, true);
                if (res != null)
                    SendMessageToServer(new PacketProxy { Data = res, Targets = excluding, IsBroadcast = true });
            }
            else
            {
                var res = PreparePacket(data, SendTarget.ToOthersExcluding, 0, excluding, false);
                if (res != null)
                {
                    SendMessageToOthers(res, excluding);
                }
            }
        }

        internal void SendMessageToOthers(byte[] res)
        {
            using (toOthersLock.AcquireExclusiveUsing())
            {
                toOthersList.Clear();
                if (IsClient)
                {
                    var pl = MyAPIGateway.Session.Player;
                    MyAPIGateway.Players.GetPlayers(toOthersList, p => p != pl);
                }
                else
                {
                    MyAPIGateway.Players.GetPlayers(toOthersList);
                }
            }
            for (int i = 0; i < toOthersList.Count; i++)
            {
                MyAPIGateway.Multiplayer.SendMessageTo(_networkId, res, toOthersList[i].SteamUserId);
            }
        }
        internal void SendMessageToOthers(byte[] res, params ulong[] excluding)
        {
            using (toOthersLock.AcquireExclusiveUsing())
            {
                toOthersList.Clear();
                if (IsClient)
                {
                    var pl = MyAPIGateway.Session.Player;
                    MyAPIGateway.Players.GetPlayers(toOthersList, p => p != pl && Array.IndexOf(excluding, p.SteamUserId) < 0);
                }
                else
                {
                    MyAPIGateway.Players.GetPlayers(toOthersList, p => Array.IndexOf(excluding, p.SteamUserId) < 0);
                }
            }
            for (int i = 0; i < toOthersList.Count; i++)
            {
                MyAPIGateway.Multiplayer.SendMessageTo(_networkId, res, toOthersList[i].SteamUserId);
            }
        }


        /// <summary>
        /// DS server
        /// </summary>
        public static bool IsDedicaded
        {
            get
            {
                return MyAPIGateway.Utilities.IsDedicated;
            }
        }
        /// <summary>
        /// Can draw something
        /// </summary>
        public static bool IsClient
        {
            get
            {
                return !IsDedicaded;
            }
        }
        /// <summary>
        /// Can rule them all!
        /// </summary>
        public static bool IsServer
        {
            get
            {
                return IsDedicaded || MyAPIGateway.Multiplayer.IsServer;
            }
        }

        public static bool IsMultiplayer
        {
            get
            {
                return MyAPIGateway.Session.SessionSettings.OnlineMode != VRage.Game.MyOnlineModeEnum.OFFLINE;
            }
        }

    }
}
