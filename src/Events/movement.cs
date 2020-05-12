namespace NWN.Events {
    public class WalkInputEvent : NWNXEvent {
        public delegate void EventDelegate(WalkInputEvent e);

        public const string BEFORE_INPUT_WALK_TO_WAYPOINT = "NWNX_ON_INPUT_WALK_TO_WAYPOINT_BEFORE";
        public const string AFTER_INPUT_WALK_TO_WAYPOINT = "NWNX_ON_INPUT_WALK_TO_WAYPOINT_AFTER";

        public static EventDelegate BeforeInputWaypoint = delegate { };
        public static EventDelegate AfterInputWaypoint = delegate { };

        public WalkInputEvent(string script) {
            EventType = script;
        }

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public NWArea Area => GetEventObject("AREA").AsArea();
        public Vector Location => GetEventVector("POS");
        public bool Running => GetEventInt("RUN_TO_POINT") == 1;

        [NWNEventHandler(BEFORE_INPUT_WALK_TO_WAYPOINT)]
        [NWNEventHandler(AFTER_INPUT_WALK_TO_WAYPOINT)]
        public static void EventHandler(string script) {
            var e = new WalkInputEvent(script);
            switch (script) {
                case BEFORE_INPUT_WALK_TO_WAYPOINT:
                    BeforeInputWaypoint(e);
                    break;
                case AFTER_INPUT_WALK_TO_WAYPOINT:
                    AfterInputWaypoint(e);
                    break;
            }
        }
    }

    public class ForceMoveEvent : NWNXEvent {
        public delegate void EventDelegate(ForceMoveEvent e);

        public const string BEFORE_INPUT_FORCE_MOVE_TO_OBJECT = "NWNX_ON_INPUT_FORCE_MOVE_TO_OBJECT_BEFORE";
        public const string AFTER_INPUT_FORCE_MOVE_TO_OBJECT = "NWNX_ON_INPUT_FORCE_MOVE_TO_OBJECT_AFTER";

        public static EventDelegate BeforeForceMove = delegate { };
        public static EventDelegate AfterForceMove = delegate { };

        public ForceMoveEvent(string script) {
            EventType = script;
        }

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public NWObject Target => GetEventObject("TARGET").AsObject();

        [NWNEventHandler(BEFORE_INPUT_FORCE_MOVE_TO_OBJECT)]
        [NWNEventHandler(AFTER_INPUT_FORCE_MOVE_TO_OBJECT)]
        public static void EventHandler(string script) {
            var e = new ForceMoveEvent(script);
            switch (script) {
                case BEFORE_INPUT_FORCE_MOVE_TO_OBJECT:
                    BeforeForceMove(e);
                    break;
                case AFTER_INPUT_FORCE_MOVE_TO_OBJECT:
                    AfterForceMove(e);
                    break;
            }
        }
    }

    public class MaterialChangeEvent : NWNXEvent {
        public delegate void EventDelegate(MaterialChangeEvent e);

        public const string BEFORE_MATERIALCHANGE = "NWNX_ON_MATERIALCHANGE_BEFORE";
        public const string AFTER_MATERIALCHANGE = "NWNX_ON_MATERIALCHANGE_AFTER";

        public static EventDelegate BeforeMaterialChange = delegate { };
        public static EventDelegate AfterMaterialChange = delegate { };

        public MaterialChangeEvent(string script) {
            EventType = script;
        }

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public int MaterialType => GetEventInt("MATERIAL_TYPE");

        [NWNEventHandler(BEFORE_MATERIALCHANGE)]
        [NWNEventHandler(AFTER_MATERIALCHANGE)]
        public static void EventHandler(string script) {
            var e = new MaterialChangeEvent(script);
            switch (script) {
                case BEFORE_MATERIALCHANGE:
                    BeforeMaterialChange(e);
                    break;
                case AFTER_MATERIALCHANGE:
                    AfterMaterialChange(e);
                    break;
            }
        }
    }
}