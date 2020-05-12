namespace NWN.Events {
    public class ClientConnectEvent : NWNXEvent {
        public delegate void EventDelegate(ClientConnectEvent e);

        public const string BEFORE_CONNECT = "NWNX_ON_CLIENT_CONNECT_BEFORE";
        public const string AFTER_CONNECT = "NWNX_ON_CLIENT_CONNECT_AFTER";

        public static EventDelegate BeforeClientConnect = delegate { };
        public static EventDelegate AfterClientConnect = delegate { };

        public ClientConnectEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public string PlayerName => GetEventString("PLAYER_NAME");
        public string PlayerCDKey => GetEventString("CDKEY");
        public string PlayerIP => GetEventString("IP_ADDRESS");
        public bool IsDM => GetEventInt("IS_DM") == 1;

        [NWNEventHandler(BEFORE_CONNECT)]
        [NWNEventHandler(AFTER_CONNECT)]
        public static void EventHandler(string script) {
            var e = new ClientConnectEvent(script);
            switch (script) {
                case BEFORE_CONNECT:
                    BeforeClientConnect(e);
                    break;
                case AFTER_CONNECT:
                    AfterClientConnect(e);
                    break;
            }
        }
    }

    public class ClientDisconnectEvent : NWNXEvent {
        public delegate void EventDelegate(ClientDisconnectEvent e);

        public const string BEFORE_DISCONNECT = "NWNX_ON_CLIENT_DISCONNECT_BEFORE";
        public const string AFTER_DISCONNECT = "NWNX_ON_CLIENT_DISCONNECT_AFTER";

        public static EventDelegate BeforeClientDisconnect = delegate { };
        public static EventDelegate AfterClientDisconnect = delegate { };

        public ClientDisconnectEvent(string script) {
            EventType = script;
        }

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();

        [NWNEventHandler(BEFORE_DISCONNECT)]
        [NWNEventHandler(AFTER_DISCONNECT)]
        public static void EventHandler(string script) {
            var e = new ClientDisconnectEvent(script);
            switch (script) {
                case BEFORE_DISCONNECT:
                    BeforeClientDisconnect(e);
                    break;
                case AFTER_DISCONNECT:
                    AfterClientDisconnect(e);
                    break;
            }
        }
    }
    public class ClientCharacterExportEvent : NWNXEvent {
        public delegate void EventDelegate(ClientCharacterExportEvent e);

        public const string BEFORE_EXPORT = "NWNX_ON_CLIENT_EXPORT_CHARACTER_BEFORE";
        public const string AFTER_EXPORT = "NWNX_ON_CLIENT_EXPORT_CHARACTER_AFTER";

        public static EventDelegate BeforeCharacterExport = delegate { };
        public static EventDelegate AfterCharacterExport = delegate { };

        public ClientCharacterExportEvent(string script) {
            EventType = script;
        }

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();

        [NWNEventHandler(BEFORE_EXPORT)]
        [NWNEventHandler(AFTER_EXPORT)]
        public static void EventHandler(string script) {
            var e = new ClientCharacterExportEvent(script);
            switch (script) {
                case BEFORE_EXPORT:
                    BeforeCharacterExport(e);
                    break;
                case AFTER_EXPORT:
                    AfterCharacterExport(e);
                    break;
            }
        }
    }
}