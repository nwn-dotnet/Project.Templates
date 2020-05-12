using System.Collections.Generic;

namespace NWN.Events {
    public class DMGiveEvent : NWNXEvent {
        public delegate void EventDelegate(DMGiveEvent e);

        public const string BEFORE_GIVE_GOLD = "NWNX_ON_DM_GIVE_GOLD_BEFORE";
        public const string AFTER_GIVE_GOLD = "NWNX_ON_DM_GIVE_GOLD_AFTER";
        public const string BEFORE_GIVE_XP = "NWNX_ON_DM_GIVE_XP_BEFORE";
        public const string AFTER_GIVE_XP = "NWNX_ON_DM_GIVE_XP_AFTER";
        public const string BEFORE_GIVE_LEVEL = "NWNX_ON_DM_GIVE_LEVEL_BEFORE";
        public const string AFTER_GIVE_LEVEL = "NWNX_ON_DM_GIVE_LEVEL_AFTER";
        public const string BEFORE_GIVE_ALIGNMENT = "NWNX_ON_DM_GIVE_ALIGNMENT_BEFORE";
        public const string AFTER_GIVE_ALIGNMENT = "NWNX_ON_DM_GIVE_ALIGNMENT_AFTER";

        public static EventDelegate BeforeGiveGold = delegate { };
        public static EventDelegate AfterGiveGold = delegate { };
        public static EventDelegate BeforeGiveXP = delegate { };
        public static EventDelegate AfterGiveXP = delegate { };
        public static EventDelegate BeforeGiveLevel = delegate { };
        public static EventDelegate AfterGiveLevel = delegate { };
        public static EventDelegate BeforeGiveAlignment = delegate { };
        public static EventDelegate AfterGiveAlignment = delegate { };

        public DMGiveEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();
        public int Amount => GetEventInt("AMOUNT");
        public NWObject Target => GetEventObject("OBJECT").AsObject();

        //Only valid for NWNX_ON_DM_GIVE_ALIGNMENT_*
        public int AlignmentType => GetEventInt("ALIGNMENT_TYPE");

        [NWNEventHandler(BEFORE_GIVE_GOLD)]
        [NWNEventHandler(AFTER_GIVE_GOLD)]
        [NWNEventHandler(BEFORE_GIVE_XP)]
        [NWNEventHandler(AFTER_GIVE_XP)]
        [NWNEventHandler(BEFORE_GIVE_LEVEL)]
        [NWNEventHandler(AFTER_GIVE_LEVEL)]
        [NWNEventHandler(BEFORE_GIVE_ALIGNMENT)]
        [NWNEventHandler(AFTER_GIVE_ALIGNMENT)]
        public static void EventHandler(string script) {
            var e = new DMGiveEvent(script);
            switch (script) {
                case BEFORE_GIVE_GOLD:
                    BeforeGiveGold(e);
                    break;
                case AFTER_GIVE_GOLD:
                    AfterGiveGold(e);
                    break;
                case BEFORE_GIVE_XP:
                    BeforeGiveXP(e);
                    break;
                case AFTER_GIVE_XP:
                    AfterGiveXP(e);
                    break;
                case BEFORE_GIVE_LEVEL:
                    BeforeGiveLevel(e);
                    break;
                case AFTER_GIVE_LEVEL:
                    AfterGiveLevel(e);
                    break;
                case BEFORE_GIVE_ALIGNMENT:
                    BeforeGiveAlignment(e);
                    break;
                case AFTER_GIVE_ALIGNMENT:
                    AfterGiveAlignment(e);
                    break;
            }
        }
    }

    public class DMSpawnObjectEvent : NWNXEvent {
        public delegate void EventDelegate(DMSpawnObjectEvent e);

        public const string BEFORE_SPAWN_OBJECT = "NWNX_ON_DM_SPAWN_OBJECT_BEFORE";
        public const string AFTER_SPAWN_OBJECT = "NWNX_ON_DM_SPAWN_OBJECT_AFTER";

