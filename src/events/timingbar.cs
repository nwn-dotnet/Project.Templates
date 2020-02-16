namespace NWN.Events
{
public class TimingBarEvent : NWNXEvent
{
    public const string BEFORE_TIMING_BAR_START	= "NWNX_ON_TIMING_BAR_START_BEFORE";
    public const string AFTER_TIMING_BAR_START	= "NWNX_ON_TIMING_BAR_START_AFTER";

    public delegate void EventDelegate(TimingBarEvent e);

    public static EventDelegate BeforeBarStart	= delegate {};
    public static EventDelegate AfterBarStart	= delegate {};

    public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
    public int EventID => GetEventInt("EVENT_ID");
    public int Duration => GetEventInt("DURATION");

    public TimingBarEvent(string script) { EventType = script; }

    [NWNEventHandler(BEFORE_TIMING_BAR_START)]
    [NWNEventHandler(AFTER_TIMING_BAR_START)]
    public static void EventHandler(string script)
    {
        var e = new TimingBarEvent(script);
        switch (script)
        {
            case BEFORE_TIMING_BAR_START:	BeforeBarStart(e); break;
            case AFTER_TIMING_BAR_START:	AfterBarStart(e); break;
        }
    }
}
}