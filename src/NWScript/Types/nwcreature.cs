using System;
using System.Collections.Generic;
using System.Linq;
using NWN.Enums;
using NWN.Enums.Associate;
using NWN.Enums.Creature;
using NWN.NWNX;

namespace NWN {
  public class NWCreature : NWObject {
    public Abilities Ability;

    public EquippedItems Equipped;


    public NWCreature(uint oid) : base(oid) {
      Equipped = new EquippedItems(this);
      Ability = new Abilities(this);
    }

    public override bool IsValidType => ObjectType == ObjectType.Creature;

    public virtual int Age => NWScript.GetAge(this);

    public string OriginalFirstName {
      get => Creature.GetOriginalName(this, false);
      set => Creature.SetOriginalName(this, value, false);
    }

    public string OriginalLastName {
      get => Creature.GetOriginalName(this, true);
      set => Creature.SetOriginalName(this, value, true);
    }

    public virtual float ChallengeRating {
      get => NWScript.GetChallengeRating(this);
      set => Creature.SetChallengeRating(this, value);
    }

    public virtual ClassType Class1 {
      get => (ClassType) NWScript.GetClassByPosition(1, this);
      set => Creature.SetClassByPosition(this, 0, value);
    }

    public virtual ClassType Class2 {
      get => (ClassType) NWScript.GetClassByPosition(2, this);
      set => Creature.SetClassByPosition(this, 2, value);
    }

    public virtual ClassType Class3 {
      get => (ClassType) NWScript.GetClassByPosition(3, this);
      set => Creature.SetClassByPosition(this, 3, value);
    }

    public virtual bool IsCommandable {
      get => NWScript.GetCommandable(this);
      set => NWScript.SetCommandable(value, this);
    }

    // TODO-enumize
    public virtual PhenoType Phenotype {
      get => NWScript.GetPhenoType(this);
      set => NWScript.SetPhenoType(value, this);
    }

    public virtual string Deity {
      get => NWScript.GetDeity(this);
      set => NWScript.SetDeity(this, value);
    }

    public virtual string SubRace {
      get => NWScript.GetSubRace(this);
      set => NWScript.SetSubRace(this, value);
    }

    public virtual RacialType RacialType {
      get => NWScript.GetRacialType(this);
      set => Creature.SetRacialType(this, value);
    }

    public virtual int ArmorClass => NWScript.GetAC(this);

    public virtual int BaseAC {
      get => Creature.GetBaseAC(this);
      set => Creature.SetBaseAC(this, value);
    }

    public virtual MovementRate MovementRate {
      get => (MovementRate) NWScript.GetMovementRate(this);
      set => Creature.SetMovementRate(this, value);
    }

    public virtual float MovementRateFactor {
      get => Creature.GetMovementRateFactor(this);
      set => Creature.SetMovementRateFactor(this, value);
    }

    public virtual int Soundset {
      get => Creature.GetSoundset(this);
      set => Creature.SetSoundset(this, value);
    }

    public virtual Gender Gender {
      get => (Gender) NWScript.GetGender(this);
      set => Creature.SetGender(this, value);
    }

    public virtual bool IsResting => NWScript.GetIsResting(this);
    public virtual bool IsPlayableRace => NWScript.GetIsPlayableRacialType(this);

    public virtual float TotalWeight => NWScript.GetWeight(this) * 0.1f;

    public virtual Size Size {
      get => (Size) NWScript.GetCreatureSize(this);
      set => Creature.SetSize(this, value);
    }

    public virtual int Gold {
      get => NWScript.GetGold(this);
      set => Creature.SetGold(this, value);
    }

    public virtual NWObject AttackTarget => NWScript.GetAttackTarget(this).AsObject();
    public virtual SpecialAttack LastAttackType => NWScript.GetLastAttackType(this);
    public virtual CombatMode LastAttackMode => NWScript.GetLastAttackMode(this);

    public virtual int XP {
      get => NWScript.GetXP(this);
      set => NWScript.SetXP(this, value);
    }

    public virtual AILevel AILevel {
      get => NWScript.GetAILevel(this);
      set => NWScript.SetAILevel(this, value);
    }

    public bool IsInCombat => NWScript.GetIsInCombat(this);

    public virtual bool IsDead => NWScript.GetIsDead(this);
    public virtual bool IsPC => NWScript.GetIsPC(this);
    public virtual bool IsDM => NWScript.GetIsDM(this);

    public virtual bool IsPossessedFamiliar => NWScript.GetIsPossessedFamiliar(this) == 1;

    public virtual bool IsDMPossessed => NWScript.GetIsDMPossessed(this);
    public virtual NWCreature Master => NWScript.GetMaster(this).AsCreature();
    public virtual Command LastCommandFromMaster => (Command) NWScript.GetLastAssociateCommand(this);
    public virtual NWItem LastWeaponUsed => NWScript.GetLastWeaponUsed(this).AsItem();
    public virtual NWObject LastDamager => NWScript.GetLastDamager(this).AsObject();
    public virtual NWTrappable LastTrapDetected => NWScript.GetLastTrapDetected(this).AsTrappable();

