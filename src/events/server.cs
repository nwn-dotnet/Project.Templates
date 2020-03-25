using System;

namespace NWN.Events {
	public class ServerEvent : NWNXEvent {
	    public delegate void EventDelegate();

        public class Events {
            public static EventDelegate Shutdown = delegate { };
        }

        public static class EventHandlers {
            // module shutdown
            [NWNEventHandler("mod_shutdown")]
            public static void Shutdown(string script) {
                Console.WriteLine("test");
            }
        }
    }
}