        public static EventDelegate BeforeSpawnObject = delegate { };
        public static EventDelegate AfterSpawnObject = delegate { };

        public DMSpawnObjectEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();
        public NWArea area = GetEventObject("AREA").AsArea();
        public NWObject Target => GetEventObject("OBJECT").AsObject();
        public Enums.ObjectTypeEngine ObjectType => (Enums.ObjectTypeEngine) GetEventInt("OBJECT_TYPE");
        public Vector Pos => GetEventVector("POS");


        [NWNEventHandler(BEFORE_SPAWN_OBJECT)]
        [NWNEventHandler(AFTER_SPAWN_OBJECT)]
        public static void EventHandler(string script) {
            var e = new DMSpawnObjectEvent(script);
            switch (script) {
                case BEFORE_SPAWN_OBJECT:
                    BeforeSpawnObject(e);
                    break;
                case AFTER_SPAWN_OBJECT:
                    AfterSpawnObject(e);
                    break;
            }
        }
    }
    public class DMMultipleObjectActionEvent : NWNXEvent {
        public delegate void EventDelegate(DMMultipleObjectActionEvent e);

        public const string DM_HEAL_BEFORE = "NWNX_ON_DM_HEAL_BEFORE";
        public const string DM_HEAL_AFTER = "NWNX_ON_DM_HEAL_AFTER";
        public const string DM_KILL_BEFORE = "NWNX_ON_DM_KILL_BEFORE";
        public const string DM_KILL_AFTER = "NWNX_ON_DM_KILL_AFTER";
        public const string DM_TOGGLE_INVULN_BEFORE = "NWNX_ON_DM_TOGGLE_INVULNERABLE_BEFORE";
        public const string DM_TOGGLE_INVULN_AFTER = "NWNX_ON_DM_TOGGLE_INVULNERABLE_AFTER";
        public const string DM_FORCE_REST_BEFORE = "NWNX_ON_DM_FORCE_REST_BEFORE";
        public const string DM_FORCE_REST_AFTER = "NWNX_ON_DM_FORCE_REST_AFTER";
        public const string DM_LIMBO_BEFORE = "NWNX_ON_DM_LIMBO_BEFORE";
        public const string DM_LIMBO_AFTER = "NWNX_ON_DM_LIMBO_AFTER";
        public const string DM_TOGGLE_AI_BEFORE = "NWNX_ON_DM_TOGGLE_AI_BEFORE";
        public const string DM_TOGGLE_AI_AFTER = "NWNX_ON_DM_TOGGLE_AI_AFTER";
        public const string DM_TOGGLE_IMMORTAL_BEFORE = "NWNX_ON_DM_TOGGLE_IMMORTAL_BEFORE";
        public const string DM_TOGGLE_IMMORTAL_AFTER = "NWNX_ON_DM_TOGGLE_IMMORTAL_AFTER";

        public static EventDelegate DMHealBefore = delegate { };
        public static EventDelegate DMHealAfter = delegate { };
        public static EventDelegate DMKillBefore = delegate { };
        public static EventDelegate DMKillAfter = delegate { };
        public static EventDelegate DMToggleInvulnBefore = delegate { };
        public static EventDelegate DMToggleInvulnAfter = delegate { };
        public static EventDelegate DMForceRestBefore = delegate { };
        public static EventDelegate DMForceRestAfter = delegate { };
        public static EventDelegate DMLimboBefore = delegate { };
        public static EventDelegate DMLimboAfter = delegate { };
        public static EventDelegate DMToggleAIBefore = delegate { };
        public static EventDelegate DMToggleAIAfter = delegate { };
        public static EventDelegate DMToggleImmortalBefore = delegate { };
        public static EventDelegate DMToggleImmortalAfter = delegate { };

        public DMMultipleObjectActionEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();

        public int NumTargets => GetEventInt("NUM_TARGETS");

        public List<NWObject> GetTargets() {
            List<NWObject> retVal = new List<NWObject>();
            for (int i = 1; i <= NumTargets; ++i) retVal.Add(GetEventObject("TARGET_" + i.ToString()).AsObject());
            return retVal;
        }

