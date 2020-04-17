namespace NWN.Events {
  public class AssociateEvent : NWNXEvent {
    public delegate void EventDelegate(AssociateEvent e);

    public const string BEFORE_ADD = "NWNX_ON_ADD_ASSOCIATE_BEFORE";
    public const string AFTER_ADD = "NWNX_ON_ADD_ASSOCIATE_AFTER";
    public const string BEFORE_REMOVE = "NWNX_ON_REMOVE_ASSOCIATE_BEFORE";
    public const string AFTER_REMOVE = "NWNX_ON_REMOVE_ASSOCIATE_AFTER";

    public static EventDelegate BeforeAddAssociate = delegate { };
    public static EventDelegate AfterAddAssociate = delegate { };
    public static EventDelegate BeforeRemoveAssociate = delegate { };
    public static EventDelegate AfterRemoveAssociate = delegate { };

    public AssociateEvent(string script) {
      EventType = script;
    }

    public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
    public NWCreature Associate => GetEventObject("ASSOCIATE_OBJECT_ID").AsCreature();

    [NWNEventHandler(BEFORE_ADD)]
    [NWNEventHandler(AFTER_ADD)]
    [NWNEventHandler(BEFORE_REMOVE)]
    [NWNEventHandler(AFTER_REMOVE)]
    public static void EventHandler(string script) {
      var e = new AssociateEvent(script);
      switch (script) {
        case BEFORE_ADD:
          BeforeAddAssociate(e);
          break;
        case AFTER_ADD:
          AfterAddAssociate(e);
          break;
        case BEFORE_REMOVE:
          BeforeRemoveAssociate(e);
          break;
        case AFTER_REMOVE:
          AfterRemoveAssociate(e);
          break;
      }
    }
  }
}