#line 2
using ProtoBuf;
using System.Collections.Generic;

/// <summary>
/// This file not public, you cannot copy it or use it parts without my permission.
/// Copyright - Phoera - 2016
/// </summary>
namespace Phoera.Network.Packets
{
    [ProtoContract]
    public sealed class PacketNetworkVarBatchUpdate : PacketNetworkVarBase
    {
        [ProtoMember(201)]
        public Dictionary<ulong, byte[]> Data;

        public override void HandlePacket(NetworkHandlerSystem nhs)
        {
            if (Data != null)
                foreach (var pair in Data)
                {
                    nhs.SetVariableValue(Entity, pair.Key, pair.Value);
                }
        }
    }
}
