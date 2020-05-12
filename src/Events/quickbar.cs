namespace NWN.Events {
    public class QuickbarEvent : NWNXEvent {
        public delegate void EventDelegate(QuickbarEvent e);

        public const string QUICKBAR_SET_BUTTON_BEFORE = "NWNX_ON_QUICKBAR_SET_BUTTON_BEFORE";
        public const string QUICKBAR_SET_BUTTON_AFTER = "NWNX_ON_QUICKBAR_SET_BUTTON_AFTER";

        public static EventDelegate BeforeQuickBarSetButton = delegate { };
        public static EventDelegate AfterQuickBarSetButton = delegate { };

        public QuickbarEvent(string script) {
            EventType = script;
        }

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public int Button => GetEventInt("BUTTON");
        public NWNX.Enum.QuickBarSlotType ButtonType => (NWNX.Enum.QuickBarSlotType)GetEventInt("TYPE");

        [NWNEventHandler(QUICKBAR_SET_BUTTON_BEFORE)]
        [NWNEventHandler(QUICKBAR_SET_BUTTON_AFTER)]
        public static void EventHandler(string script) {
            var e = new QuickbarEvent(script);
            switch (script) {
                case QUICKBAR_SET_BUTTON_BEFORE:
                    BeforeQuickBarSetButton(e);
                    break;
                case QUICKBAR_SET_BUTTON_AFTER:
                    AfterQuickBarSetButton(e);
                    break;
            }
        }
    }
}