﻿using System.Collections.Generic;
using System.Net;
using ETModel;

namespace ETHotfix
{
	[ObjectSystem]
	public class NetOuterComponentAwakeSystem : AwakeSystem<NetOuterComponent>
	{
		public override void Awake(NetOuterComponent self)
		{
			self.Awake(NetworkProtocol.WebSocket);
			self.MessagePacker = new ProtobufPacker();
			self.MessageDispatcher = new OuterMessageDispatcher();
		}
	}

	[ObjectSystem]
	public class NetOuterComponentAwake1System : AwakeSystem<NetOuterComponent, IPEndPoint>
	{
		public override void Awake(NetOuterComponent self, IPEndPoint ipEndPoint)
		{
			self.Awake(NetworkProtocol.TCP, ipEndPoint);
			self.MessagePacker = new ProtobufPacker();
			self.MessageDispatcher = new OuterMessageDispatcher();
		}
	}
	
	[ObjectSystem]
	public class NetOuterComponentAwake2System : AwakeSystem<NetOuterComponent, List<string>>
	{
		public override void Awake(NetOuterComponent self, List<string> prefixs)
		{
			self.Awake(NetworkProtocol.WebSocket, prefixs);
			self.MessagePacker = new ProtobufPacker();
			self.MessageDispatcher = new OuterMessageDispatcher();
		}
	}

	[ObjectSystem]
	public class NetOuterComponentUpdateSystem : UpdateSystem<NetOuterComponent>
	{
		public override void Update(NetOuterComponent self)
		{
			self.Update();
		}
	}
}