namespace NWN.Events
{
    public class TrapEvent : NWNXEvent
    {
        public const string BEFORE_TRAP_DISARM	= "NWNX_ON_TRAP_DISARM_BEFORE";
        public const string AFTER_TRAP_DISARM	= "NWNX_ON_TRAP_DISARM_AFTER";
        public const string BEFORE_TRAP_ENTER	= "NWNX_ON_TRAP_ENTER_BEFORE";
        public const string AFTER_TRAP_ENTER	= "NWNX_ON_TRAP_ENTER_AFTER";
        public const string BEFORE_TRAP_EXAMINE	= "NWNX_ON_TRAP_EXAMINE_BEFORE";
        public const string AFTER_TRAP_EXAMINE	= "NWNX_ON_TRAP_EXAMINE_AFTER";
        public const string BEFORE_TRAP_FLAG	= "NWNX_ON_TRAP_FLAG_BEFORE";
        public const string AFTER_TRAP_FLAG	    = "NWNX_ON_TRAP_FLAG_AFTER";
        public const string BEFORE_TRAP_RECOVER	= "NWNX_ON_TRAP_RECOVER_BEFORE";
        public const string AFTER_TRAP_RECOVER	= "NWNX_ON_TRAP_RECOVER_AFTER";
        public const string BEFORE_TRAP_SET	    = "NWNX_ON_TRAP_SET_BEFORE";
        public const string AFTER_TRAP_SET	    = "NWNX_ON_TRAP_SET_AFTER";

        public delegate void EventDelegate(TrapEvent e);
    
        public static EventDelegate BeforeTrapDisarm	= delegate {};
        public static EventDelegate AfterTrapDisarm	    = delegate {};
        public static EventDelegate BeforeTrapEnter	    = delegate {};
        public static EventDelegate AfterTrapEnter	    = delegate {};
        public static EventDelegate BeforeTrapExamine	= delegate {};
        public static EventDelegate AfterTrapExamine    = delegate {};
        public static EventDelegate BeforeTrapFlag  	= delegate {};
        public static EventDelegate AfterTrapFlag       = delegate {};
        public static EventDelegate BeforeTrapRecover	= delegate {};
        public static EventDelegate AfterTrapRecover    = delegate {};
        public static EventDelegate BeforeTrapSet   	= delegate {};
        public static EventDelegate AfterTrapSet        = delegate {};
    
        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public NWObject Trap => GetEventObject("TRAP_OBJECT_ID").AsObject();
        public bool ActionSuccess
        {
            get => GetEventInt("ACTION_RESULT") == 1;
            set => SetEventResult(value ? "1" : "0");
        }
    
        public TrapEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_TRAP_DISARM)]
        [NWNEventHandler(AFTER_TRAP_DISARM)]
        [NWNEventHandler(BEFORE_TRAP_EXAMINE)]
        [NWNEventHandler(AFTER_TRAP_EXAMINE)]
        [NWNEventHandler(BEFORE_TRAP_FLAG)]
        [NWNEventHandler(AFTER_TRAP_FLAG)]
        [NWNEventHandler(BEFORE_TRAP_RECOVER)]
        [NWNEventHandler(AFTER_TRAP_RECOVER)]
        [NWNEventHandler(BEFORE_TRAP_SET)]
        [NWNEventHandler(AFTER_TRAP_SET)]
        public static void EventHandler(string script)
        {
            var e = new TrapEvent(script);
            switch (script)
            {
                case BEFORE_TRAP_DISARM:	BeforeTrapDisarm(e); break;
                case AFTER_TRAP_DISARM:	    AfterTrapDisarm(e); break;
                case BEFORE_TRAP_EXAMINE:	BeforeTrapExamine(e); break;
                case AFTER_TRAP_EXAMINE:	AfterTrapExamine(e); break;
                case BEFORE_TRAP_FLAG:	    BeforeTrapFlag(e); break;
                case AFTER_TRAP_FLAG:	    AfterTrapFlag(e); break;
                case BEFORE_TRAP_RECOVER:	BeforeTrapRecover(e); break;
                case AFTER_TRAP_RECOVER:	AfterTrapRecover(e); break;
                case BEFORE_TRAP_SET:	    BeforeTrapSet(e); break;
                case AFTER_TRAP_SET:	    AfterTrapSet(e); break;
            }
        }
    }
}