        [NWNEventHandler(DM_HEAL_BEFORE)]
        [NWNEventHandler(DM_HEAL_AFTER)]
        [NWNEventHandler(DM_KILL_BEFORE)]
        [NWNEventHandler(DM_KILL_AFTER)]
        [NWNEventHandler(DM_TOGGLE_INVULN_BEFORE)]
        [NWNEventHandler(DM_TOGGLE_INVULN_AFTER)]
        [NWNEventHandler(DM_FORCE_REST_BEFORE)]
        [NWNEventHandler(DM_FORCE_REST_AFTER)]
        [NWNEventHandler(DM_LIMBO_BEFORE)]
        [NWNEventHandler(DM_LIMBO_AFTER)]
        [NWNEventHandler(DM_TOGGLE_AI_BEFORE)]
        [NWNEventHandler(DM_TOGGLE_AI_AFTER)]
        [NWNEventHandler(DM_TOGGLE_IMMORTAL_BEFORE)]
        [NWNEventHandler(DM_TOGGLE_IMMORTAL_AFTER)]
        public static void EventHandler(string script) {
            var e = new DMMultipleObjectActionEvent(script);
            switch (script) {
                case DM_HEAL_BEFORE:
                    DMHealBefore(e);
                    break;
                case DM_HEAL_AFTER:
                    DMHealAfter(e);
                    break;
                case DM_KILL_BEFORE:
                    DMKillBefore(e);
                    break;
                case DM_KILL_AFTER:
                    DMKillAfter(e);
                    break;
                case DM_TOGGLE_INVULN_BEFORE:
                    DMToggleInvulnBefore(e);
                    break;
                case DM_TOGGLE_INVULN_AFTER:
                    DMToggleInvulnAfter(e);
                    break;
                case DM_FORCE_REST_BEFORE:
                    DMForceRestBefore(e);
                    break;
                case DM_FORCE_REST_AFTER:
                    DMForceRestAfter(e);
                    break;
                case DM_LIMBO_BEFORE:
                    DMLimboBefore(e);
                    break;
                case DM_LIMBO_AFTER:
                    DMLimboAfter(e);
                    break;
                case DM_TOGGLE_AI_BEFORE:
                    DMToggleAIBefore(e);
                    break;
                case DM_TOGGLE_AI_AFTER:
                    DMToggleAIAfter(e);
                    break;
                case DM_TOGGLE_IMMORTAL_BEFORE:
                    DMToggleImmortalBefore(e);
                    break;
                case DM_TOGGLE_IMMORTAL_AFTER:
                    DMToggleImmortalAfter(e);
                    break;
            }
        }
    }
    public class DMSingleObjectActionEvent : NWNXEvent {
        public delegate void EventDelegate(DMSingleObjectActionEvent e);

        public const string DM_GOTO_BEFORE = "NWNX_ON_DM_GOTO_BEFORE";
        public const string DM_GOTO_AFTER = "NWNX_ON_DM_GOTO_AFTER";
        public const string DM_POSSESS_BEFORE = "NWNX_ON_DM_POSSESS_BEFORE";
        public const string DM_POSSESS_AFTER = "NWNX_ON_DM_POSSESS_AFTER";
        public const string DM_POSSESS_FULL_POWER_BEFORE = "NWNX_ON_DM_POSSESS_FULL_POWER_BEFORE";
        public const string DM_POSSESS_FULL_POWER_AFTER = "NWNX_ON_DM_POSSESS_FULL_POWER_AFTER";
        public const string DM_TOGGLE_LOCK_BEFORE = "NWNX_ON_DM_TOGGLE_LOCK_BEFORE";
        public const string DM_TOGGLE_LOCK_AFTER = "NWNX_ON_DM_TOGGLE_LOCK_AFTER";
        public const string NWNX_ON_DM_DISABLE_TRAP_BEFORE = "DM_DISABLE_TRAP_BEFORE";
        public const string NWNX_ON_DM_DISABLE_TRAP_AFTER = "DM_DISABLE_TRAP_AFTER";

