namespace NWN.Events {
    public class InputAttackEvent : NWNXEvent {
        public delegate void EventDelegate(InputAttackEvent e);

        public const string INPUT_ATTACK_OBJECT_BEFORE = "INPUT_ATTACK_OBJECT_BEFORE";
        public const string INPUT_ATTACK_OBJECT_AFTER = "INPUT_ATTACK_OBJECT_AFTER";

        public static EventDelegate BeforeAttackObject = delegate { };
        public static EventDelegate AfterAttackObject = delegate { };

        public InputAttackEvent(string script) {
            EventType = script;
        }

        public NWCreature AttackingCreature => Internal.OBJECT_SELF.AsCreature();
        public NWObject Target => GetEventObject("TARGET").AsObject();
        public bool Passive => GetEventInt("PASSIVE") == 1;
        public bool ClearAllActions => GetEventInt("CLEAR_ALL_ACTIONS") == 1;
        public bool AddToFront => GetEventInt("ADD_TO_FRONT") == 1;

        [NWNEventHandler(INPUT_ATTACK_OBJECT_BEFORE)]
        [NWNEventHandler(INPUT_ATTACK_OBJECT_AFTER)]
        public static void EventHandler(string script) {
            var e = new InputAttackEvent(script);
            switch (script) {
                case INPUT_ATTACK_OBJECT_BEFORE:
                    BeforeAttackObject(e);
                    break;
                case INPUT_ATTACK_OBJECT_AFTER:
                    AfterAttackObject(e);
                    break;
            }
        }
    }
    public class InputForceMoveToEvent : NWNXEvent {
        public delegate void EventDelegate(InputForceMoveToEvent e);

        public const string INPUT_FORCE_MOVE_TO_OBJECT_BEFORE = "NWNX_ON_INPUT_FORCE_MOVE_TO_OBJECT_BEFORE";
        public const string INPUT_FORCE_MOVE_TO_OBJECT_AFTER = "NWNX_ON_INPUT_FORCE_MOVE_TO_OBJECT_AFTER";

        public static EventDelegate BeforeInputForceMoveTo = delegate { };
        public static EventDelegate AfterInputForceMoveTo = delegate { };

        public InputForceMoveToEvent(string script) {
            EventType = script;
        }

        public NWCreature MovingCreature => Internal.OBJECT_SELF.AsCreature();
        public NWObject Target => GetEventObject("TARGET").AsObject();

        [NWNEventHandler(INPUT_FORCE_MOVE_TO_OBJECT_BEFORE)]
        [NWNEventHandler(INPUT_FORCE_MOVE_TO_OBJECT_AFTER)]
        public static void EventHandler(string script) {
            var e = new InputForceMoveToEvent(script);
            switch (script) {
                case INPUT_FORCE_MOVE_TO_OBJECT_BEFORE:
                    BeforeInputForceMoveTo(e);
                    break;
                case INPUT_FORCE_MOVE_TO_OBJECT_AFTER:
                    AfterInputForceMoveTo(e);
                    break;
            }
        }
    }
    public class InputCastSpellEvent : NWNXEvent {
        public delegate void EventDelegate(InputCastSpellEvent e);

        public const string NWNX_ON_INPUT_CAST_SPELL_BEFORE = "NWNX_ON_INPUT_CAST_SPELL_BEFORE";
        public const string NWNX_ON_INPUT_CAST_SPELL_AFTER = "NWNX_ON_INPUT_CAST_SPELL_AFTER";

        public static EventDelegate BeforeInputCastSpell = delegate { };
        public static EventDelegate AfterInputCastSpell = delegate { };

        public InputCastSpellEvent(string script) {
            EventType = script;
        }

        public NWCreature Caster => Internal.OBJECT_SELF.AsCreature();
        public NWObject Target => GetEventObject("TARGET").AsObject();
        public int SpellID => GetEventInt("SPELL_ID");
        public int Multiclass => GetEventInt("MULTICLASS");
        public int DomainLevel => GetEventInt("DOMAIN_LEVEL");
        public Enums.MetaMagic MetaType => (Enums.MetaMagic)GetEventInt("META_TYPE");
        public bool IsInstant => GetEventInt("INSTANT") == 1;
        public int ProjectilePath => GetEventInt("PROJECTILE_PATH");
        public bool IsSpontaneous => GetEventInt("SPONTANEOUS") == 1;
        public bool IsFake => GetEventInt("FAKE") == 1;
        public int Feat => GetEventInt("FEAT");
        public int CasterLevel => GetEventInt("CASTER_LEVEL");
        public bool IsAreaTarget => GetEventInt("IS_AREA_TARGET") == 1;
        public Vector Pos => GetEventVector("POS");


        [NWNEventHandler(NWNX_ON_INPUT_CAST_SPELL_BEFORE)]
        [NWNEventHandler(NWNX_ON_INPUT_CAST_SPELL_AFTER)]
        public static void EventHandler(string script) {
            var e = new InputCastSpellEvent(script);
            switch (script) {
                case NWNX_ON_INPUT_CAST_SPELL_BEFORE:
                    BeforeInputCastSpell(e);
                    break;
                case NWNX_ON_INPUT_CAST_SPELL_AFTER:
                    AfterInputCastSpell(e);
                    break;
            }
        }
    }
    public class InputKeyboardEvent : NWNXEvent {
        public delegate void EventDelegate(InputKeyboardEvent e);

        public const string INPUT_KEYBOARD_BEFORE = "NWNX_ON_INPUT_KEYBOARD_BEFORE";
        public const string INPUT_KEYBOARD_AFTER = "NWNX_ON_INPUT_KEYBOARD_AFTER";

        public static EventDelegate BeforeKeyboardInput = delegate { };
        public static EventDelegate AfterKeyboardInput = delegate { };

        public InputKeyboardEvent(string script) {
            EventType = script;
        }

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public string Key => GetEventString("KEY");

        [NWNEventHandler(INPUT_KEYBOARD_BEFORE)]
        [NWNEventHandler(INPUT_KEYBOARD_AFTER)]
        public static void EventHandler(string script) {
            var e = new InputKeyboardEvent(script);
            switch (script) {
                case INPUT_KEYBOARD_BEFORE:
                    BeforeKeyboardInput(e);
                    break;
                case INPUT_KEYBOARD_AFTER:
                    AfterKeyboardInput(e);
                    break;
            }
        }
    }
}