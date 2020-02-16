namespace NWN.Events
{
    public class UseItemEvent : NWNXEvent
    {
        public override bool Skippable => true;

        public const string BEFORE_USE      = "NWNX_ON_USE_ITEM_BEFORE";
        public const string AFTER_USE       = "NWNX_ON_USE_ITEM_AFTER";

        public delegate void EventDelegate(UseItemEvent e);

        public static EventDelegate BeforeUseItem               = delegate {};
        public static EventDelegate AfterUseItem                = delegate {};

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public NWItem Item => GetEventObject("ITEM_OBJECT_ID").AsItem();
        public NWObject TargetObject => GetEventObject("TARGET_OBJECT_ID").AsObject();
        public int ItemPropertyIndex => GetEventInt("ITEM_PROPERTY_INDEX");
        public int ItemSubPropertyIndex => GetEventInt("ITEM_SUB_PROPERTY_INDEX");
        public Vector TargetVector => GetEventVector("TARGET_POSITION");

        public UseItemEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_USE)]
        [NWNEventHandler(AFTER_USE)]
        public static void EventHandler(string script)
        {
            var e = new UseItemEvent(script);
            switch (script)
            {
                case BEFORE_USE:    BeforeUseItem(e); break;
                case AFTER_USE:     AfterUseItem(e); break;
                default: break;
            }
        }
    }
}