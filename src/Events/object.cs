namespace NWN.Events {
    public class ObjectLockEvent : NWNXEvent {
        public delegate void EventDelegate(ObjectLockEvent e);

        public const string OBJECT_LOCK_BEFORE = "NWNX_ON_OBJECT_LOCK_BEFORE";
        public const string OBJECT_LOCK_AFTER = "NWNX_ON_OBJECT_LOCK_AFTER";

        public static EventDelegate BeforeLockObject = delegate { };
        public static EventDelegate AfterLockObject = delegate { };

        public ObjectLockEvent(string script) {
            EventType = script;
        }

        public NWObject Locker => Internal.OBJECT_SELF.AsObject();
        public NWObject Door => GetEventObject("DOOR").AsObject();

        [NWNEventHandler(OBJECT_LOCK_BEFORE)]
        [NWNEventHandler(OBJECT_LOCK_AFTER)]
        public static void EventHandler(string script) {
            var e = new ObjectLockEvent(script);
            switch (script) {
                case OBJECT_LOCK_BEFORE:
                    BeforeLockObject(e);
                    break;
                case OBJECT_LOCK_AFTER:
                    AfterLockObject(e);
                    break;
            }
        }
    }
    public class ObjectUnlockEvent : NWNXEvent {
        public delegate void EventDelegate(ObjectUnlockEvent e);

        public const string OBJECT_UNLOCK_BEFORE = "NWNX_ON_OBJECT_UNLOCK_BEFORE";
        public const string OBJECT_UNLOCK_AFTER = "NWNX_ON_OBJECT_UNLOCK_AFTER";

        public static EventDelegate BeforeUnlockObject = delegate { };
        public static EventDelegate AfterUnlockObject = delegate { };

        public ObjectUnlockEvent(string script) {
            EventType = script;
        }

        public NWObject Locker => Internal.OBJECT_SELF.AsObject();
        public NWObject Door => GetEventObject("DOOR").AsObject();
        public NWItem ThievesTool => GetEventObject("THIEVES_TOOL").AsItem();
        public int ActivePropertyIndex => GetEventInt("ACTIVE_PROPERTY_INDEX");

        [NWNEventHandler(OBJECT_UNLOCK_BEFORE)]
        [NWNEventHandler(OBJECT_UNLOCK_AFTER)]
        public static void EventHandler(string script) {
            var e = new ObjectUnlockEvent(script);
            switch (script) {
                case OBJECT_UNLOCK_BEFORE:
                    BeforeUnlockObject(e);
                    break;
                case OBJECT_UNLOCK_AFTER:
                    AfterUnlockObject(e);
                    break;
            }
        }
    }
}