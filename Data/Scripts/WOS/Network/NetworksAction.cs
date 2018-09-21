#line 2
using Phoera.Framework;
using ProtoBuf;
using Sandbox.ModAPI;

namespace Phoera.Network
{
	public static class NetworkActionExtensions
	{
		public static Actions.NetworkAction CreateAction(this NetworkHandlerSystem nhs, Actions.NAction handler)
		{
			return new Actions.NetworkAction(nhs,handler);
		}
		public static Actions.NetworkAction<T1> CreateAction<T1>(this NetworkHandlerSystem nhs, Actions.NAction<T1> handler)
		{
			return new Actions.NetworkAction<T1>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2> CreateAction<T1, T2>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2> handler)
		{
			return new Actions.NetworkAction<T1, T2>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3> CreateAction<T1, T2, T3>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4> CreateAction<T1, T2, T3, T4>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5> CreateAction<T1, T2, T3, T4, T5>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6> CreateAction<T1, T2, T3, T4, T5, T6>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7> CreateAction<T1, T2, T3, T4, T5, T6, T7>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(nhs,handler);
		}
		public static Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> CreateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this NetworkHandlerSystem nhs, Actions.NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler)
		{
			return new Actions.NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(nhs,handler);
		}
	}
}
namespace Phoera.Network.Actions
{
	public delegate void NAction(ulong sender);

