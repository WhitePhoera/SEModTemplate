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
    public sealed class PacketProxy : PacketBase
    {
        [ProtoMember(101)]
        public byte[] Data;
        [ProtoMember(102)]
        public ulong[] Targets;
        [ProtoMember(103)]
        public bool IsBroadcast;

        public override void HandlePacket(NetworkHandlerSystem nhs)
        {
            if (IsBroadcast)
            {
                if (Targets != null && Targets.Length > 0)
                {
                    nhs.SendMessageToOthers(Data, Targets);
                }
                else
                {
                    nhs.SendMessageToOthers(Data, Sender);
                }
            }
            else
            {
                if (Targets != null)
                {
                    if (Targets.Length > 1)
                    {
                        nhs.SendMessageTo(Data, Targets);
                    }
                    else
                    {
                        nhs.SendMessageTo(Data, Targets[0]);
                    }
                }
            }
        }
    }
}
