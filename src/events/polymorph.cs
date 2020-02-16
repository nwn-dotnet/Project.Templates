namespace NWN.Events
{
    public class PolymorphEvent : NWNXEvent
    {
        public const string BEFORE_POLYMORPH	= "NWNX_ON_POLYMORPH_BEFORE";
        public const string AFTER_POLYMORPH	= "NWNX_ON_POLYMORPH_AFTER";
    
        public delegate void EventDelegate(PolymorphEvent e);
    
        public static EventDelegate BeforePolymorph	= delegate {};
        public static EventDelegate AfterPolymorph	= delegate {};
    
        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public int PolymorphType => GetEventInt("POLYMORPH_TYPE");
    
        public PolymorphEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_POLYMORPH)]
        [NWNEventHandler(AFTER_POLYMORPH)]
        public static void EventHandler(string script)
        {
            var e = new PolymorphEvent(script);
            switch (script)
            {
                case BEFORE_POLYMORPH:	BeforePolymorph(e); break;
                case AFTER_POLYMORPH:	AfterPolymorph(e); break;
            }
        }
    }
}