namespace NWN.Events {
    public class CalendarEvent : NWNXEvent {
        public delegate void EventDelegate(CalendarEvent e);

        public const string CALENDAR_DAWN = "NWNX_ON_CALENDAR_DAWN";
        public const string CALENDAR_DAY = "NWNX_ON_CALENDAR_DAY";
        public const string CALENDAR_DUSK = "NWNX_ON_CALENDAR_DUSK";
        public const string CALENDAR_HOUR = "NWNX_ON_CALENDAR_HOUR";
        public const string CALENDAR_MONTH = "NWNX_ON_CALENDAR_MONTH";
        public const string CALENDAR_YEAR = "NWNX_ON_CALENDAR_YEAR";

        public static EventDelegate CalendarDawnEvent = delegate { };
        public static EventDelegate CalendarDayEvent = delegate { };
        public static EventDelegate CalendarDuskEvent = delegate { };
        public static EventDelegate CalendarHourEvent = delegate { };
        public static EventDelegate CalendarMonthEvent = delegate { };
        public static EventDelegate CalendarYearEvent = delegate { };

        public CalendarEvent(string script) {
            EventType = script;
        }

        public NWObject Module => Internal.OBJECT_SELF.AsObject();
        public int PreviousValue => GetEventInt("OLD");
        public int NewValue => GetEventInt("NEW");

        [NWNEventHandler(CALENDAR_DAWN)]
        [NWNEventHandler(CALENDAR_DAY)]
        [NWNEventHandler(CALENDAR_DUSK)]
        [NWNEventHandler(CALENDAR_HOUR)]
        [NWNEventHandler(CALENDAR_MONTH)]
        [NWNEventHandler(CALENDAR_YEAR)]
        public static void EventHandler(string script) {
            var e = new CalendarEvent(script);
            switch (script) {
                case CALENDAR_DAWN:
                    CalendarDawnEvent(e);
                    break;
                case CALENDAR_DAY:
                    CalendarDayEvent(e);
                    break;
                case CALENDAR_DUSK:
                    CalendarDuskEvent(e);
                    break;
                case CALENDAR_HOUR:
                    CalendarHourEvent(e);
                    break;
                case CALENDAR_MONTH:
                    CalendarMonthEvent(e);
                    break;
                case CALENDAR_YEAR:
                    CalendarYearEvent(e);
                    break;
            }
        }
    }
}