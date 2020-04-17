using System;
using NWN.Events;
using static NWN.NWScript;
using static NWN.NWNX.Chat;

namespace NWN.MyCode {
  public class MyCode {
    /// <summary>
    ///   Hooks other events.
    /// </summary>
    public static void SubscribeToEvents() {
      // chat script
      RegisterChatScript("on_nwnx_chat");

      // nwnxee events
      HookAllNwnxEvents();

      // this is for shutdown to process correctly
      NWNX.Events.SubscribeEvent("MODULE_SHUTDOWN", "mod_shutdown");
      AppDomain.CurrentDomain.ProcessExit += (sender, args) => {
        NWNX.Events.SignalEvent("MODULE_SHUTDOWN", GetModule());
      };
    }

    public static void HookAllNwnxEvents() {
      AmmoEvent.BeforeReloadAmmo += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      AmmoEvent.AfterReloadAmmo += e => {
        //Log($"Reloaded {e.GetResult()} ({e.BaseItemID})");
      };

      CastSpellEvent.BeforeCastSpell += e => {
        //Log($"{e.Caster.Name} casting {e.SpellID}");
      };

      CastSpellEvent.AfterCastSpell += e => {
        //Log($"{e.Caster.Name} cast {e.SpellID}");
      };

      ClientConnectEvent.BeforeClientConnect += e => { };

      ClientConnectEvent.AfterClientConnect += e => {
        //Log($"{e.PlayerName} connected with {e.PlayerCDKey} from {e.PlayerIP}");
      };

      ClientDisconnectEvent.BeforeClientDisconnect += e => {
        // if player is not valid, ie disconnect before choosing a character
        if (e.Player == OBJECT_INVALID) return;
      };

      ClientDisconnectEvent.AfterClientDisconnect += e => { };

      CombatModeEvent.OnCombatModeOn += e => {
        // Log($"{e.Player.Name} entering {e.Mode}");
      };

      CombatModeEvent.OnCombatModeOff += e => {
        // Log($"{e.Player.Name} entered {e.Mode}");
      };

      CombatRoundEvent.BeforeCombatRoundStart += e => {
        // Log($"{e.Creature.Name} entering new round: {e.Target.Name}");
      };

      CombatRoundEvent.AfterCombatRoundStart += e => {
        // Log($"{e.Creature.Name} entered new round: {e.Target.Name}");
      };

      ContainerEvent.BeforeOpenItemInventory += e => {
        // Log($"{e.Owner.Name} opening {e.Container.Name}");
      };

      ContainerEvent.AfterOpenItemInventory += e => {
        // Log($"{e.Owner.Name} opened {e.Container.Name}");
      };

      ContainerEvent.BeforeCloseItemInventory += e => {
        // Log($"{e.Owner.Name} closeng {e.Container.Name}");
      };

      ContainerEvent.AfterCloseItemInventory += e => {
        //Log($"{e.Owner.Name} closed {e.Container.Name}");
      };

      EffectEvent.BeforeEffectApplied += e => {
        //Log($"Applying {e.EffectType} on {e.Target.Name}");
      };

      EffectEvent.AfterEffectApplied += e => {
        //Log($"Applied {e.EffectType} on {e.Target.Name}");
      };

      EffectEvent.BeforeEffectRemoved += e => {
        //Log($"Removing {e.EffectType} on {e.Target.Name}");
      };

      EffectEvent.AfterEffectRemoved += e => {
        //Log($"Removed {e.EffectType} on {e.Target.Name}");
      };

      ExamineEvent.BeforeExamineObject += e => {
        //Log($"{e.Player.Name} examining {e.ExaminedObject.Name}");
      };

      ExamineEvent.AfterExamineObject += e => {
        //Log($"{e.Player.Name} examined {e.ExaminedObject.Name}");
      };

      InventoryOpenEvent.BeforeInventoryOpen += e => {
        //Log($"{e.Player.Name} opening inventory");
      };

      InventoryOpenEvent.AfterInventoryOpen += e => {
        //Log($"{e.Player.Name} opened inventory");
      };

      InventorySelectPanelEvent.BeforeSelectPanel += e => {
        //Log($"{e.Player.Name} switching to inventory screen {e.SelectedPanelIndex}");
      };

      InventorySelectPanelEvent.AfterSelectPanel += e => {
        //Log($"{e.Player.Name} switched to inventory screen {e.SelectedPanelIndex}");
      };

      InventoryEvent.BeforeAddItem += e => {
        //Log($"Adding {e.Item.Name} to {e.Container.Name}");
      };

      InventoryEvent.AfterAddItem += e => {
        //Log($"Added {e.Item.Name} to {e.Container.Name}");
      };

      InventoryEvent.BeforeRemoveItem += e => {
        //Log($"Removing {e.Item.Name} to {e.Container.Name}");
      };

      InventoryEvent.AfterRemoveItem += e => {
        //Log($"Removed {e.Item.Name} to {e.Container.Name}");
      };

      EquipEvent.BeforeEquipItem += e => {
        //Log($"{e.Owner.Name} equipping {e.Item.Name} to {e.Slot}");
      };

      EquipEvent.AfterEquipItem += e => {
        //Log($"{e.Owner.Name} equipped {e.Item.Name} to {e.Slot}");
      };

      EquipEvent.BeforeUnequipItem += e => {
        //Log($"{e.Owner.Name} unequipping {e.Item.Name}");
      };

      EquipEvent.AfterUnequipItem += e => {
        //Log($"{e.Owner.Name} unequipped {e.Item.Name}");
      };

      ItemSplitEvent.BeforeItemSplit += e => {
        //Log($"{e.Player.Name} splitting {e.Amount} {e.Item.Name}");
      };

      ItemSplitEvent.AfterItemSplit += e => {
        //Log($"{e.Player.Name} split {e.Amount} {e.Item.Name}");
      };

      LearnScrollEvent.BeforeLearnScroll += e => {
        //Log($"{e.Creature.Name} learning {e.Scroll.Name}");
      };

      LearnScrollEvent.AfterLearnScroll += e => {
        //Log($"{e.Creature.Name} learned {e.Scroll.Name}");
      };

      LevellingEvent.BeforeLevelUp += e => {
        //Log($"{e.Creature.Name} levelling up.");
      };
      LevellingEvent.AfterLevelUp += e => {
        //Log($"{e.Creature.Name} levelled up.");
      };

      LevellingEvent.BeforeLevelDown += e => {
        //Log($"{e.Creature.Name} levelling down.");
      };

      LevellingEvent.AfterLevelDown += e => {
        //Log($"{e.Creature.Name} levelled down.");
      };

      WalkInputEvent.BeforeInputWaypoint += e => {
        //Log($"{e.Player.Name} wants to move to {e.Area.Name} ({e.Location.x}, {e.Location.y}) {e.Running}");
      };

      WalkInputEvent.AfterInputWaypoint += e => {
        //Log($"{e.Player.Name} moving to {e.Area.Name} ({e.Location.x}, {e.Location.y}) {e.Running}");
      };

      DetectionEvent.BeforeListen += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      DetectionEvent.AfterListen += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      DetectionEvent.BeforeSpot += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      DetectionEvent.AfterSpot += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      StealthEvent.BeforeEnterStealth += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      StealthEvent.AfterEnterStealth += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      StealthEvent.BeforeExitStealth += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      StealthEvent.AfterExitStealth += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TimingBarEvent.BeforeBarStart += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TimingBarEvent.AfterBarStart += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.BeforeTrapDisarm += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.AfterTrapDisarm += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.BeforeTrapEnter += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.AfterTrapEnter += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.BeforeTrapExamine += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.AfterTrapExamine += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.BeforeTrapFlag += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.AfterTrapFlag += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.BeforeTrapRecover += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.AfterTrapRecover += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.BeforeTrapSet += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      TrapEvent.AfterTrapSet += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      UseFeatEvent.BeforeUseFeat += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      UseFeatEvent.AfterUseFeat += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      UseItemEvent.BeforeUseItem += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      UseItemEvent.AfterUseItem += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      UseSkillEvent.BeforeUseSkill += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      UseSkillEvent.AfterUseSkill += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      UUIDConflictEvent.CollisionBefore += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      UUIDConflictEvent.CollisionAfter += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      WebHookEvent.OnWebHookFailure += e => {
        //Log($"Reloading {e.BaseItemID}");
      };

      WebHookEvent.OnWebHookSuccess += e => {
        //Log($"Reloading {e.BaseItemID}");
      };
    }
  }
}