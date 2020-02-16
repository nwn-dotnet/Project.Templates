using System;
using System.Collections.Generic;
using System.Linq;

namespace NWN
{
    public class NWCreature : NWObject
    {
        public override bool IsValidType => ObjectType == ObjectType.Creature;

        public virtual int Age => NWScript.GetAge(this);

        public string OriginalFirstName
        {
            get => NWNX.Creature.GetOriginalName(this, false);
            set => NWNX.Creature.SetOriginalName(this, value, false);
        }
        public string OriginalLastName
        {
            get => NWNX.Creature.GetOriginalName(this, true);
            set => NWNX.Creature.SetOriginalName(this, value, true);
        }
        public virtual float ChallengeRating
        {
            get => NWScript.GetChallengeRating(this);
            set => NWNX.Creature.SetChallengeRating(this, value);
        }

        public virtual ClassType Class1
        {
            get => (ClassType)NWScript.GetClassByPosition(1, this);
            set => NWNX.Creature.SetClassByPosition(this, 0, value);
        }
        public virtual ClassType Class2
        {
            get => (ClassType)NWScript.GetClassByPosition(2, this);
            set => NWNX.Creature.SetClassByPosition(this, 2, value);
        }
        public virtual ClassType Class3
        {
            get => (ClassType)NWScript.GetClassByPosition(3, this);
            set => NWNX.Creature.SetClassByPosition(this, 3, value);
        }

        public virtual bool IsCommandable
        {
            get => NWScript.GetCommandable(this) != 0;
            set => NWScript.SetCommandable(value ? 1 : 0, this);
        }

        // TODO-enumize
        public virtual int Phenotype
        {
            get => NWScript.GetPhenoType(this);
            set => NWScript.SetPhenoType(value, this);
        }

        public virtual string Deity
        {
            get => NWScript.GetDeity(this);
            set => NWScript.SetDeity(this, value);
        }
        public virtual string SubRace
        {
            get => NWScript.GetSubRace(this);
            set => NWScript.SetSubRace(this, value);
        }

        public virtual RacialType RacialType
        {
            get => (RacialType)NWScript.GetRacialType(this);
            set => NWNX.Creature.SetRacialType(this, value);
        }

        public virtual int ArmorClass => NWScript.GetAC(this);
        public virtual int BaseAC
        {
            get => NWNX.Creature.GetBaseAC(this);
            set => NWNX.Creature.SetBaseAC(this, value);
        }
        public virtual MovementRate MovementRate
        {
            get => (MovementRate)NWScript.GetMovementRate(this);
            set => NWNX.Creature.SetMovementRate(this, value);
        }
        public virtual float MovementRateFactor
        {
            get => NWNX.Creature.GetMovementRateFactor(this);
            set => NWNX.Creature.SetMovementRateFactor(this, value);
        }
        public virtual int Soundset
        {
            get => NWNX.Creature.GetSoundset(this);
            set => NWNX.Creature.SetSoundset(this, value);
        }
        public virtual Gender Gender
        {
            get => (Gender)NWScript.GetGender(this);
            set => NWNX.Creature.SetGender(this, value);
        }

        public virtual bool IsResting => NWScript.GetIsResting(this) != 0;
        public virtual bool IsPlayableRace => NWScript.GetIsPlayableRacialType(this) != 0;

        public virtual float TotalWeight => NWScript.GetWeight(this) * 0.1f;
        public virtual CreatureSize Size
        {
            get => (CreatureSize)NWScript.GetCreatureSize(this);
            set => NWNX.Creature.SetSize(this, value);
        }
        public virtual int Gold
        {
            get => NWScript.GetGold(this);
            set => NWNX.Creature.SetGold(this, value);
        }

        public class Abilities
        {
            private NWCreature owner;
            public class AbilityScore
            {
                private Ability ability;
                private NWCreature owner;
                public AbilityScore(Ability ability, NWCreature owner) { this.ability = ability; this.owner = owner; }

                public int Total => NWScript.GetAbilityScore(owner, (int)ability);
                public int Base => NWScript.GetAbilityScore(owner, (int)ability, 1);
                public int Modifier => NWScript.GetAbilityModifier((int)ability, owner);
                public int Raw
                {
                    get => NWNX.Creature.GetRawAbilityScore(owner, ability);
                    set => NWNX.Creature.SetRawAbilityScore(owner, ability, value);
                }
            }
            public Abilities(NWCreature owner) { this.owner = owner; }
            public AbilityScore this[Ability index] { get => new AbilityScore(index, owner); }
        }
        public Abilities Ability;

        public virtual NWObject AttackTarget => NWScript.GetAttackTarget(this).AsObject();
        public virtual SpecialAttack LastAttackType => (SpecialAttack)NWScript.GetLastAttackType(this);
        public virtual CombatMode LastAttackMode => (CombatMode)NWScript.GetLastAttackMode(this);

        public virtual int XP
        {
            get => NWScript.GetXP(this);
            set => NWScript.SetXP(this, value);
        }

        public virtual AILevel AILevel
        {
            get => (AILevel)NWScript.GetAILevel(this);
            set => NWScript.SetAILevel(this, (int)value);
        }

        public bool IsInCombat => NWScript.GetIsInCombat(this) != 0;

        public virtual void ClearAllActions(bool clearCombatState = false)
        {
            AssignCommand(() => { NWScript.ClearAllActions(clearCombatState ? 1 : 0); });
        }

