namespace NWN.Events
{
    public class HealerKitEvent : NWNXEvent
    {
        public const string BEFORE_USE = "NWNX_ON_HEALER_KIT_BEFORE";
        public const string AFTER_USE  = "NWNX_ON_HEALER_KIT_AFTER";

        public delegate void EventDelegate(HealerKitEvent e);

        public static EventDelegate BeforeUseKit = delegate {};
        public static EventDelegate AfterUseKit  = delegate {};

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public NWObject Target => GetEventObject("TARGET_OBJECT_ID").AsObject();
        public NWItem Item => GetEventObject("ITEM_OBJECT_ID").AsItem();
        public int ItemPropertyIndex => GetEventInt("ITEM_PROPERTY_INDEX");
        public int MoveToTarget => GetEventInt("MOVE_TO_TARGET");
        public int ActionResult 
        { 
            get => GetEventInt("ACTION_RESULT"); 
            set => SetEventResult(value.ToString()); 
        }

        public HealerKitEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_USE)]
        [NWNEventHandler(AFTER_USE)]
        public static void EventHandler(string script)
        {
            var e = new HealerKitEvent(script);
            switch (script)
            {
                case BEFORE_USE:    BeforeUseKit(e); break;
                case AFTER_USE:     AfterUseKit(e); break;
                default: break;
            }
        }
    }
}