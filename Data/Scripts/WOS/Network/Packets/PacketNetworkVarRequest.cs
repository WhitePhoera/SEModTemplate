#line 2
using Phoera.Framework;
using Phoera.Framework.Interfaces;
using Phoera.Framework.Utils;
using ProtoBuf;
using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
    public sealed class PacketNetworkVarRequest : PacketNetworkVarBase
    {
        public override void HandlePacket(NetworkHandlerSystem nhs)
        {
            nhs.SendVariableValue(Entity, Variable, Sender);
        }
    }
}
