namespace NWN.Events
{
    public class LearnScrollEvent : NWNXEvent
    {
        public const string BEFORE_LEARN = "NWNX_ON_ITEM_SCROLL_LEARN_BEFORE";
        public const string AFTER_LEARN  = "NWNX_ON_ITEM_SCROLL_LEARN_AFTER";

        public delegate void EventDelegate(LearnScrollEvent e);

        public static EventDelegate BeforeLearnScroll          = delegate {};
        public static EventDelegate AfterLearnScroll           = delegate {};

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public NWItem Scroll => GetEventObject("SCROLL").AsItem();

        public LearnScrollEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_LEARN)]
        [NWNEventHandler(AFTER_LEARN)]
        public static void EventHandler(string script)
        {
            var e = new LearnScrollEvent(script);
            switch (script)
            {
                case BEFORE_LEARN:    BeforeLearnScroll(e); break;
                case AFTER_LEARN:     AfterLearnScroll(e); break;
                default: break;
            }
        }
    }
}