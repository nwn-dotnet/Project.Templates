namespace NWN.Events
{
    public class QuickChatEvent : NWNXEvent
    {
        public const string BEFORE_QUICKCHAT	= "NWNX_ON_QUICKCHAT_BEFORE";
        public const string AFTER_QUICKCHAT	    = "NWNX_ON_QUICKCHAT_AFTER";
    
        public delegate void EventDelegate(QuickChatEvent e);
    
        public static EventDelegate BeforeQuickChat	= delegate {};
        public static EventDelegate AfterQuickChat	= delegate {};
    
        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public int Command => GetEventInt("QUICKCHAT_COMMAND");
    
        public QuickChatEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_QUICKCHAT)]
        [NWNEventHandler(AFTER_QUICKCHAT)]
        public static void EventHandler(string script)
        {
            var e = new QuickChatEvent(script);
            switch (script)
            {
                case BEFORE_QUICKCHAT:	BeforeQuickChat(e); break;
                case AFTER_QUICKCHAT:	AfterQuickChat(e); break;
            }
        }
    }
}