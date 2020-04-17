namespace NWN.Events {
  public class LockEvent : NWNXEvent {
    public delegate void EventDelegate(LockEvent e);

    public const string OBJECT_LOCK_BEFORE = "NWNX_ON_OBJECT_LOCK_BEFORE";
    public const string OBJECT_LOCK_AFTER = "NWNX_ON_OBJECT_LOCK_AFTER";

    public static EventDelegate LockBefore = delegate { };
    public static EventDelegate LockAfter = delegate { };

    public LockEvent(string script) {
      EventType = script;
    }

    public uint Locker => Internal.OBJECT_SELF;
    public uint Door => NWNX.Object.StringToObject(GetEventString("DOOR"));

    [NWNEventHandler(OBJECT_LOCK_BEFORE)]
    [NWNEventHandler(OBJECT_LOCK_AFTER)]
    public static void EventHandler(string script) {
      var e = new LockEvent(script);
      switch (script) {
        case OBJECT_LOCK_BEFORE:
          LockBefore(e);
          break;
        case OBJECT_LOCK_AFTER:
          LockAfter(e);
          break;
      }
    }
  }

  public class UnlockEvent : NWNXEvent {
    public delegate void EventDelegate(UnlockEvent e);

    public const string OBJECT_UNLOCK_BEFORE = "NWNX_ON_OBJECT_UNLOCK_BEFORE";
    public const string OBJECT_UNLOCK_AFTER = "NWNX_ON_OBJECT_UNLOCK_AFTER";

    public static EventDelegate UnlockBefore = delegate { };
    public static EventDelegate UnlockAfter = delegate { };

    public UnlockEvent(string script) {
      EventType = script;
    }

    public uint Unlocker => Internal.OBJECT_SELF;
    public uint Door => NWNX.Object.StringToObject(GetEventString("DOOR"));
    public uint ThievesTool => NWNX.Object.StringToObject(GetEventString("THIEVES_TOOL"));
    public int ActivePropertyIndex => GetEventInt("ACTIVE_PROPERTY_INDEX");

    [NWNEventHandler(OBJECT_UNLOCK_BEFORE)]
    [NWNEventHandler(OBJECT_UNLOCK_AFTER)]
    public static void EventHandler(string script) {
      var e = new UnlockEvent(script);
      switch (script) {
        case OBJECT_UNLOCK_BEFORE:
          UnlockBefore(e);
          break;
        case OBJECT_UNLOCK_AFTER:
          UnlockAfter(e);
          break;
      }
    }
  }
}