        public static EventDelegate DMGotoBefore = delegate { };
        public static EventDelegate DMGotoAfter = delegate { };
        public static EventDelegate DMPossessBefore = delegate { };
        public static EventDelegate DMPossessAfter = delegate { };
        public static EventDelegate DMPossessFullPowerBefore = delegate { };
        public static EventDelegate DMPossessFullPowerAfter = delegate { };
        public static EventDelegate DMToggleLockBefore = delegate { };
        public static EventDelegate DMToggleLockAfter = delegate { };
        public static EventDelegate DMDisableTrapBefore = delegate { };
        public static EventDelegate DMDisableTrapAfter = delegate { };

        public DMSingleObjectActionEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();

        public NWObject Target => GetEventObject("TARGET").AsObject();

        [NWNEventHandler(DM_GOTO_BEFORE)]
        [NWNEventHandler(DM_GOTO_AFTER)]
        [NWNEventHandler(DM_POSSESS_BEFORE)]
        [NWNEventHandler(DM_POSSESS_AFTER)]
        [NWNEventHandler(DM_POSSESS_FULL_POWER_BEFORE)]
        [NWNEventHandler(DM_POSSESS_FULL_POWER_AFTER)]
        [NWNEventHandler(DM_TOGGLE_LOCK_BEFORE)]
        [NWNEventHandler(DM_TOGGLE_LOCK_AFTER)]
        [NWNEventHandler(NWNX_ON_DM_DISABLE_TRAP_BEFORE)]
        [NWNEventHandler(NWNX_ON_DM_DISABLE_TRAP_AFTER)]

        public static void EventHandler(string script) {
            var e = new DMSingleObjectActionEvent(script);
            switch (script) {
                case DM_GOTO_BEFORE:
                    DMGotoBefore(e);
                    break;
                case DM_GOTO_AFTER:
                    DMGotoAfter(e);
                    break;
                case DM_POSSESS_BEFORE:
                    DMPossessBefore(e);
                    break;
                case DM_POSSESS_AFTER:
                    DMPossessAfter(e);
                    break;
                case DM_POSSESS_FULL_POWER_BEFORE:
                    DMPossessFullPowerBefore(e);
                    break;
                case DM_POSSESS_FULL_POWER_AFTER:
                    DMPossessFullPowerAfter(e);
                    break;
                case DM_TOGGLE_LOCK_BEFORE:
                    DMToggleLockBefore(e);
                    break;
                case DM_TOGGLE_LOCK_AFTER:
                    DMToggleLockAfter(e);
                    break;
                case NWNX_ON_DM_DISABLE_TRAP_BEFORE:
                    DMDisableTrapBefore(e);
                    break;
                case NWNX_ON_DM_DISABLE_TRAP_AFTER:
                    DMDisableTrapAfter(e);
                    break;
            }
        }
    }
    public class DMJumpEvent : NWNXEvent {
        public delegate void EventDelegate(DMJumpEvent e);

        public const string DM_JUMP_TO_POINT_BEFORE = "NWNX_ON_DM_JUMP_TO_POINT_BEFORE";
        public const string DM_JUMP_TO_POINT_AFTER = "NWNX_ON_DM_JUMP_TO_POINT_AFTER";
        public const string DM_JUMP_TARGET_TO_POINT_BEFORE = "NWNX_ON_DM_JUMP_TARGET_TO_POINT_BEFORE";
        public const string DM_JUMP_TARGET_TO_POINT_AFTER = "NWNX_ON_DM_JUMP_TARGET_TO_POINT_AFTER";
        public const string DM_JUMP_ALL_PLAYERS_TO_POINT_BEFORE = "NWNX_ON_DM_JUMP_ALL_PLAYERS_TO_POINT_BEFORE";
        public const string DM_JUMP_ALL_PLAYERS_TO_POINT_AFTER = "NWNX_ON_DM_JUMP_ALL_PLAYERS_TO_POINT_AFTER";

