namespace NWN.Events
{
    public class CombatModeEvent : NWNXEvent
    {
        public enum CombatMode
        {
            NONE = 0,
            PARRY,
            POWER_ATTACK,
            IMPROVED_POWER_ATTACK,
            COUNTERSPELL,
            FLURRY_OF_BLOWS,
            RAPID_SHOT,      
            EXPERTISE,
            IMPROVED_EXPERTISE,
            DEFENSIVE_CASTING,
            DIRTY_FIGHTING,
            DEFENSIVE_STANCE
        }

        public const string COMBAT_MODE_ON  = "NWNX_ON_COMBAT_MODE_ON";
        public const string COMBAT_MODE_OFF = "NWNX_ON_COMBAT_MODE_OFF";

        public delegate void EventDelegate(CombatModeEvent e);

        public static EventDelegate OnCombatModeOn  = delegate {};
        public static EventDelegate OnCombatModeOff = delegate {};

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public CombatMode Mode => (CombatMode)GetEventInt("COMBAT_MODE_ID");

        public CombatModeEvent(string script) { EventType = script; }

        [NWNEventHandler(COMBAT_MODE_ON)]
        [NWNEventHandler(COMBAT_MODE_OFF)]
        public static void EventHandler(string script)
        {
            var e = new CombatModeEvent(script);
            switch (script)
            {
                case COMBAT_MODE_ON:  OnCombatModeOn(e); break;
                case COMBAT_MODE_OFF: OnCombatModeOff(e); break;
                default: break;
            }
        }
    }
}