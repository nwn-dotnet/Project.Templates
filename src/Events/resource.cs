namespace NWN.Events {
    public class ResourceEvent : NWNXEvent {
        public delegate void EventDelegate(ResourceEvent e);

        //Note: These events fire when a file gets added/removed/modified in the /nwnx or /development folder

        public const string RESOURCE_ADDED = "NWNX_ON_RESOURCE_ADDED";
        public const string RESOURCE_REMOVED = "NWNX_ON_RESOURCE_REMOVED";
        public const string RESOURCE_MODIFIED = "NWNX_ON_RESOURCE_MODIFIED";

        public static EventDelegate ResourceAdded = delegate { };
        public static EventDelegate ResourceRemoved = delegate { };
        public static EventDelegate ResourceModified = delegate { };

        public ResourceEvent(string script) {
            EventType = script;
        }

        public NWModule Module => Internal.OBJECT_SELF.AsModule();
        public string Alias => GetEventString("ALIAS");
        public string ResRef => GetEventString("RESREF");
        public NWNX.Enum.ResRefType ResRefType => (NWNX.Enum.ResRefType)GetEventInt("TYPE");

        [NWNEventHandler(RESOURCE_ADDED)]
        [NWNEventHandler(RESOURCE_REMOVED)]
        [NWNEventHandler(RESOURCE_MODIFIED)]
        public static void EventHandler(string script) {
            var e = new ResourceEvent(script);
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