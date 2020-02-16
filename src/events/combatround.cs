namespace NWN.Events
{
    public class CombatRoundEvent : NWNXEvent
    {
        public const string BEFORE_ROUND_START = "NWNX_ON_START_COMBAT_ROUND_BEFORE";
        public const string AFTER_ROUND_START   = "NWNX_ON_START_COMBAT_ROUND_AFTER";

        public delegate void EventDelegate(CombatRoundEvent e);

        public static EventDelegate BeforeCombatRoundStart = delegate {};
        public static EventDelegate AfterCombatRoundStart  = delegate {};

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public NWObject Target => GetEventObject("TARGET_OBJECT_ID").AsObject();

        public CombatRoundEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_ROUND_START)]
        [NWNEventHandler(AFTER_ROUND_START)]
        public static void EventHandler(string script)
        {
            var e = new CombatRoundEvent(script);
            switch (script)
            {
                case BEFORE_ROUND_START: BeforeCombatRoundStart(e); break;
                case AFTER_ROUND_START:  AfterCombatRoundStart(e); break;
                default: break;
            }
        }
    }
}