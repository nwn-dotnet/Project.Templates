namespace NWN.Events
{
    public class SpellSlotEvent : NWNXEvent
    {
        public const string BEFORE_SET      = "NWNX_SET_MEMORIZED_SPELL_SLOT_BEFORE";
        public const string AFTER_SET       = "NWNX_SET_MEMORIZED_SPELL_SLOT_AFTER";
        public const string BEFORE_CLEAR      = "NWNX_CLEAR_MEMORIZED_SPELL_SLOT_BEFORE";
        public const string AFTER_CLEAR       = "NWNX_CLEAR_MEMORIZED_SPELL_SLOT_AFTER";

        public delegate void EventDelegate(SpellSlotEvent e);

        public static EventDelegate BeforeSetSpellSlot          = delegate {};
        public static EventDelegate AfterSetSpellSlot           = delegate {};
        public static EventDelegate BeforeClearSpellSlot        = delegate {};
        public static EventDelegate AfterClearSpellSlot         = delegate {};

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public int SpellMulticlass => GetEventInt("SPELL_MULTICLASS");
        public int SpellLevel => GetEventInt("SPELL_LEVEL");
        public int SpellSlot => GetEventInt("SPELL_SLOT");

        // Only in SET* events
        public int SpellID => GetEventInt("SPELL_ID");
        public int SpellDomain => GetEventInt("SPELL_DOMAIN");
        public int SpellMetamagic => GetEventInt("SPELL_METAMAGIC");
        public int SpellFromClient => GetEventInt("SPELL_FROM_CLIENT"); // ?
        public int ActionResult 
        { 
            get => GetEventInt("ACTION_RESULT"); 
            set => SetEventResult(value.ToString()); 
        }

        public SpellSlotEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_SET)]
        [NWNEventHandler(AFTER_SET)]
        [NWNEventHandler(BEFORE_CLEAR)]
        [NWNEventHandler(AFTER_CLEAR)]
        public static void EventHandler(string script)
        {
            var e = new SpellSlotEvent(script);
            switch (script)
            {
                case BEFORE_SET:    BeforeSetSpellSlot(e); break;
                case AFTER_SET:     AfterSetSpellSlot(e); break;
                case BEFORE_CLEAR:  BeforeClearSpellSlot(e); break;
                case AFTER_CLEAR:   AfterClearSpellSlot(e); break;
                default: break;
            }
        }
    }
}