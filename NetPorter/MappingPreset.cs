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
		[NonSerialized()] public PortMapListener Listener;

		public bool Enabled;

		public override string ToString()
		{
			return Name;
		}
	}
}