        public class EquippedItems
        {
            private NWCreature owner;
            public EquippedItems(NWCreature owner)
            {
                this.owner = owner;
            }
            public NWItem this[InventorySlot index] { get => NWScript.GetItemInSlot((int)index, owner).AsItem(); }
            public virtual IEnumerable<NWItem> All
            {
                get
                {
                    for (int slot = 0; slot < NWScript.NUM_INVENTORY_SLOTS; slot++)
                    {
                        yield return NWScript.GetItemInSlot(slot, owner).AsItem();
                    }
                }
            }
        }
        public EquippedItems Equipped;

        public virtual void FloatingText(string text, bool displayToFaction = false)
        {
            NWScript.FloatingTextStringOnCreature(text, this, displayToFaction ? 1 : 0);
        }

        public virtual bool IsDead => NWScript.GetIsDead(this) != 0;
        public virtual bool IsPC => NWScript.GetIsPC(this) != 0;
        public virtual bool IsDM => NWScript.GetIsDM(this) != 0;

        public virtual bool IsPossessedFamiliar => NWScript.GetIsPossessedFamiliar(this) == 1;

        public virtual bool IsDMPossessed => NWScript.GetIsDMPossessed(this) == 1;
        public virtual NWCreature Master => NWScript.GetMaster(this).AsCreature();
        public virtual AssociateCommand LastCommandFromMaster => (AssociateCommand)NWScript.GetLastAssociateCommand(this);
        public virtual NWItem LastWeaponUsed => NWScript.GetLastWeaponUsed(this).AsItem();
        public virtual NWObject LastDamager => NWScript.GetLastDamager(this).AsObject();
        public virtual NWTrappable LastTrapDetected => NWScript.GetLastTrapDetected(this).AsTrappable();

        public int SpellResistance
        {
            get => NWScript.GetSpellResistance(this);
            set => NWNX.Creature.SetSpellResistance(this, value);
        }
        public int SkillPointsRemaining
        {
            get => NWNX.Creature.GetSkillPointsRemaining(this);
            set => NWNX.Creature.SetSkillPointsRemaining(this, value);
        }

        public NWItem GetPossessedItem(string itemTag)
        {
            return NWScript.GetItemPossessedBy(this, itemTag).AsItem();
        }

        // Feats stuff..
        public int FeatCount => NWNX.Creature.GetFeatCount(this);
        public bool HasFeat(Feat feat)
        {
            return NWScript.GetHasFeat((int)feat, this) != 0;
        }
        public void AddFeat(Feat feat)
        {
            NWNX.Creature.AddFeat(this, feat);
        }
        public void AddFeatByLevel(Feat feat, int level)
        {
            NWNX.Creature.AddFeatByLevel(this, feat, level);
        }
        public void RemoveFeat(Feat feat)
        {
            NWNX.Creature.RemoveFeat(this, feat);
        }
        public bool KnowsFeat(Feat feat)
        {
            return NWNX.Creature.GetKnowsFeat(this, feat);
        }
        public Feat GetFeat(int index)
        {
            return NWNX.Creature.GetFeatByIndex(this, index);
        }
        public virtual IEnumerable<Feat> Feats
        {
            get
            {
                var count = FeatCount;
                for (var i = 0; i < count; i++)
                    yield return GetFeat(i);
            }
        }
        public bool MeetsFeatRequirements(Feat feat)
        {
            return NWNX.Creature.GetMeetsFeatRequirements(this, feat);
        }
        public int GetFeatRemainingUses(Feat feat)
        {
            return NWNX.Creature.GetFeatRemainingUses(this, feat);
        }
        public int GetFeatTotalUses(Feat feat)
        {
            return NWNX.Creature.GetFeatTotalUses(this, feat);
        }
        public void SetFeatRemainingUses(Feat feat, int uses)
        {
            NWNX.Creature.SetFeatRemainingUses(this, feat, uses);
        }

        public bool HasSkill(int skill)
        {
            return NWScript.GetHasSkill(skill, this) != 0;
        }
        public int GetSkillRank(int skill, bool baseOnly=false)
        {
            return NWScript.GetSkillRank(skill, this, baseOnly?1:0);
        }

        public bool GetObjectSeen(NWObject target)
        {
            return NWScript.GetObjectSeen(target, this) != 0;
        }
        public bool GetObjectHeard(NWObject target)
        {
            return NWScript.GetObjectHeard(target, this) != 0;
        }

        public void SummonFamiliar()
        {
            NWScript.SummonFamiliar(this);
        }
        public void SummonAnimalCompanion()
        {
            NWScript.SummonAnimalCompanion(this);
        }

        public bool HasAnyEffect(params int[] effectIDs)
        {
            var eff = NWScript.GetFirstEffect(this);
            while (NWScript.GetIsEffectValid(eff) == 1)
            {
                if (effectIDs.Contains(NWScript.GetEffectType(eff)))
                {
                    return true;
                }

                eff = NWScript.GetNextEffect(this);
            }

            return false;
        }

        public void RestoreFeats()
        {
            NWNX.Creature.RestoreFeats(this);
        }
        public void RestoreSpecialAbilities()
        {
            NWNX.Creature.RestoreSpecialAbilities(this);
        }
        public void RestoreSpells(int level = -1)
        {
            NWNX.Creature.RestoreSpells(this, level);
        }
        public void RestoreItems()
        {
            NWNX.Creature.RestoreItems(this);
        }


        public NWCreature(uint oid) : base(oid)
        {
            Equipped = new EquippedItems(this);
            Ability = new Abilities(this);
        }
    }
}
