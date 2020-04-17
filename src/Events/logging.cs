using System;

namespace NWN.Events {
	public class EventLogger {
		public static void Log(string msg) {
			Console.WriteLine(msg);
			NWScript.SendMessageToPC(NWScript.GetFirstPC(), $"<cCCC>{msg}</c>");
		}

        // put this back in to test multicast delegates
		public static void HookAllMessages() {
			AmmoEvent.BeforeReloadAmmo += e => Log($"Reloading {e.BaseItemID}");
			AmmoEvent.AfterReloadAmmo += e => Log($"Reloaded {e.GetResult()} ({e.BaseItemID})");

			CastSpellEvent.BeforeCastSpell += e => Log($"{e.Caster.Name} casting {e.SpellID}");
			CastSpellEvent.AfterCastSpell += e => Log($"{e.Caster.Name} cast {e.SpellID}");

			ClientConnectEvent.BeforeClientConnect += e =>
				Log($"{e.PlayerName} connecting with {e.PlayerCDKey} from {e.PlayerIP}");
			ClientConnectEvent.AfterClientConnect +=
				e => Log($"{e.PlayerName} connected with {e.PlayerCDKey} from {e.PlayerIP}");

			CombatModeEvent.OnCombatModeOn += e => Log($"{e.Player.Name} entering {e.Mode}");
			CombatModeEvent.OnCombatModeOff += e => Log($"{e.Player.Name} entered {e.Mode}");

			CombatRoundEvent.BeforeCombatRoundStart +=
				e => Log($"{e.Creature.Name} entering new round: {e.Target.Name}");
			CombatRoundEvent.AfterCombatRoundStart +=
				e => Log($"{e.Creature.Name} entered new round: {e.Target.Name}");

			ContainerEvent.BeforeOpenItemInventory += e => Log($"{e.Owner.Name} opening {e.Container.Name}");
			ContainerEvent.AfterOpenItemInventory += e => Log($"{e.Owner.Name} opened {e.Container.Name}");

			ContainerEvent.BeforeCloseItemInventory += e => Log($"{e.Owner.Name} closeng {e.Container.Name}");
			ContainerEvent.AfterCloseItemInventory += e => Log($"{e.Owner.Name} closed {e.Container.Name}");

			EffectEvent.BeforeEffectApplied += e => Log($"Applying {e.EffectType} on {e.Target.Name}");
			EffectEvent.AfterEffectApplied += e => Log($"Applied {e.EffectType} on {e.Target.Name}");

			EffectEvent.BeforeEffectRemoved += e => Log($"Removing {e.EffectType} on {e.Target.Name}");
			EffectEvent.AfterEffectRemoved += e => Log($"Removed {e.EffectType} on {e.Target.Name}");

			ExamineEvent.BeforeExamineObject += e => Log($"{e.Player.Name} examining {e.ExaminedObject.Name}");
			ExamineEvent.AfterExamineObject += e => Log($"{e.Player.Name} examined {e.ExaminedObject.Name}");

			InventoryOpenEvent.BeforeInventoryOpen += e => Log($"{e.Player.Name} opening inventory");
			InventoryOpenEvent.AfterInventoryOpen += e => Log($"{e.Player.Name} opened inventory");

			InventorySelectPanelEvent.BeforeSelectPanel += e =>
				Log($"{e.Player.Name} switching to inventory screen {e.SelectedPanelIndex}");
			InventorySelectPanelEvent.AfterSelectPanel += e =>
				Log($"{e.Player.Name} switched to inventory screen {e.SelectedPanelIndex}");

			InventoryEvent.BeforeAddItem += e => Log($"Adding {e.Item.Name} to {e.Container.Name}");
			InventoryEvent.AfterAddItem += e => Log($"Added {e.Item.Name} to {e.Container.Name}");

			InventoryEvent.BeforeRemoveItem += e => Log($"Removing {e.Item.Name} to {e.Container.Name}");
			InventoryEvent.AfterRemoveItem += e => Log($"Removed {e.Item.Name} to {e.Container.Name}");

			EquipEvent.BeforeEquipItem += e => Log($"{e.Owner.Name} equipping {e.Item.Name} to {e.Slot}");
			EquipEvent.AfterEquipItem += e => Log($"{e.Owner.Name} equipped {e.Item.Name} to {e.Slot}");

			EquipEvent.BeforeUnequipItem += e => Log($"{e.Owner.Name} unequipping {e.Item.Name}");
			EquipEvent.AfterUnequipItem += e => Log($"{e.Owner.Name} unequipped {e.Item.Name}");

			ItemSplitEvent.BeforeItemSplit += e => Log($"{e.Player.Name} splitting {e.Amount} {e.Item.Name}");
			ItemSplitEvent.AfterItemSplit += e => Log($"{e.Player.Name} split {e.Amount} {e.Item.Name}");

			LearnScrollEvent.BeforeLearnScroll += e => Log($"{e.Creature.Name} learning {e.Scroll.Name}");
			LearnScrollEvent.AfterLearnScroll += e => Log($"{e.Creature.Name} learned {e.Scroll.Name}");

			LevellingEvent.BeforeLevelUp += e => Log($"{e.Creature.Name} levelling up.");
			LevellingEvent.AfterLevelUp += e => Log($"{e.Creature.Name} levelled up.");

			LevellingEvent.BeforeLevelDown += e => Log($"{e.Creature.Name} levelling down.");
			LevellingEvent.AfterLevelDown += e => Log($"{e.Creature.Name} levelled down.");

			WalkInputEvent.BeforeInputWaypoint += e =>
				Log($"{e.Player.Name} wants to move to {e.Area.Name} ({e.Location.x}, {e.Location.y}) {e.Running}");
			WalkInputEvent.AfterInputWaypoint += e =>
				Log($"{e.Player.Name} moving to {e.Area.Name} ({e.Location.x}, {e.Location.y}) {e.Running}");
		}
	}
}