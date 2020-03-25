namespace NWN.Events {
	public class ContainerEvent : NWNXEvent {
		public delegate void EventDelegate(ContainerEvent e);

		public const string BEFORE_OPEN = "NWNX_ON_ITEM_INVENTORY_OPEN_BEFORE";
		public const string AFTER_OPEN = "NWNX_ON_ITEM_INVENTORY_OPEN_AFTER";
		public const string BEFORE_CLOSE = "NWNX_ON_ITEM_INVENTORY_CLOSE_BEFORE";
		public const string AFTER_CLOSE = "NWNX_ON_ITEM_INVENTORY_CLOSE_AFTER";

		public static EventDelegate BeforeOpenItemInventory = delegate { };
		public static EventDelegate AfterOpenItemInventory = delegate { };
		public static EventDelegate BeforeCloseItemInventory = delegate { };
		public static EventDelegate AfterCloseItemInventory = delegate { };

		public ContainerEvent(string script) {
			EventType = script;
		}

		public NWItem Container => Internal.OBJECT_SELF.AsItem();
		public NWCreature Owner => GetEventObject("OWNER").AsCreature();

		[NWNEventHandler(BEFORE_OPEN)]
		[NWNEventHandler(AFTER_OPEN)]
		[NWNEventHandler(BEFORE_CLOSE)]
		[NWNEventHandler(AFTER_CLOSE)]
		public static void EventHandler(string script) {
			var e = new ContainerEvent(script);
			switch (script) {
				case BEFORE_OPEN:
					BeforeOpenItemInventory(e);
					break;
				case AFTER_OPEN:
					AfterOpenItemInventory(e);
					break;
				case BEFORE_CLOSE:
					BeforeCloseItemInventory(e);
					break;
				case AFTER_CLOSE:
					AfterCloseItemInventory(e);
					break;
			}
		}
	}
}