        public static EventDelegate JumpToPointBefore = delegate { };
        public static EventDelegate JumpToPointAfter = delegate { };
        public static EventDelegate JumpTargetToPointBefore = delegate { };
        public static EventDelegate JumpTargetToPointAfter = delegate { };
        public static EventDelegate JumpAllPlayersToPointBefore = delegate { };
        public static EventDelegate JumpAllPlayersToPointAfter = delegate { };

        public DMJumpEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();
        public NWArea TargetArea => GetEventObject("TARGET_AREA").AsArea();
        public Vector Pos => GetEventVector("POS");
        int NumTargets => GetEventInt("NUM_TARGETS");
        public List<NWObject> GetTargets() {
            List<NWObject> retVal = new List<NWObject>();
            for (int i = 1; i <= NumTargets; ++i) retVal.Add(GetEventObject("TARGET_" + i.ToString()).AsObject());
            return retVal;
        }        

        [NWNEventHandler(DM_JUMP_TO_POINT_BEFORE)]
        [NWNEventHandler(DM_JUMP_TO_POINT_AFTER)]
        [NWNEventHandler(DM_JUMP_TARGET_TO_POINT_BEFORE)]
        [NWNEventHandler(DM_JUMP_TARGET_TO_POINT_AFTER)]
        [NWNEventHandler(DM_JUMP_ALL_PLAYERS_TO_POINT_BEFORE)]
        [NWNEventHandler(DM_JUMP_ALL_PLAYERS_TO_POINT_AFTER)]
        public static void EventHandler(string script) {
            var e = new DMJumpEvent(script);
            switch (script) {
                case DM_JUMP_TO_POINT_BEFORE:
                    JumpToPointBefore(e);
                    break;
                case DM_JUMP_TO_POINT_AFTER:
                    JumpToPointAfter(e);
                    break;
                case DM_JUMP_TARGET_TO_POINT_BEFORE:
                    JumpTargetToPointBefore(e);
                    break;
                case DM_JUMP_TARGET_TO_POINT_AFTER:
                    JumpTargetToPointAfter(e);
                    break;
                case DM_JUMP_ALL_PLAYERS_TO_POINT_BEFORE:
                    JumpAllPlayersToPointBefore(e);
                    break;
                case DM_JUMP_ALL_PLAYERS_TO_POINT_AFTER:
                    JumpAllPlayersToPointAfter(e);
                    break;
            }
        }
    }
    public class DMChangeDifficultyEvent : NWNXEvent {
        public delegate void EventDelegate(DMChangeDifficultyEvent e);

        public const string DM_CHANGE_DIFFICULTY_BEFORE = "NWNX_ON_DM_CHANGE_DIFFICULTY_BEFORE";
        public const string DM_CHANGE_DIFFICULTY_AFTER = "NWNX_ON_DM_CHANGE_DIFFICULTY_AFTER";

        public static EventDelegate BeforeChangeDifficulty = delegate { };
        public static EventDelegate AfterChangeDifficulty = delegate { };

        public DMChangeDifficultyEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();
        public int DifficultySetting => GetEventInt("DIFFICULTY_SETTING"); 


        [NWNEventHandler(DM_CHANGE_DIFFICULTY_BEFORE)]
        [NWNEventHandler(DM_CHANGE_DIFFICULTY_AFTER)]
        public static void EventHandler(string script) {
            var e = new DMChangeDifficultyEvent(script);
            switch (script) {
                case DM_CHANGE_DIFFICULTY_BEFORE:
                    BeforeChangeDifficulty(e);
                    break;
                case DM_CHANGE_DIFFICULTY_AFTER:
                    AfterChangeDifficulty(e);
                    break;
            }
        }
    }
    public class DMViewInventoryEvent : NWNXEvent {
        public delegate void EventDelegate(DMViewInventoryEvent e);

        public const string DM_VIEW_INVENTORY_BEFORE = "NWNX_ON_DM_VIEW_INVENTORY_BEFORE";
        public const string DM_VIEW_INVENTORY_AFTER = "NWNX_ON_DM_VIEW_INVENTORY_AFTER";

