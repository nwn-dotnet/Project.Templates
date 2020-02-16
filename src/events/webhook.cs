namespace NWN.Events
{
public class WebHookEvent : NWNXEvent
{
    public const string SUCCESS	= "NWNX_ON_WEBHOOK_SUCCESS";
    public const string FAILURE	= "NWNX_ON_WEBHOOK_FAILURE";

    public delegate void EventDelegate(WebHookEvent e);

    public static EventDelegate OnWebHookSuccess	= delegate {};
    public static EventDelegate OnWebHookFailure	= delegate {};

    public WebHookEvent(string script) { EventType = script; }

    [NWNEventHandler(SUCCESS)]
    [NWNEventHandler(FAILURE)]
    public static void EventHandler(string script)
    {
        var e = new WebHookEvent(script);
        switch (script)
        {
            case SUCCESS:	OnWebHookSuccess(e); break;
            case FAILURE:	OnWebHookFailure(e); break;
        }
    }
}    
}