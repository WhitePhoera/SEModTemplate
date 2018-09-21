#line 2
using Phoera.Framework;
using Phoera.Framework.Interfaces;
using Phoera.Framework.Utils;
using ProtoBuf;
using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;
using VRage.Game.ModAPI;
using VRage.ModAPI;

/// <summary>
/// This file not public, you cannot copy it or use it parts without my permission.
/// Copyright - Phoera - 2016
/// </summary>
namespace Phoera.Network.Packets
{
    [ProtoContract]
    [ProtoInclude(1001, typeof(PacketHello))]
    [ProtoInclude(1002, typeof(PacketGZip))] // don't ask!
    [ProtoInclude(1003, typeof(PacketAction))]
    [ProtoInclude(1004, typeof(PacketProxy))]
    [ProtoInclude(1005, typeof(PacketNetworkVarUpdate))]
    [ProtoInclude(1006, typeof(PacketNetworkVarRequest))]
    [ProtoInclude(1007, typeof(PacketNetworkVarBatchUpdate))]
    public class PacketBase
    {
        [ProtoMember(1)]
        public ulong Sender;
        [ProtoMember(2)]
        public ulong ModId;

        public virtual void HandlePacket(NetworkHandlerSystem nhs) { }
    }
}