        public static EventDelegate BeforeViewInventory = delegate { };
        public static EventDelegate AfterViewInventory = delegate { };

        public DMViewInventoryEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();
        public bool IsOpening => GetEventInt("OPEN_INVENTORY") == 1;
        public NWObject Target => GetEventObject("TARGET").AsObject();


        [NWNEventHandler(DM_VIEW_INVENTORY_BEFORE)]
        [NWNEventHandler(DM_VIEW_INVENTORY_AFTER)]
        public static void EventHandler(string script) {
            var e = new DMViewInventoryEvent(script);
            switch (script) {
                case DM_VIEW_INVENTORY_BEFORE:
                    BeforeViewInventory(e);
                    break;
                case DM_VIEW_INVENTORY_AFTER:
                    AfterViewInventory(e);
                    break;
            }
        }
    }
    public class DMSpawnTrapOnObjectEvent : NWNXEvent {
        public delegate void EventDelegate(DMSpawnTrapOnObjectEvent e);

        public const string DM_SPAWN_TRAP_ON_OBJECT_BEFORE = "NWNX_ON_DM_SPAWN_TRAP_ON_OBJECT_BEFORE";
        public const string DM_SPAWN_TRAP_ON_OBJECT_AFTER = "NWNX_ON_DM_SPAWN_TRAP_ON_OBJECT_AFTER";

        public static EventDelegate BeforeSpawnTrapOnObject = delegate { };
        public static EventDelegate AfterSpawnTrapOnObject = delegate { };

        public DMSpawnTrapOnObjectEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();
        public NWArea Area => GetEventObject("AREA").AsArea();
        public NWObject Target => GetEventObject("TARGET").AsObject();


        [NWNEventHandler(DM_SPAWN_TRAP_ON_OBJECT_BEFORE)]
        [NWNEventHandler(DM_SPAWN_TRAP_ON_OBJECT_AFTER)]
        public static void EventHandler(string script) {
            var e = new DMSpawnTrapOnObjectEvent(script);
            switch (script) {
                case DM_SPAWN_TRAP_ON_OBJECT_BEFORE:
                    BeforeSpawnTrapOnObject(e);
                    break;
                case DM_SPAWN_TRAP_ON_OBJECT_AFTER:
                    AfterSpawnTrapOnObject(e);
                    break;
            }
        }
    }
    public class DMDumpLocalsEvent : NWNXEvent {
        public delegate void EventDelegate(DMDumpLocalsEvent e);

        public const string DM_DUMP_LOCALS_BEFORE = "NWNX_ON_DM_DUMP_LOCALS_BEFORE";
        public const string DM_DUMP_LOCALS_AFTER = "NWNX_ON_DM_DUMP_LOCALS_AFTER";

        public static EventDelegate BeforeDMDumpLocals = delegate { };
        public static EventDelegate AfterDMDumpLocals = delegate { };

        public DMDumpLocalsEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();
        public int Type => GetEventInt("TYPE");
        public NWObject Target => GetEventObject("TARGET").AsObject();


        [NWNEventHandler(DM_DUMP_LOCALS_BEFORE)]
        [NWNEventHandler(DM_DUMP_LOCALS_AFTER)]
        public static void EventHandler(string script) {
            var e = new DMDumpLocalsEvent(script);
            switch (script) {
                case DM_DUMP_LOCALS_BEFORE:
                    BeforeDMDumpLocals(e);
                    break;
                case DM_DUMP_LOCALS_AFTER:
                    AfterDMDumpLocals(e);
                    break;
            }
        }
    }
    public class DMOtherEvent : NWNXEvent {
        public delegate void EventDelegate(DMOtherEvent e);

