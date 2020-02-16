namespace NWN.Events
{
    public class UseFeatEvent : NWNXEvent
    {
        public const string BEFORE_USE_FEAT      = "NWNX_ON_USE_FEAT_BEFORE";
        public const string AFTER_USE_FEAT       = "NWNX_ON_USE_FEAT_AFTER";

        public delegate void EventDelegate(UseFeatEvent e);

        public static EventDelegate BeforeUseFeat          = delegate {};
        public static EventDelegate AfterUseFeat           = delegate {};

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public int FeatID => GetEventInt("FEAT_ID");
        public int SubFeatID => GetEventInt("SUBFEAT_ID");
        public NWObject TargetObject => GetEventObject("TARGET_OBJECT_ID").AsObject();
        public NWObjectBase AreaObject => GetEventObject("AREA_OBJECT_ID").AsObject();
        public Vector TargetVector => GetEventVector("TARGET_POSITION");

        public UseFeatEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_USE_FEAT)]
        [NWNEventHandler(AFTER_USE_FEAT)]
        public static void EventHandler(string script)
        {
            var e = new UseFeatEvent(script);
            switch (script)
            {
                case BEFORE_USE_FEAT:    BeforeUseFeat(e); break;
                case AFTER_USE_FEAT:     AfterUseFeat(e); break;
                default: break;
            }
        }
    }
}