namespace NWN.Events {
    public class ELCValidateCharacterEvent : NWNXEvent {
        public delegate void EventDelegate(ELCValidateCharacterEvent e);

        //NWNX_ELC must be loaded for these events to work. The `_AFTER` event only fires if the character successfully completes validation.
        public const string ELC_VALIDATE_CHARACTER_BEFORE = "NWNX_ON_ELC_VALIDATE_CHARACTER_BEFORE";
        public const string ELC_VALIDATE_CHARACTER_AFTER = "NWNX_ON_ELC_VALIDATE_CHARACTER_AFTER";

        public static EventDelegate BeforeValidateCharacter = delegate { };
        public static EventDelegate AfterValidateCharacter = delegate { };

        public ELCValidateCharacterEvent(string script) {
            EventType = script;
        }

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();

        [NWNEventHandler(ELC_VALIDATE_CHARACTER_BEFORE)]
        [NWNEventHandler(ELC_VALIDATE_CHARACTER_AFTER)]
        public static void EventHandler(string script) {
            var e = new ELCValidateCharacterEvent(script);
            switch (script) {
                case ELC_VALIDATE_CHARACTER_BEFORE:
                    BeforeValidateCharacter(e);
                    break;
                case ELC_VALIDATE_CHARACTER_AFTER:
                    AfterValidateCharacter(e);
                    break;
            }
        }
    }
}