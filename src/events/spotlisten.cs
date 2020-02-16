namespace NWN.Events
{
public class DetectionEvent : NWNXEvent
{
    public const string BEFORE_DO_LISTEN_DETECTION	= "NWNX_ON_DO_LISTEN_DETECTION_BEFORE";
    public const string AFTER_DO_LISTEN_DETECTION	= "NWNX_ON_DO_LISTEN_DETECTION_AFTER";
    public const string BEFORE_DO_SPOT_DETECTION	= "NWNX_ON_DO_SPOT_DETECTION_BEFORE";
    public const string AFTER_DO_SPOT_DETECTION	    = "NWNX_ON_DO_SPOT_DETECTION_AFTER";

    public delegate void EventDelegate(DetectionEvent e);

    public static EventDelegate BeforeListen	= delegate {};
    public static EventDelegate AfterListen	    = delegate {};
    public static EventDelegate BeforeSpot	= delegate {};
    public static EventDelegate AfterSpot	    = delegate {};

    public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
    public NWCreature Target => GetEventObject("TARGET").AsCreature();
    public bool TargetInvisible => GetEventInt("TARGET_INVISIBLE") == 1;
    public bool DetectionResult => GetEventInt("BEFORE_RESULT") == 1;  // AFTER only.

    public DetectionEvent(string script) { EventType = script; }

    [NWNEventHandler(BEFORE_DO_LISTEN_DETECTION)]
    [NWNEventHandler(AFTER_DO_LISTEN_DETECTION)]
    [NWNEventHandler(BEFORE_DO_SPOT_DETECTION)]
    [NWNEventHandler(AFTER_DO_SPOT_DETECTION)]
    public static void EventHandler(string script)
    {
        var e = new DetectionEvent(script);
        switch (script)
        {
            case BEFORE_DO_LISTEN_DETECTION:	BeforeListen(e); break;
            case AFTER_DO_LISTEN_DETECTION:	    AfterListen(e); break;
            case BEFORE_DO_SPOT_DETECTION:	    BeforeSpot(e); break;
            case AFTER_DO_SPOT_DETECTION:	    AfterSpot(e); break;
        }
    }
}
}