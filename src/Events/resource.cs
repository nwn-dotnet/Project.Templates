namespace NWN.Events {
	public class ResourceChangeEvent : NWNXEvent {
		public delegate void EventDelegate(ResourceChangeEvent e);

		public const string RESOURCE_ADDED = "NWNX_ON_RESOURCE_ADDED";
		public const string RESOURCE_REMOVED = "NWNX_ON_RESOURCE_REMOVED";
		public const string RESOURCE_MODIFIED = "NWNX_ON_RESOURCE_MODIFIED";

		public static EventDelegate ResourceAdded = delegate { };
		public static EventDelegate ResourceRemoved = delegate { };
		public static EventDelegate ResourceModified = delegate { };

		public ResourceChangeEvent(string script) {
			EventType = script;
		}

		public string Alias => GetEventString("ALIAS");
		public string ResourceResref => GetEventString("RESREF");
		public string ResourceType => GetEventString("TYPE");

		[NWNEventHandler(RESOURCE_ADDED)]
		[NWNEventHandler(RESOURCE_REMOVED)]
		[NWNEventHandler(RESOURCE_MODIFIED)]
		public static void EventHandler(string script) {
			var e = new ResourceChangeEvent(script);
			switch (script) {
				case RESOURCE_ADDED:
					ResourceAdded(e);
					break;
				case RESOURCE_REMOVED:
					ResourceRemoved(e);
					break;
				case RESOURCE_MODIFIED:
					ResourceModified(e);
					break;
			}
		}
	}
}