namespace NWN.Events {
  public class LoreEvent : NWNXEvent {
    public delegate void EventDelegate(LoreEvent e);

    public const string BEFORE_USE_LORE = "NWNX_ON_ITEM_USE_LORE_BEFORE";
    public const string AFTER_USE_LORE = "NWNX_ON_ITEM_USE_LORE_AFTER";
    public const string BEFORE_PAY_TO_ID = "NWNX_ON_ITEM_PAY_TO_IDENTIFY_BEFORE";
    public const string AFTER_PAY_TO_ID = "NWNX_ON_ITEM_PAY_TO_IDENTIFY_AFTER";

    public static EventDelegate BeforeUseLore = delegate { };
    public static EventDelegate AfterUseLore = delegate { };
    public static EventDelegate BeforePayToIdentify = delegate { };
    public static EventDelegate AfterPayToIdentify = delegate { };

    public LoreEvent(string script) {
      EventType = script;
    }

    public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
    public NWItem Item => GetEventObject("ITEM").AsItem();
    public NWObject Store => GetEventObject("STORE").AsObject();

    [NWNEventHandler(BEFORE_USE_LORE)]
    [NWNEventHandler(AFTER_USE_LORE)]
    [NWNEventHandler(BEFORE_PAY_TO_ID)]
    [NWNEventHandler(AFTER_PAY_TO_ID)]
    public static void EventHandler(string script) {
      var e = new LoreEvent(script);
      switch (script) {
        case BEFORE_USE_LORE:
          BeforeUseLore(e);
          break;
        case AFTER_USE_LORE:
          AfterUseLore(e);
          break;
        case BEFORE_PAY_TO_ID:
          BeforePayToIdentify(e);
          break;
        case AFTER_PAY_TO_ID:
          AfterPayToIdentify(e);
          break;
      }
    }
  }
}