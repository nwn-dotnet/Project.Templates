namespace NWN.Events {
    public class TimingBarEvent : NWNXEvent {
        public delegate void EventDelegate(TimingBarEvent e);

        public const string BEFORE_TIMING_BAR_START = "NWNX_ON_TIMING_BAR_START_BEFORE";
        public const string AFTER_TIMING_BAR_START = "NWNX_ON_TIMING_BAR_START_AFTER";
        public const string BEFORE_TIMING_BAR_STOP = "NWNX_ON_TIMING_BAR_STOP_BEFORE";
        public const string AFTER_TIMING_BAR_STOP = "NWNX_ON_TIMING_BAR_STOP_AFTER";
        public const string BEFORE_TIMING_BAR_CANCEL = "NWNX_ON_TIMING_BAR_CANCEL_BEFORE";
        public const string AFTER_TIMING_BAR_CANCEL = "NWNX_ON_TIMING_BAR_CANCEL_AFTER";

        public static EventDelegate BeforeBarStart = delegate { };
        public static EventDelegate AfterBarStart = delegate { };
        public static EventDelegate BeforeBarStop = delegate { };
        public static EventDelegate AfterBarStop = delegate { };
        public static EventDelegate BeforeBarCancel = delegate { };
        public static EventDelegate AfterBarCancel = delegate { };

        public TimingBarEvent(string script) {
            EventType = script;
        }

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public int EventID => GetEventInt("EVENT_ID");
        public int Duration => GetEventInt("DURATION");

        [NWNEventHandler(BEFORE_TIMING_BAR_START)]
        [NWNEventHandler(AFTER_TIMING_BAR_START)]
        [NWNEventHandler(BEFORE_TIMING_BAR_STOP)]
        [NWNEventHandler(AFTER_TIMING_BAR_STOP)]
        [NWNEventHandler(BEFORE_TIMING_BAR_CANCEL)]
        [NWNEventHandler(AFTER_TIMING_BAR_CANCEL)]
        public static void EventHandler(string script) {
            var e = new TimingBarEvent(script);
            switch (script) {
                case BEFORE_TIMING_BAR_START:
                    BeforeBarStart(e);
                    break;
                case AFTER_TIMING_BAR_START:
                    AfterBarStart(e);
                    break;
                case BEFORE_TIMING_BAR_STOP:
                    BeforeBarStop(e);
                    break;
                case AFTER_TIMING_BAR_STOP:
                    AfterBarStop(e);
                    break;
                case BEFORE_TIMING_BAR_CANCEL:
                    BeforeBarCancel(e);
                    break;
                case AFTER_TIMING_BAR_CANCEL:
                    AfterBarCancel(e);
                    break;
            }
        }
    }
}