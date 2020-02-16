namespace NWN.Events
{
    public class ExamineEvent : NWNXEvent
    {
        public const string BEFORE_EXAMINE = "NWNX_ON_EXAMINE_OBJECT_BEFORE";
        public const string AFTER_EXAMINE  = "NWNX_ON_EXAMINE_OBJECT_AFTER";

        public delegate void EventDelegate(ExamineEvent e);

        public static EventDelegate BeforeExamineObject = delegate {};
        public static EventDelegate AfterExamineObject  = delegate {};

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public NWObject ExaminedObject => GetEventObject("EXAMINEE_OBJECT_ID").AsObject();
        public bool GetTrapSuccess() => GetEventInt("TRAP_EXAMINE_SUCCESS") == 1;

        public ExamineEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_EXAMINE)]
        [NWNEventHandler(AFTER_EXAMINE)]
        public static void EventHandler(string script)
        {
            var e = new ExamineEvent(script);
            switch (script)
            {
                case BEFORE_EXAMINE:    BeforeExamineObject(e); break;
                case AFTER_EXAMINE:     AfterExamineObject(e); break;
                default: break;
            }
        }
    }
}