        public const string DM_APPEAR_BEFORE = "NWNX_ON_DM_APPEAR_BEFORE";
        public const string DM_APPEAR_AFTER = "NWNX_ON_DM_APPEAR_AFTER";
        public const string DM_DISAPPEAR_BEFORE = "NWNX_ON_DM_DISAPPEAR_BEFORE";
        public const string DM_DISAPPEAR_AFTER = "NWNX_ON_DM_DISAPPEAR_AFTER";
        public const string DM_SET_FACTION_BEFORE = "NWNX_ON_DM_SET_FACTION_BEFORE";
        public const string DM_SET_FACTION_AFTER = "NWNX_ON_DM_SET_FACTION_AFTER";
        public const string DM_TAKE_ITEM_BEFORE = "NWNX_ON_DM_TAKE_ITEM_BEFORE";
        public const string DM_TAKE_ITEM_AFTER = "NWNX_ON_DM_TAKE_ITEM_AFTER";
        public const string DM_SET_STAT_BEFORE = "NWNX_ON_DM_SET_STAT_BEFORE";
        public const string DM_SET_STAT_AFTER = "NWNX_ON_DM_SET_STAT_AFTER";
        public const string DM_GET_VARIABLE_BEFORE = "NWNX_ON_DM_GET_VARIABLE_BEFORE";
        public const string DM_GET_VARIABLE_AFTER = "NWNX_ON_DM_GET_VARIABLE_AFTER";
        public const string DM_SET_VARIABLE_BEFORE = "NWNX_ON_DM_SET_VARIABLE_BEFORE";
        public const string DM_SET_VARIABLE_AFTER = "NWNX_ON_DM_SET_VARIABLE_AFTER";
        public const string DM_SET_TIME_BEFORE = "NWNX_ON_DM_SET_TIME_BEFORE";
        public const string DM_SET_TIME_AFTER = "NWNX_ON_DM_SET_TIME_AFTER";
        public const string DM_SET_DATE_BEFORE = "NWNX_ON_DM_SET_DATE_BEFORE";
        public const string DM_SET_DATE_AFTER = "NWNX_ON_DM_SET_DATE_AFTER";
        public const string DM_SET_FACTION_REPUTATION_BEFORE = "NWNX_ON_DM_SET_FACTION_REPUTATION_BEFORE";
        public const string DM_SET_FACTION_REPUTATION_AFTER = "NWNX_ON_DM_SET_FACTION_REPUTATION_AFTER";
        public const string DM_GET_FACTION_REPUTATION_BEFORE = "NWNX_ON_DM_GET_FACTION_REPUTATION_BEFORE";
        public const string DM_GET_FACTION_REPUTATION_AFTER = "NWNX_ON_DM_GET_FACTION_REPUTATION_AFTER";

        public static EventDelegate DMAppearBefore = delegate { };
        public static EventDelegate DMAppearAfter = delegate { };
        public static EventDelegate DMDisappearBefore = delegate { };
        public static EventDelegate DMDisappearAfter = delegate { };
        public static EventDelegate DMSetFactionBefore = delegate { };
        public static EventDelegate DMSetFactionAfter = delegate { };
        public static EventDelegate DMTakeItemBefore = delegate { };
        public static EventDelegate DMTakeItemAfter = delegate { };
        public static EventDelegate DMSetStatBefore = delegate { };
        public static EventDelegate DMSetStatAfter = delegate { };
        public static EventDelegate DMGetVariableBefore = delegate { };
        public static EventDelegate DMGetVariableAfter = delegate { };
        public static EventDelegate DMSetVariableBefore = delegate { };
        public static EventDelegate DMSetVariableAfter = delegate { };
        public static EventDelegate DMSetTimeBefore = delegate { };
        public static EventDelegate DMSetTimeAfter = delegate { };
        public static EventDelegate SetDateBefore = delegate { };
        public static EventDelegate SetDateAfter = delegate { };
        public static EventDelegate DMSetFactionRepBefore = delegate { };
        public static EventDelegate DMSetFactionRepAfter = delegate { };
        public static EventDelegate DMGetFactionRepBefore = delegate { };
        public static EventDelegate DMGetFactionRepAfter = delegate { };

        public DMOtherEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer DM => Internal.OBJECT_SELF.AsPlayer();

