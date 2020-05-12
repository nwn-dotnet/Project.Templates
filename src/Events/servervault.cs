namespace NWN.Events {
    public class ServerVaultEvent : NWNXEvent {
        public delegate void EventDelegate(ServerVaultEvent e);

        public const string BEFORE_CHECK_STICKY_NAME = "NWNX_ON_CHECK_STICKY_PLAYER_NAME_RESERVED_BEFORE";
        public const string AFTER_CHECK_STICKY_NAME = "NWNX_ON_CHECK_STICKY_PLAYER_NAME_RESERVED_AFTER";

        public static EventDelegate BeforeCheckStickyName = delegate { };
        public static EventDelegate AfterCheckStickyName = delegate { };

        public ServerVaultEvent(string script) {
            EventType = script;
        }

        public NWObject Module => Internal.OBJECT_SELF.AsObject();
        public string PlayerName => GetEventString("PLAYER_NAME");
        public string CDKey => GetEventString("CDKEY");
        public string LegacyCDKey => GetEventString("LEGACY_CDKEY");
        public bool IsDM => GetEventInt("IS_DM") == 1;

        [NWNEventHandler(BEFORE_CHECK_STICKY_NAME)]
        [NWNEventHandler(AFTER_CHECK_STICKY_NAME)]
        public static void EventHandler(string script) {
            var e = new ServerVaultEvent(script);
            switch (script) {
                case BEFORE_CHECK_STICKY_NAME:
                    BeforeCheckStickyName(e);
                    break;
                case AFTER_CHECK_STICKY_NAME:
                    AfterCheckStickyName(e);
                    break;
            }
        }
    }
    public class ServerCharacterEvent : NWNXEvent {
        public delegate void EventDelegate(ServerCharacterEvent e);

        public const string SERVER_CHARACTER_SAVE_BEFORE = "NWNX_ON_SERVER_CHARACTER_SAVE_BEFORE";
        public const string SERVER_CHARACTER_SAVE_AFTER = "NWNX_ON_SERVER_CHARACTER_SAVE_AFTER";

        public static EventDelegate BeforeServerCharacterSave = delegate { };
        public static EventDelegate AfterServerCharacterSave = delegate { };

        public ServerCharacterEvent(string script) {
            EventType = script;
        }

        public NWPlayer Character => Internal.OBJECT_SELF.AsPlayer();

        [NWNEventHandler(SERVER_CHARACTER_SAVE_BEFORE)]
        [NWNEventHandler(SERVER_CHARACTER_SAVE_AFTER)]
        public static void EventHandler(string script) {
            var e = new ServerCharacterEvent(script);
            switch (script) {
                case SERVER_CHARACTER_SAVE_BEFORE:
                    BeforeServerCharacterSave(e);
                    break;
                case SERVER_CHARACTER_SAVE_AFTER:
                    AfterServerCharacterSave(e);
                    break;
            }
        }
    }
    public class UUIDCollisionEvent : NWNXEvent {
        public delegate void EventDelegate(UUIDCollisionEvent e);

        // Note: To get the existing object with `UUID` you can use GetObjectByUUID(), be aware that this event runs before the 
        // object is added to the world which means many functions(for example `GetArea(OBJECT_SELF)`) will not work.

        public const string UUID_COLLISION_BEFORE = "NWNX_ON_UUID_COLLISION_BEFORE";
        public const string UUID_COLLISION_AFTER = "NWNX_ON_UUID_COLLISION_AFTER";

        public static EventDelegate BeforeUUIDCollision = delegate { };
        public static EventDelegate AfterUUIDCollision = delegate { };

        public UUIDCollisionEvent(string script) {
            EventType = script;
        }

        public NWObject CollidingObject => Internal.OBJECT_SELF.AsObject();

        [NWNEventHandler(UUID_COLLISION_BEFORE)]
        [NWNEventHandler(UUID_COLLISION_AFTER)]
        public static void EventHandler(string script) {
            var e = new UUIDCollisionEvent(script);
            switch (script) {
                case UUID_COLLISION_BEFORE:
                    BeforeUUIDCollision(e);
                    break;
                case UUID_COLLISION_AFTER:
                    AfterUUIDCollision(e);
                    break;
            }
        }
    }
}