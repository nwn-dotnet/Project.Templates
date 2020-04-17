using System;

namespace NWN.Events {
  public class UUIDConflictEvent : NWNXEvent {
    public delegate void EventDelegate(UUIDConflictEvent e);

    public const string UUID_Collision_Before = "NWNX_ON_UUID_COLLISION_BEFORE";
    public const string UUID_Collision_After = "NWNX_ON_UUID_COLLISION_AFTER";

    public static EventDelegate CollisionBefore = delegate { };
    public static EventDelegate CollisionAfter = delegate { };

    public UUIDConflictEvent(string script) {
      EventType = script;
    }

    public uint OBJECT_SELF => Internal.OBJECT_SELF;
    public Guid Guid => Guid.Parse(GetEventString("UUID"));

    [NWNEventHandler(UUID_Collision_Before)]
    [NWNEventHandler(UUID_Collision_After)]
    public static void EventHandler(string script) {
      var e = new UUIDConflictEvent(script);
      switch (script) {
        case UUID_Collision_Before:
          CollisionBefore(e);
          break;
        case UUID_Collision_After:
          CollisionAfter(e);
          break;
      }
    }
  }
}