        [NWNEventHandler(DM_APPEAR_BEFORE)]
        [NWNEventHandler(DM_APPEAR_AFTER)]
        [NWNEventHandler(DM_DISAPPEAR_BEFORE)]
        [NWNEventHandler(DM_DISAPPEAR_AFTER)]
        [NWNEventHandler(DM_SET_FACTION_BEFORE)]
        [NWNEventHandler(DM_SET_FACTION_AFTER)]
        [NWNEventHandler(DM_TAKE_ITEM_BEFORE)]
        [NWNEventHandler(DM_TAKE_ITEM_AFTER)]
        [NWNEventHandler(DM_SET_STAT_BEFORE)]
        [NWNEventHandler(DM_SET_STAT_AFTER)]
        [NWNEventHandler(DM_GET_VARIABLE_BEFORE)]
        [NWNEventHandler(DM_GET_VARIABLE_AFTER)]
        [NWNEventHandler(DM_SET_VARIABLE_BEFORE)]
        [NWNEventHandler(DM_SET_VARIABLE_AFTER)]
        [NWNEventHandler(DM_SET_TIME_BEFORE)]
        [NWNEventHandler(DM_SET_TIME_AFTER)]
        [NWNEventHandler(DM_SET_DATE_BEFORE)]
        [NWNEventHandler(DM_SET_DATE_AFTER)]
        [NWNEventHandler(DM_SET_FACTION_REPUTATION_BEFORE)]
        [NWNEventHandler(DM_SET_FACTION_REPUTATION_AFTER)]
        [NWNEventHandler(DM_GET_FACTION_REPUTATION_BEFORE)]
        [NWNEventHandler(DM_GET_FACTION_REPUTATION_AFTER)]
        public static void EventHandler(string script) {
            var e = new DMOtherEvent(script);
            switch (script) {
                case DM_APPEAR_BEFORE:
                    DMAppearBefore(e);
                    break;
                case DM_APPEAR_AFTER:
                    DMAppearAfter(e);
                    break;
                case DM_DISAPPEAR_BEFORE:
                    DMDisappearBefore(e);
                    break;
                case DM_DISAPPEAR_AFTER:
                    DMDisappearAfter(e);
                    break;
                case DM_SET_FACTION_BEFORE:
                    DMSetFactionBefore(e);
                    break;
                case DM_SET_FACTION_AFTER:
                    DMSetFactionAfter(e);
                    break;
                case DM_TAKE_ITEM_BEFORE:
                    DMTakeItemBefore(e);
                    break;
                case DM_TAKE_ITEM_AFTER:
                    DMTakeItemAfter(e);
                    break;
                case DM_SET_STAT_BEFORE:
                    DMSetStatBefore(e);
                    break;
                case DM_SET_STAT_AFTER:
                    DMSetStatAfter(e);
                    break;
                case DM_GET_VARIABLE_BEFORE:
                    DMGetVariableBefore(e);
                    break;
                case DM_GET_VARIABLE_AFTER:
                    DMGetVariableAfter(e);
                    break;
                case DM_SET_VARIABLE_BEFORE:
                    DMSetVariableBefore(e);
                    break;
                case DM_SET_VARIABLE_AFTER:
                    DMSetVariableAfter(e);
                    break;
                case DM_SET_TIME_BEFORE:
                    DMSetTimeBefore(e);
                    break;
                case DM_SET_TIME_AFTER:
                    DMSetTimeAfter(e);
                    break;
                case DM_SET_DATE_BEFORE:
                    SetDateBefore(e);
                    break;
                case DM_SET_DATE_AFTER:
                    SetDateAfter(e);
                    break;
                case DM_SET_FACTION_REPUTATION_BEFORE:
                    DMSetFactionRepBefore(e);
                    break;
                case DM_SET_FACTION_REPUTATION_AFTER:
                    DMSetFactionRepAfter(e);
                    break;
                case DM_GET_FACTION_REPUTATION_BEFORE:
                    DMGetFactionRepBefore(e);
                    break;
                case DM_GET_FACTION_REPUTATION_AFTER:
                    DMGetFactionRepAfter(e);
                    break;
            }
        }
    }
}