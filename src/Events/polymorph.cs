namespace NWN.Events {
    public class PolymorphEvent : NWNXEvent {
        public delegate void EventDelegate(PolymorphEvent e);

        public const string BEFORE_POLYMORPH = "NWNX_ON_POLYMORPH_BEFORE";
        public const string AFTER_POLYMORPH = "NWNX_ON_POLYMORPH_AFTER";
        public const string BEFORE_UNPOLYMORPH = "NWNX_ON_UNPOLYMORPH_BEFORE";
        public const string AFTER_UNPOLYMORPH = "NWNX_ON_UNPOLYMORPH_AFTER";

        public static EventDelegate BeforePolymorph = delegate { };
        public static EventDelegate AfterPolymorph = delegate { };
        public static EventDelegate BeforeUnPolymorph = delegate { };
        public static EventDelegate AfterUnPolymorph = delegate { };

        public PolymorphEvent(string script) {
            EventType = script;
        }

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public int PolymorphType => GetEventInt("POLYMORPH_TYPE");

        [NWNEventHandler(BEFORE_POLYMORPH)]
        [NWNEventHandler(AFTER_POLYMORPH)]
        [NWNEventHandler(BEFORE_UNPOLYMORPH)]
        [NWNEventHandler(AFTER_UNPOLYMORPH)]
        public static void EventHandler(string script) {
            var e = new PolymorphEvent(script);
            switch (script) {
                case BEFORE_POLYMORPH:
                    BeforePolymorph(e);
                    break;
                case AFTER_POLYMORPH:
                    AfterPolymorph(e);
                    break;
                case BEFORE_UNPOLYMORPH:
                    BeforeUnPolymorph(e);
                    break;
                case AFTER_UNPOLYMORPH:
                    AfterUnPolymorph(e);
                    break;
            }
        }
    }
}