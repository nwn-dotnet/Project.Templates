namespace NWN.Events {
	public class QuickChatEvent : NWNXEvent {
		public delegate void EventDelegate(QuickChatEvent e);

		public const string BEFORE_QUICKCHAT = "NWNX_ON_QUICKCHAT_BEFORE";
		public const string AFTER_QUICKCHAT = "NWNX_ON_QUICKCHAT_AFTER";

		public static EventDelegate BeforeQuickChat = delegate { };
		public static EventDelegate AfterQuickChat = delegate { };

		public QuickChatEvent(string script) {
			EventType = script;
		}

		public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
		public int Command => GetEventInt("QUICKCHAT_COMMAND");

		[NWNEventHandler(BEFORE_QUICKCHAT)]
		[NWNEventHandler(AFTER_QUICKCHAT)]
		public static void EventHandler(string script) {
			var e = new QuickChatEvent(script);
			switch (script) {
				case BEFORE_QUICKCHAT:
					BeforeQuickChat(e);
					break;
				case AFTER_QUICKCHAT:
					AfterQuickChat(e);
					break;
			}
		}
	}
}