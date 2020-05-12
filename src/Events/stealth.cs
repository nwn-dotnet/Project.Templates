namespace NWN.Events {
    public class StealthEvent : NWNXEvent {
        public delegate void EventDelegate(StealthEvent e);

        public const string BEFORE_ENTER = "NWNX_ON_ENTER_STEALTH_BEFORE";
        public const string AFTER_ENTER = "NWNX_ON_ENTER_STEALTH_AFTER";
        public const string BEFORE_EXIT = "NWNX_ON_EXIT_STEALTH_BEFORE";
        public const string AFTER_EXIT = "NWNX_ON_EXIT_STEALTH_AFTER";

        public static EventDelegate BeforeEnterStealth = delegate { };
        public static EventDelegate AfterEnterStealth = delegate { };
        public static EventDelegate BeforeExitStealth = delegate { };
        public static EventDelegate AfterExitStealth = delegate { };

        public StealthEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();

        [NWNEventHandler(BEFORE_ENTER)]
        [NWNEventHandler(AFTER_ENTER)]
        [NWNEventHandler(BEFORE_EXIT)]
        [NWNEventHandler(AFTER_EXIT)]
        public static void EventHandler(string script) {
            var e = new StealthEvent(script);
            switch (script) {
                case BEFORE_ENTER:
                    BeforeEnterStealth(e);
                    break;
                case AFTER_ENTER:
                    AfterEnterStealth(e);
                    break;
                case BEFORE_EXIT:
                    BeforeEnterStealth(e);
                    break;
                case AFTER_EXIT:
                    AfterEnterStealth(e);
                    break;
            }
        }
    }
}