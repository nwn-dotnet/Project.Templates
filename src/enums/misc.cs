namespace NWN
{
    public enum PvPSetting
    {
        NoPvP              = 0,
        PartyPvP           = 1,
        FullPvP            = 2,
        ServerDefault      = 3,
    }
    public enum WeatherEffectType
    {
        Rain = 0,
        Snow = 1,
        Lightning = 2,
    }
    public enum WeatherType
    {
        Invalid = -1,
        Clear = 0,
        Rain = 1,
        Snow = 2,
    }
    public enum DayNightCycleType
    {
        CycleDayNight = 0,
        AlwaysBright = 1,
        AlwaysDark = 2,
    }
    public enum AreaColorType
    {
        MoonAmbient = 0,
        MoonDiffuse = 1,
        SunAmbient  = 2,
        SunDiffuse  = 3,
    }
    public enum MovementRate
    {
        PC       = 0,
        Immobile = 1,
        VerySlow = 2,
        Slow     = 3,
        Normal   = 4,
        Fast     = 5,
        VeryFast = 6,
        Default  = 7,
        DMFast   = 8,
    }
    public enum MovementType
    {
        Stationary    = 0,
        Walk          = 1,
        Run           = 2,
        Sidestep      = 3,
        WalkBackwards = 4,
    }
    public enum BonusType
    {
        Attack        = 1,
        Damage        = 2,
        SavingThrow   = 3,
        Ability       = 4,
        Skill         = 5,
        TouchAttack   = 6,
    }
    public enum Gender
    {
        Male = 0,
        Female = 1,
        Both = 2,
        Other = 3,
        None = 4,
    }
    public enum CreatureSize
    {
        Invalid = 0,
        Tiny = 1,
        Small = 2,
        Medium = 3,
        Large = 4,
        Huge = 5,
    }
    public enum SpecialAttack
    {
        Invalid = 0,
        CalledShotLeg = 1,
        CalledShotArm = 2,
        Sap = 3,
        Disarm = 4,
        ImprovedDisarm = 5,
        Knockdown = 6,
        ImprovedKnockdown = 7,
        StunningFist = 8,
        FlurryOfBlows = 9,
        RapidShot = 10,
    }
    public enum CombatMode
    {
        Invalid             = 0,
        Parry               = 1,
        PowerAttack         = 2,
        ImprovedPowerAttack = 3,
        //CounterSpell
        FlurryOfBlows       = 4,
        RapidShot           = 5,
        Expertise           = 6,
        ImprovedExpertise   = 7,
        DefensiveCasting    = 8,
        DirtyFighting       = 9,
        DefensiveStance     = 10,
    }
    public enum AILevel
    {
        Default   = -1,
        VeryLow   = 0,
        Low       = 1,
        Medium    = 2,
        High      = 3,
        VeryHigh  = 4,
    }
    public enum AssociateCommand
    {
        StandGround = -2,
        AttackNearest = -3,
        HealMaster = -4,
        FollowMaster = -5,
        MasterFailedLockpick = -6,
        GuardMaster = -7,
        UnsummonFamiliar = -8,
        UnsummonAnimalCompanion = -9,
        UnsummonSummoned = -10,
        MasterUnderAttack = -11,
        ReleaseDomination = -12,
        UnpossessFamiliar = -13,
        MasterSawTrap = -14,
        MasterAttackedOther = -15,
        MasterGoingtobeAttacked = -16,
        LeaveParty = -17,
        PickLock = -18,
        Inventory = -19,
        DisarmTrap = -20,
        ToggleCasting = -21,
        ToggleStealth = -22,
        ToggleSearch = -23,
    }
    public enum Ability
    {
        Invalid       = -1,
        Strength      = 0,
        Dexterity     = 1,
        Constitution  = 2,
        Intelligence  = 3,
        Wisdom        = 4,
        Charisma      = 5,
    }
    [System.Flags]
    public enum ObjectType
    {
        Creature       = 1,
        Item           = 2,
        Trigger        = 4,
        Door           = 8,
        AreaOfEffect   = 16,
        Waypoint       = 32,
        Placeable      = 64,
        Store          = 128,
        Encounter      = 256,
        All            = 32767,
        Invalid        = 32767,
    }
    public enum ObjectTypeEngine
    {
        Invalid        = -1,
        GUI            = 1,
        Tile           = 2,
        Module         = 3,
        Area           = 4,
        Creature       = 5,
        Item           = 6,
        Trigger        = 7,
        Projectile     = 8,
        Placeable      = 9,
        Door           = 10,
        AreaOfEffect   = 11,
        Waypoint       = 12,
        Encounter      = 13,
        Store          = 14,
        Portal         = 15,
        Sound          = 16,
    }

    public enum EventScript
    {
        Module_OnHeartbeat                    = 3000,
        Module_OnUserDefined                  = 3001,
        Module_OnModuleLoad                   = 3002,
        Module_OnModuleStart                  = 3003,
        Module_OnClientEnter                  = 3004,
        Module_OnClientExit                   = 3005,
        Module_OnActivateItem                 = 3006,
        Module_OnAcquireItem                  = 3007,
        Module_OnLoseItem                     = 3008,
        Module_OnPlayerDeath                  = 3009,
        Module_OnPlayerDying                  = 3010,
        Module_OnRespawnButtonPressed         = 3011,
        Module_OnPlayerRest                   = 3012,
        Module_OnPlayerLevelUp                = 3013,
        Module_OnPlayerCancelCutscene         = 3014,
        Module_OnEquipItem                    = 3015,
        Module_OnUnequipItem                  = 3016,
        Module_OnPlayerChat                   = 3017,
        Area_OnHeartbeat                      = 4000,
        Area_OnUserDefined                    = 4001,
        Area_OnEnter                          = 4002,
        Area_OnExit                           = 4003,
        AreaOfEffect_OnHeartbeat              = 11000,
        AreaOfEffect_OnUserDefined            = 11001,
        AreaOfEffect_OnObjectEnter            = 11002,
        AreaOfEffect_OnObjectExit             = 11003,
        Creature_OnHeartbeat                  = 5000,
        Creature_OnNotice                     = 5001,
        Creature_OnSpellCastAt                = 5002,
        Creature_OnMeleeAttacked              = 5003,
        Creature_OnDamaged                    = 5004,
        Creature_OnDisturbed                  = 5005,
        Creature_OnEndCombatRound             = 5006,
        Creature_OnDialogue                   = 5007,
        Creature_OnSpawnIn                    = 5008,
        Creature_OnRested                     = 5009,
        Creature_OnDeath                      = 5010,
        Creature_OnUserDefined                = 5011,
        Creature_OnBlockedByDoor              = 5012,
        Trigger_OnHeartbeat                   = 7000,
        Trigger_OnObjectEnter                 = 7001,
        Trigger_OnObjectExit                  = 7002,
        Trigger_OnUserDefined                 = 7003,
        Trigger_OnTrapTriggered               = 7004,
        Trigger_OnDisarmed                    = 7005,
        Trigger_OnClicked                     = 7006,
        Placeable_OnClosed                    = 9000,
        Placeable_OnDamaged                   = 9001,
        Placeable_OnDeath                     = 9002,
        Placeable_OnDisarm                    = 9003,
        Placeable_OnHeartbeat                 = 9004,
        Placeable_OnInventoryDisturbed        = 9005,
        Placeable_OnLock                      = 9006,
        Placeable_OnMeleeAttacked             = 9007,
        Placeable_OnOpen                      = 9008,
        Placeable_OnSpellCastAt               = 9009,
        Placeable_OnTrapTriggered             = 9010,
        Placeable_OnUnlock                    = 9011,
        Placeable_OnUsed                      = 9012,
        Placeable_OnUserDefined               = 9013,
        Placeable_OnDialogue                  = 9014,
        Placeable_OnLeftClick                 = 9015,
        Door_OnOpen                           = 10000,
        Door_OnClose                          = 10001,
        Door_OnDamage                         = 10002,
        Door_OnDeath                          = 10003,
        Door_OnDisarm                         = 10004,
        Door_OnHeartbeat                      = 10005,
        Door_OnLock                           = 10006,
        Door_OnMeleeAttacked                  = 10007,
        Door_OnSpellcastat                    = 10008,
        Door_OnTrapTriggered                  = 10009,
        Door_OnUnlock                         = 10010,
        Door_OnUserDefined                    = 10011,
        Door_OnClicked                        = 10012,
        Door_OnDialogue                       = 10013,
        Door_OnFailToOpen                     = 10014,
        Encounter_OnObjectEnter               = 13000,
        Encounter_OnObjectExit                = 13001,
        Encounter_OnHeartbeat                 = 13002,
        Encounter_OnEncounterExhausted        = 13003,
        Encounter_OnUserDefined               = 13004,
        Store_OnOpen                          = 14000,
        Store_OnClose                         = 14001,
    }


    public enum ACBonus
    {
        Dodge         = 0,
        Natural       = 1,
        Armor         = 2,
        Shield        = 3,
        Deflection    = 4,
    }

    public enum SavingThrow
    {
        All          = 0,
        None         = 0,
        Fortitude    = 1,
        Reflex       = 2,
        Will         = 3,
    }

    public enum SavingThrowType
    {
        All          = 0,
        None         = 0,
        MindSpells   = 1,
        Poison       = 2,
        Disease      = 3,
        Fear         = 4,
        Sonic        = 5,
        Acid         = 6,
        Fire         = 7,
        Electricity  = 8,
        Positive     = 9,
        Negative     = 10,
        Death        = 11,
        Cold         = 12,
        Divine       = 13,
        Trap         = 14,
        Spell        = 15,
        Good         = 16,
        Evil         = 17,
        Law          = 18,
        Chaos        = 19,
    }

    [System.Flags]
    public enum DamageType
    {
        None         = 0x0000,
        Bludgeoning  = 0x0001,
        Piercing     = 0x0002,
        Slashing     = 0x0004,
        Magical      = 0x0008,
        Acid         = 0x0010,
        Cold         = 0x0020,
        Divine       = 0x0040,
        Electrical   = 0x0080,
        Fire         = 0x0100,
        Negative     = 0x0200,
        Positive     = 0x0400,
        Sonic        = 0x0800,

        Physical     = Bludgeoning | Piercing | Slashing,
        Elemental    = Acid | Cold | Electrical | Fire | Sonic,
        Exotic       = Divine | Magical | Negative | Positive,

    }

    public enum ImmunityType
    {
        None                     = 0,
        MindSpells               = 1,
        Poison                   = 2,
        Disease                  = 3,
        Fear                     = 4,
        Trap                     = 5,
        Paralysis                = 6,
        Blindness                = 7,
        Deafness                 = 8,
        Slow                     = 9,
        Entangle                 = 10,
        Silence                  = 11,
        Stun                     = 12,
        Sleep                    = 13,
        Charm                    = 14,
        Dominate                 = 15,
        Confused                 = 16,
        Cursed                   = 17,
        Dazed                    = 18,
        AbilityDecrease          = 19,
        AttackDecrease           = 20,
        DamageDecrease           = 21,
        DamageImmunityDecrease   = 22,
        AcDecrease               = 23,
        MovementSpeedDecrease    = 24,
        SavingThrowDecrease      = 25,
        SpellResistanceDecrease  = 26,
        SkillDecrease            = 27,
        Knockdown                = 28,
        NegativeLevel            = 29,
        SneakAttack              = 30,
        CriticalHit              = 31,
        Death                    = 32,
    }

    public enum ToggleMode
    {
        Detect              = 0,
        Stealth             = 1,
        Parry               = 2,
        PowerAttack         = 3,
        ImprovedPowerAttack = 4,
        CounterSpell        = 5,
        FlurryOfBlows       = 6,
        RapidShot           = 7,
        Expertise           = 8,
        ImprovedExpertise   = 9,
        DefensiveCast       = 10,
        DirtyFighting       = 11,
        DefensiveStance     = 12,
    }

    public enum CombatModeEngine // Values used by the engine and NWNX
    {
        None                = 0,
        Parry               = 1,
        PowerAttack         = 2,
        ImprovedPowerAttack = 3,
        CounterSpell        = 4,
        FlurryOfBlows       = 5,
        RapidShot           = 6,
        Expertise           = 7,
        ImprovedExpertise   = 8,
        DefensiveCasting    = 9,
        DirtyFighting       = 10,
        DefensiveStance     = 11,
    }

    public enum Alignment
    {
        All                 = 0,
        Neutral             = 1,
        Lawful              = 2,
        Chaotic             = 3,
        Good                = 4,
        Evil                = 5,
    }

    public enum Direction
    {
        East = 0,
        North = 90,
        West = 180,
        South = 270,
        NorthEast = 45,
        NorthWest = 135,
        SouthEast = 315,
        SouthWest = 225,
    }
}