    public int SpellResistance {
      get => NWScript.GetSpellResistance(this);
      set => Creature.SetSpellResistance(this, value);
    }

    public int SkillPointsRemaining {
      get => Creature.GetSkillPointsRemaining(this);
      set => Creature.SetSkillPointsRemaining(this, value);
    }

    // Feats stuff..
    public int FeatCount => Creature.GetFeatCount(this);

    public virtual IEnumerable<Feat> Feats {
      get {
        var count = FeatCount;
        for (var i = 0; i < count; i++)
          yield return GetFeat(i);
      }
    }

    public virtual void ClearAllActions(bool clearCombatState = false) {
      AssignCommand(() => { NWScript.ClearAllActions(clearCombatState); });
    }

    public virtual void FloatingText(string text, bool displayToFaction = false) {
      NWScript.FloatingTextStringOnCreature(text, this, displayToFaction);
    }

    public NWItem GetPossessedItem(string itemTag) {
      return NWScript.GetItemPossessedBy(this, itemTag).AsItem();
    }

    public bool HasFeat(Feat feat) {
      return NWScript.GetHasFeat((int) feat, this);
    }

    public void AddFeat(Feat feat) {
      Creature.AddFeat(this, feat);
    }

    public void AddFeatByLevel(Feat feat, int level) {
      Creature.AddFeatByLevel(this, feat, level);
    }

    public void RemoveFeat(Feat feat) {
      Creature.RemoveFeat(this, feat);
    }

    public bool KnowsFeat(Feat feat) {
      return Creature.GetKnowsFeat(this, feat);
    }

    public Feat GetFeat(int index) {
      return Creature.GetFeatByIndex(this, index);
    }

    public bool MeetsFeatRequirements(Feat feat) {
      return Creature.GetMeetsFeatRequirements(this, feat);
    }

    public int GetFeatRemainingUses(Feat feat) {
      return Creature.GetFeatRemainingUses(this, feat);
    }

    public int GetFeatTotalUses(Feat feat) {
      return Creature.GetFeatTotalUses(this, feat);
    }

    public void SetFeatRemainingUses(Feat feat, int uses) {
      Creature.SetFeatRemainingUses(this, feat, uses);
    }

    public bool HasSkill(Skill skill) {
      return NWScript.GetHasSkill(skill, this);
    }

    public int GetSkillRank(Skill skill, bool baseOnly = false) {
      return NWScript.GetSkillRank(skill, this, baseOnly);
    }

    public bool GetObjectSeen(NWObject target) {
      return NWScript.GetObjectSeen(target, this);
    }

    public bool GetObjectHeard(NWObject target) {
      return NWScript.GetObjectHeard(target, this);
    }

    public void SummonFamiliar() {
      NWScript.SummonFamiliar(this);
    }

    public void SummonAnimalCompanion() {
      NWScript.SummonAnimalCompanion(this);
    }

    public bool HasAnyEffect(params int[] effectIDs) {
      var eff = NWScript.GetFirstEffect(this);
      while (NWScript.GetIsEffectValid(eff) == 1) {
        if (effectIDs.Contains(NWScript.GetEffectType(eff))) return true;
        eff = NWScript.GetNextEffect(this);
      }

      return false;
    }

    public void RestoreFeats() {
      Creature.RestoreFeats(this);
    }

    public void RestoreSpecialAbilities() {
      Creature.RestoreSpecialAbilities(this);
    }

    public void RestoreSpells(int level = -1) {
      Creature.RestoreSpells(this, level);
    }

    public void RestoreItems() {
      Creature.RestoreItems(this);
    }

    public class Abilities {
      private readonly NWCreature owner;

      public Abilities(NWCreature owner) {
        this.owner = owner;
      }

      public AbilityScore this[Ability index] => new AbilityScore(index, owner);

      public class AbilityScore {
        private readonly Ability ability;
        private readonly NWCreature owner;

        public AbilityScore(Ability ability, NWCreature owner) {
          this.ability = ability;
          this.owner = owner;
        }

        public int Total => NWScript.GetAbilityScore(owner, ability);
        public int Base => NWScript.GetAbilityScore(owner, ability, true);
        public int Modifier => NWScript.GetAbilityModifier(ability, owner);

        public int Raw {
          get => Creature.GetRawAbilityScore(owner, ability);
          set => Creature.SetRawAbilityScore(owner, ability, value);
        }
      }
    }

    public class EquippedItems {
      private readonly NWCreature owner;

      public EquippedItems(NWCreature owner) {
        this.owner = owner;
      }

      public NWItem this[InventorySlot index] => NWScript.GetItemInSlot(index, owner).AsItem();

      public virtual IEnumerable<NWItem> All {
        get {
          foreach (var currentSlot in Enum.GetValues(typeof(InventorySlot)))
            yield return NWScript.GetItemInSlot((InventorySlot) currentSlot!, owner).AsItem();
        }
      }
    }
  }
}