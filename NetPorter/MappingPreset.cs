using Org.Mentalis.Proxy.PortMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetPorter
{
	[Serializable()]
	class MappingPreset
	{
		public string Name;
		public int ListenPort;
		public string DestinationHost;
		public int DestinationPort;
		public bool IPv4 = true;
		public bool IPv6 = false;
		public bool Reverse;
		[NonSerialized()] public PortMapListener Listener;
		[NonSerialized()] public PortMapListener IPv6Listener;
		[NonSerialized()] public Exception Reason;

		public bool Enabled;

		public override string ToString()
		{
			return Name;
		}
	}
}
