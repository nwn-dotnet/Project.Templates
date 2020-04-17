namespace NWN.Events {
  public class ItemSplitEvent : NWNXEvent {
    public delegate void EventDelegate(ItemSplitEvent e);

    public const string BEFORE_SPLIT = "NWNX_ON_ITEM_SPLIT_BEFORE";
    public const string AFTER_SPLIT = "NWNX_ON_ITEM_SPLIT_AFTER";

    public static EventDelegate BeforeItemSplit = delegate { };
    public static EventDelegate AfterItemSplit = delegate { };

    public ItemSplitEvent(string script) {
      EventType = script;
    }

    public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
    public NWItem Item => GetEventObject("ITEM").AsItem();
    public int Amount => GetEventInt("NUMBER_SPLIT_OFF");

    [NWNEventHandler(BEFORE_SPLIT)]
    [NWNEventHandler(AFTER_SPLIT)]
    public static void EventHandler(string script) {
      var e = new ItemSplitEvent(script);
      switch (script) {
        case BEFORE_SPLIT:
          BeforeItemSplit(e);
          break;
        case AFTER_SPLIT:
          AfterItemSplit(e);
          break;
      }
    }
  }
}