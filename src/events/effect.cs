namespace NWN.Events
{
    public class EffectEvent : NWNXEvent
    {
        public const string BEFORE_EFFECT_APPLIED	= "NWNX_ON_EFFECT_APPLIED_BEFORE";
        public const string AFTER_EFFECT_APPLIED	= "NWNX_ON_EFFECT_APPLIED_AFTER";
        public const string BEFORE_EFFECT_REMOVED	= "NWNX_ON_EFFECT_REMOVED_BEFORE";
        public const string AFTER_EFFECT_REMOVED	= "NWNX_ON_EFFECT_REMOVED_AFTER";
    
        public delegate void EventDelegate(EffectEvent e);
    
        public static EventDelegate BeforeEffectApplied	= delegate {};
        public static EventDelegate AfterEffectApplied	= delegate {};
        public static EventDelegate BeforeEffectRemoved	= delegate {};
        public static EventDelegate AfterEffectRemoved	= delegate {};
    
        public NWObject Target => Internal.OBJECT_SELF.AsObject();
        public int EffectID => GetEventInt("UNIQUE_ID");
        public NWObject Creator => GetEventObject("CREATOR").AsObject();
        public int EffectType => GetEventInt("TYPE");
        public int EffectSubType => GetEventInt("SUB_TYPE");
        public int DurationType => GetEventInt("DURATION_TYPE");
        public float Duration => GetEventFloat("DURATION");
        public int SpellID => GetEventInt("SPELL_ID");
        public int CasterLevel => GetEventInt("CASTER_LEVEL");
        public string CustomTag => GetEventString("CUSTOM_TAG");
        public int GetIntParam(int ndx) => GetEventInt($"INT_PARAM_{ndx}");
        public float GetFloatParam(int ndx) => GetEventFloat($"FLOAT_PARAM_{ndx}");
        public string GetStringParam(int ndx) => GetEventString($"STRING_PARAM_{ndx}");
        public NWObject GetObjectParam(int ndx) => GetEventObject($"OBJECT_PARAM_{ndx}").AsObject();
    
        public EffectEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_EFFECT_APPLIED)]
        [NWNEventHandler(AFTER_EFFECT_APPLIED)]
        [NWNEventHandler(BEFORE_EFFECT_REMOVED)]
        [NWNEventHandler(AFTER_EFFECT_REMOVED)]
        public static void EventHandler(string script)
        {
            var e = new EffectEvent(script);
            switch (script)
            {
                case BEFORE_EFFECT_APPLIED:	BeforeEffectApplied(e); break;
                case AFTER_EFFECT_APPLIED:	AfterEffectApplied(e); break;
                case BEFORE_EFFECT_REMOVED:	BeforeEffectRemoved(e); break;
                case AFTER_EFFECT_REMOVED:	AfterEffectRemoved(e); break;
            }
        }
    }
}