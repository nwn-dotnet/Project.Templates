using System;
namespace NWN.Events {
    public class MapPinEvent : NWNXEvent {
        public delegate void EventDelegate(MapPinEvent e);

        public const string MAP_PIN_ADD_PIN_BEFORE = "NWNX_ON_MAP_PIN_ADD_PIN_BEFORE";
        public const string MAP_PIN_ADD_PIN_AFTER = "NWNX_ON_MAP_PIN_ADD_PIN_AFTER";
        public const string MAP_PIN_CHANGE_PIN_BEFORE = "NWNX_ON_MAP_PIN_CHANGE_PIN_BEFORE";
        public const string MAP_PIN_CHANGE_PIN_AFTER = "NWNX_ON_MAP_PIN_CHANGE_PIN_AFTER";
        public const string MAP_PIN_DESTROY_PIN_BEFORE = "NWNX_ON_MAP_PIN_DESTROY_PIN_BEFORE";
        public const string MAP_PIN_DESTROY_PIN_AFTER = "NWNX_ON_MAP_PIN_DESTROY_PIN_AFTER";

        public static EventDelegate BeforeMapPinAdd = delegate { };
        public static EventDelegate AfterMapPinAdd = delegate { };
        public static EventDelegate BeforeMapPinChange = delegate { };
        public static EventDelegate AfterMapPinChange = delegate { };
        public static EventDelegate BeforeMapPinDestroy = delegate { };
        public static EventDelegate AfterMapPinDestroy = delegate { };

        public MapPinEvent(string script) {
            EventType = script;
        }

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public (float x, float y) PinPos => (GetEventFloat("PIN_X"), GetEventFloat("PIN_Y"));
        public int PinID => GetEventInt("PIN_ID");
        public string PinNote => GetEventString("PIN_NOTE");

        [NWNEventHandler(MAP_PIN_ADD_PIN_BEFORE)]
        [NWNEventHandler(MAP_PIN_ADD_PIN_AFTER)]
        [NWNEventHandler(MAP_PIN_CHANGE_PIN_BEFORE)]
        [NWNEventHandler(MAP_PIN_CHANGE_PIN_AFTER)]
        [NWNEventHandler(MAP_PIN_DESTROY_PIN_BEFORE)]
        [NWNEventHandler(MAP_PIN_DESTROY_PIN_AFTER)]
        public static void EventHandler(string script) {
            var e = new MapPinEvent(script);
            switch (script) {
                case MAP_PIN_ADD_PIN_BEFORE:
                    BeforeMapPinAdd(e);
                    break;
                case MAP_PIN_ADD_PIN_AFTER:
                    AfterMapPinAdd(e);
                    break;
                case MAP_PIN_CHANGE_PIN_BEFORE:
                    BeforeMapPinChange(e);
                    break;
                case MAP_PIN_CHANGE_PIN_AFTER:
                    AfterMapPinChange(e);
                    break;
                case MAP_PIN_DESTROY_PIN_BEFORE:
                    BeforeMapPinDestroy(e);
                    break;
                case MAP_PIN_DESTROY_PIN_AFTER:
                    AfterMapPinDestroy(e);
                    break;
            }
        }
    }
}