	public class NetworkAction
	{
		readonly NAction _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		public NetworkAction(NetworkHandlerSystem nhs, NAction handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket()
		{
			var res = new Packets.PacketAction { Id = _id };
			return res;
		}
		public void CallToServer()
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket());
		}
		public void CallToOthers()
		{
			_nhs.SendMessageToOthers(PreparePacket());
		}
		public void CallToOthers(params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(), excluding);
		}
		public void CallTo(params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(), targets);
		}
		public void CallTo(ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			_handler(sender);
		}
	}

	public delegate void NAction<T1>(ulong sender, T1 arg1);

	public class NetworkAction<T1>
	{
		readonly NAction<T1> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1));
		}
		public void CallToOthers(T1 arg1)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1));
		}
		public void CallToOthers(T1 arg1, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1), excluding);
		}
		public void CallTo(T1 arg1, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1), targets);
		}
		public void CallTo(T1 arg1, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1);
		}
	}

	public delegate void NAction<T1, T2>(ulong sender, T1 arg1, T2 arg2);

	public class NetworkAction<T1, T2>
	{
		readonly NAction<T1, T2> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2));
		}
		public void CallToOthers(T1 arg1, T2 arg2)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2));
		}
		public void CallToOthers(T1 arg1, T2 arg2, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2);
		}
	}

	public delegate void NAction<T1, T2, T3>(ulong sender, T1 arg1, T2 arg2, T3 arg3);

	public class NetworkAction<T1, T2, T3>
	{
		readonly NAction<T1, T2, T3> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3);
		}
	}

	public delegate void NAction<T1, T2, T3, T4>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

	public class NetworkAction<T1, T2, T3, T4>
	{
		readonly NAction<T1, T2, T3, T4> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

	public class NetworkAction<T1, T2, T3, T4, T5>
	{
		readonly NAction<T1, T2, T3, T4, T5> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);

	public class NetworkAction<T1, T2, T3, T4, T5, T6>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
			[ProtoMember(9)]
			public T9 arg9;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			t.arg9 = arg9;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8, args.arg9);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
			[ProtoMember(9)]
			public T9 arg9;
			[ProtoMember(10)]
			public T10 arg10;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			t.arg9 = arg9;
			t.arg10 = arg10;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8, args.arg9, args.arg10);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
			[ProtoMember(9)]
			public T9 arg9;
			[ProtoMember(10)]
			public T10 arg10;
			[ProtoMember(11)]
			public T11 arg11;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			t.arg9 = arg9;
			t.arg10 = arg10;
			t.arg11 = arg11;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8, args.arg9, args.arg10, args.arg11);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
			[ProtoMember(9)]
			public T9 arg9;
			[ProtoMember(10)]
			public T10 arg10;
			[ProtoMember(11)]
			public T11 arg11;
			[ProtoMember(12)]
			public T12 arg12;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			t.arg9 = arg9;
			t.arg10 = arg10;
			t.arg11 = arg11;
			t.arg12 = arg12;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8, args.arg9, args.arg10, args.arg11, args.arg12);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
			[ProtoMember(9)]
			public T9 arg9;
			[ProtoMember(10)]
			public T10 arg10;
			[ProtoMember(11)]
			public T11 arg11;
			[ProtoMember(12)]
			public T12 arg12;
			[ProtoMember(13)]
			public T13 arg13;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			t.arg9 = arg9;
			t.arg10 = arg10;
			t.arg11 = arg11;
			t.arg12 = arg12;
			t.arg13 = arg13;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8, args.arg9, args.arg10, args.arg11, args.arg12, args.arg13);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
			[ProtoMember(9)]
			public T9 arg9;
			[ProtoMember(10)]
			public T10 arg10;
			[ProtoMember(11)]
			public T11 arg11;
			[ProtoMember(12)]
			public T12 arg12;
			[ProtoMember(13)]
			public T13 arg13;
			[ProtoMember(14)]
			public T14 arg14;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			t.arg9 = arg9;
			t.arg10 = arg10;
			t.arg11 = arg11;
			t.arg12 = arg12;
			t.arg13 = arg13;
			t.arg14 = arg14;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8, args.arg9, args.arg10, args.arg11, args.arg12, args.arg13, args.arg14);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
			[ProtoMember(9)]
			public T9 arg9;
			[ProtoMember(10)]
			public T10 arg10;
			[ProtoMember(11)]
			public T11 arg11;
			[ProtoMember(12)]
			public T12 arg12;
			[ProtoMember(13)]
			public T13 arg13;
			[ProtoMember(14)]
			public T14 arg14;
			[ProtoMember(15)]
			public T15 arg15;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			t.arg9 = arg9;
			t.arg10 = arg10;
			t.arg11 = arg11;
			t.arg12 = arg12;
			t.arg13 = arg13;
			t.arg14 = arg14;
			t.arg15 = arg15;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8, args.arg9, args.arg10, args.arg11, args.arg12, args.arg13, args.arg14, args.arg15);
		}
	}

	public delegate void NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ulong sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

	public class NetworkAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
	{
		readonly NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> _handler;
		readonly NetworkHandlerSystem _nhs;
		readonly ulong _id;

		[ProtoContract]
		struct Args 
		{
			[ProtoMember(1)]
			public T1 arg1;
			[ProtoMember(2)]
			public T2 arg2;
			[ProtoMember(3)]
			public T3 arg3;
			[ProtoMember(4)]
			public T4 arg4;
			[ProtoMember(5)]
			public T5 arg5;
			[ProtoMember(6)]
			public T6 arg6;
			[ProtoMember(7)]
			public T7 arg7;
			[ProtoMember(8)]
			public T8 arg8;
			[ProtoMember(9)]
			public T9 arg9;
			[ProtoMember(10)]
			public T10 arg10;
			[ProtoMember(11)]
			public T11 arg11;
			[ProtoMember(12)]
			public T12 arg12;
			[ProtoMember(13)]
			public T13 arg13;
			[ProtoMember(14)]
			public T14 arg14;
			[ProtoMember(15)]
			public T15 arg15;
			[ProtoMember(16)]
			public T16 arg16;
		}
		public NetworkAction(NetworkHandlerSystem nhs, NAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler)
		{
			_nhs = nhs;
			_id = nhs.RegisterActionHandler(HandlePacket);
			_handler = handler;
		}
		Packets.PacketAction PreparePacket(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
			var res = new Packets.PacketAction { Id = _id };
			var t = new Args();
			t.arg1 = arg1;
			t.arg2 = arg2;
			t.arg3 = arg3;
			t.arg4 = arg4;
			t.arg5 = arg5;
			t.arg6 = arg6;
			t.arg7 = arg7;
			t.arg8 = arg8;
			t.arg9 = arg9;
			t.arg10 = arg10;
			t.arg11 = arg11;
			t.arg12 = arg12;
			t.arg13 = arg13;
			t.arg14 = arg14;
			t.arg15 = arg15;
			t.arg16 = arg16;
			res.Data = t.ToBinary();
			return res;
		}
		public void CallToServer(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
			if(NetworkHandlerSystem.IsServer)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
				return;
			}
			_nhs.SendMessageToServer(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
		}
		public void CallToOthers(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, params ulong[] excluding)
		{
			_nhs.SendMessageToOthers(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), excluding);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, params ulong[] targets)
		{
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), targets);
		}
		public void CallTo(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, ulong target)
		{
			if(target == MyAPIGateway.Multiplayer.MyId)
			{
				_handler(MyAPIGateway.Multiplayer.MyId, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
				return;
			}
			_nhs.SendMessageTo(PreparePacket(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), target);
		}
		public void HandlePacket(ulong sender, byte[] data)
		{
			var args = data.FromBinary<Args>();
			_handler(sender, args.arg1, args.arg2, args.arg3, args.arg4, args.arg5, args.arg6, args.arg7, args.arg8, args.arg9, args.arg10, args.arg11, args.arg12, args.arg13, args.arg14, args.arg15, args.arg16);
		}
	}

}
