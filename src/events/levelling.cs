namespace NWN.Events
{
    public class LevellingEvent : NWNXEvent
    {
        public const string BEFORE_LEVEL_UP	    = "NWNX_ON_LEVEL_UP_BEFORE";
        public const string AFTER_LEVEL_UP	    = "NWNX_ON_LEVEL_UP_AFTER";
        public const string BEFORE_LEVEL_DOWN	= "NWNX_ON_LEVEL_DOWN_BEFORE";
        public const string AFTER_LEVEL_DOWN	= "NWNX_ON_LEVEL_DOWN_AFTER";
    
        public delegate void EventDelegate(LevellingEvent e);
    
        public static EventDelegate BeforeLevelUp	= delegate {};
        public static EventDelegate AfterLevelUp	= delegate {};
        public static EventDelegate BeforeLevelDown	= delegate {};
        public static EventDelegate AfterLevelDown	= delegate {};
    
        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
    
        public LevellingEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_LEVEL_UP)]
        [NWNEventHandler(AFTER_LEVEL_UP)]
        [NWNEventHandler(BEFORE_LEVEL_DOWN)]
        [NWNEventHandler(AFTER_LEVEL_DOWN)]
        public static void EventHandler(string script)
        {
            var e = new LevellingEvent(script);
            switch (script)
            {
                case BEFORE_LEVEL_UP:	BeforeLevelUp(e); break;
                case AFTER_LEVEL_UP:	AfterLevelUp(e); break;
                case BEFORE_LEVEL_DOWN:	BeforeLevelDown(e); break;
                case AFTER_LEVEL_DOWN:	AfterLevelDown(e); break;
            }
        }
    }
}