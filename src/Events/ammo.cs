namespace NWN.Events {
  public class AmmoEvent : NWNXEvent {
    public delegate void EventDelegate(AmmoEvent e);

    public const string BEFORE_RELOAD = "NWNX_ON_ITEM_AMMO_RELOAD_BEFORE";
    public const string AFTER_RELOAD = "NWNX_ON_ITEM_AMMO_RELOAD_AFTER";

    public static EventDelegate BeforeReloadAmmo = delegate { };
    public static EventDelegate AfterReloadAmmo = delegate { };

    public AmmoEvent(string script) {
      EventType = script;
    }

    public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
    public int BaseItemID => GetEventInt("BASE_ITEM_ID");
    public int BaseItemNth => GetEventInt("BASE_ITEM_NTH");

    public int GetResult() {
      return GetEventInt("ACTION_RESULT");
    }

    public void SetResult(int nth) {
      NWNX.Events.SetEventResult(nth.ToString());
    }

    [NWNEventHandler(BEFORE_RELOAD)]
    [NWNEventHandler(AFTER_RELOAD)]
    public static void EventHandler(string script) {
      var e = new AmmoEvent(script);
      switch (script) {
        case BEFORE_RELOAD:
          BeforeReloadAmmo(e);
          break;
        case AFTER_RELOAD:
          AfterReloadAmmo(e);
          break;
      }
    }
  }
}