using System;
using NWN.NWNX.Enum;

namespace NWN.NWNX {
	public class Player {
		private const string PLUGIN_NAME = "NWNX_Player";

		// Force display placeable examine window for player
		// If used on a placeable in a different area than the player, the portait will not be shown.
		public static void ForcePlaceableExamineWindow(NWObject player, NWObject placeable) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "ForcePlaceableExamineWindow");
			Internal.NativeFunctions.nwnxPushObject(placeable);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Force opens the target object's inventory for the player.
		// A few notes about this function:
		// - If the placeable is in a different area than the player, the portrait will not be shown
		// - The placeable's open/close animations will be played
		// - Clicking the 'close' button will cause the player to walk to the placeable;
		//     If the placeable is in a different area, the player will just walk to the edge
		//     of the current area and stop. This action can be cancelled manually.
		// - Walking will close the placeable automatically.
		public static void ForcePlaceableInventoryWindow(NWObject player, NWObject placeable) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "ForcePlaceableInventoryWindow");
			Internal.NativeFunctions.nwnxPushObject(placeable);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Starts displaying a timing bar.
		// Will run a script at the end of the timing bar, if specified.
		public static void StartGuiTimingBar(NWObject player, float seconds, string script = "",
			TimingBarType type = TimingBarType.Custom) {
			if (NWScript.GetLocalInt(player, "NWNX_PLAYER_GUI_TIMING_ACTIVE") == 1) return;
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "StartGuiTimingBar");
			Internal.NativeFunctions.nwnxPushInt((int) type);
			Internal.NativeFunctions.nwnxPushFloat(seconds);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();

			var id = NWScript.GetLocalInt(player, "NWNX_PLAYER_GUI_TIMING_ID") + 1;
			NWScript.SetLocalInt(player, "NWNX_PLAYER_GUI_TIMING_ACTIVE", id);
			NWScript.SetLocalInt(player, "NWNX_PLAYER_GUI_TIMING_ID", id);

			NWScript.DelayCommand(seconds, () => StopGuiTimingBar(player, script, id));
		}

		// Stops displaying a timing bar.
		// Runs a script if specified.
		public static void StopGuiTimingBar(NWObject creature, string script, int id) {
			var activeId = NWScript.GetLocalInt(creature, "NWNX_PLAYER_GUI_TIMING_ACTIVE");
			// Either the timing event was never started, or it already finished.
			if (activeId == 0) return;
			// If id != -1, we ended up here through DelayCommand. Make sure it's for the right ID
			if (id != -1 && id != activeId) return;
			NWScript.DeleteLocalInt(creature, "NWNX_PLAYER_GUI_TIMING_ACTIVE");
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "StopGuiTimingBar");
			Internal.NativeFunctions.nwnxPushObject(creature);
			Internal.NativeFunctions.nwnxCallFunction();
			if (!string.IsNullOrWhiteSpace(script)) NWScript.ExecuteScript(script, creature);
		}

		// Stops displaying a timing bar.
		// Runs a script if specified.
		public static void StopGuiTimingBar(NWObject player, string script) {
			StopGuiTimingBar(player, script, -1);
		}

		// Sets whether the player should always walk when given movement commands.
		// If true, clicking on the ground or using WASD will trigger walking instead of running.
		public static void SetAlwaysWalk(NWObject player, int bWalk) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetAlwaysWalk");
			Internal.NativeFunctions.nwnxPushInt(bWalk);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Gets the player's quickbar slot info
		public static QuickBarSlot GetQuickBarSlot(NWObject player, int slot) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetQuickBarSlot");
			var qbs = new QuickBarSlot();
			Internal.NativeFunctions.nwnxPushInt(slot);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
			qbs.Associate = UIntToObject.AsCreature(Internal.NativeFunctions.nwnxPopObject());
			qbs.AssociateType = Internal.NativeFunctions.nwnxPopInt();
			qbs.DomainLevel = Internal.NativeFunctions.nwnxPopInt();
			qbs.MetaType = Internal.NativeFunctions.nwnxPopInt();
			qbs.INTParam1 = Internal.NativeFunctions.nwnxPopInt();
			qbs.ToolTip = Internal.NativeFunctions.nwnxPopString();
			qbs.CommandLine = Internal.NativeFunctions.nwnxPopString();
			qbs.CommandLabel = Internal.NativeFunctions.nwnxPopString();
			qbs.Resref = Internal.NativeFunctions.nwnxPopString();
			qbs.MultiClass = Internal.NativeFunctions.nwnxPopInt();
			qbs.ObjectType = (QuickBarSlotType) Internal.NativeFunctions.nwnxPopInt();
			qbs.SecondaryItem = UIntToObject.AsItem(Internal.NativeFunctions.nwnxPopObject());
			qbs.Item = UIntToObject.AsItem(Internal.NativeFunctions.nwnxPopObject());
			return qbs;
		}

		// Sets a player's quickbar slot
		public static void SetQuickBarSlot(NWObject player, int slot, QuickBarSlot qbs) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetQuickBarSlot");
			Internal.NativeFunctions.nwnxPushObject(qbs.Item!);
			Internal.NativeFunctions.nwnxPushObject(qbs.SecondaryItem!);
			Internal.NativeFunctions.nwnxPushInt((int) qbs.ObjectType);
			Internal.NativeFunctions.nwnxPushInt(qbs.MultiClass);
			Internal.NativeFunctions.nwnxPushString(qbs.Resref!);
			Internal.NativeFunctions.nwnxPushString(qbs.CommandLabel!);
			Internal.NativeFunctions.nwnxPushString(qbs.CommandLine!);
			Internal.NativeFunctions.nwnxPushString(qbs.ToolTip!);
			Internal.NativeFunctions.nwnxPushInt(qbs.INTParam1);
			Internal.NativeFunctions.nwnxPushInt(qbs.MetaType);
			Internal.NativeFunctions.nwnxPushInt(qbs.DomainLevel);
			Internal.NativeFunctions.nwnxPushInt(qbs.AssociateType);
			Internal.NativeFunctions.nwnxPushObject(qbs.Associate!);
			Internal.NativeFunctions.nwnxPushInt(slot);
			Internal.NativeFunctions.nwnxPushObject(player!);
			Internal.NativeFunctions.nwnxCallFunction();
		}


		// Get the name of the .bic file associated with the player's character.
		public static string GetBicFileName(NWObject player) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetBicFileName");
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
			return Internal.NativeFunctions.nwnxPopString();
		}

		// Plays the VFX at the target position in current area for the given player only
		public static void ShowVisualEffect(NWObject player, int effectId, Vector position) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "ShowVisualEffect");
			Internal.NativeFunctions.nwnxPushFloat(position.x);
			Internal.NativeFunctions.nwnxPushFloat(position.y);
			Internal.NativeFunctions.nwnxPushFloat(position.z);
			Internal.NativeFunctions.nwnxPushInt(effectId);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Changes the nighttime music track for the given player only
		public static void MusicBackgroundChangeTimeToggle(NWObject player, int track, bool nNight) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "ChangeBackgroundMusic");
			Internal.NativeFunctions.nwnxPushInt(track);
			Internal.NativeFunctions.nwnxPushInt(nNight ? 1 : 0); // bool day = false
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Toggle the background music for the given player only
		public static void MusicBackgroundToggle(NWObject player, bool nOn) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "PlayBackgroundMusic");
			Internal.NativeFunctions.nwnxPushInt(nOn ? 1 : 0); // bool play = false
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Changes the battle music track for the given player only
		public static void MusicBattleChange(NWObject player, int track) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "ChangeBattleMusic");
			Internal.NativeFunctions.nwnxPushInt(track);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Toggle the background music for the given player only
		public static void MusicBattleToggle(NWObject player, bool nOn) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "PlayBattleMusic");
			Internal.NativeFunctions.nwnxPushInt(nOn ? 1 : 0);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Play a sound at the location of target for the given player only
		// If target is OBJECT_INVALID the sound will play at the location of the player
		public static void PlaySound(NWObject player, string sound, NWObject target) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "PlaySound");
			Internal.NativeFunctions.nwnxPushObject(target);
			Internal.NativeFunctions.nwnxPushString(sound);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Toggle a placeable's usable flag for the given player only
		public static void SetPlaceableUseable(NWObject player, NWObject placeable, bool isUseable) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetPlaceableUsable");
			Internal.NativeFunctions.nwnxPushInt(isUseable ? 1 : 0);
			Internal.NativeFunctions.nwnxPushObject(placeable);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Override player's rest duration
		// Duration is in milliseconds, 1000 = 1 second
		// Minimum duration of 10ms
		// -1 clears the override
		public static void SetRestDuration(NWObject player, int duration) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetRestDuration");
			Internal.NativeFunctions.nwnxPushInt(duration);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Apply visualeffect to target that only player can see
		// Note: Only works with instant effects: VFX_COM_*, VFX_FNF_*, VFX_IMP_*
		public static void ApplyInstantVisualEffectToObject(NWObject player, NWObject target, int visualeffect) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "ApplyInstantVisualEffectToObject");
			Internal.NativeFunctions.nwnxPushInt(visualeffect);
			Internal.NativeFunctions.nwnxPushObject(target);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Refreshes the players character sheet
		// Note: You may need to use DelayCommand if you're manipulating values
		// through nwnx and forcing a UI refresh, 0.5s seemed to be fine
		public static void UpdateCharacterSheet(NWObject player) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "UpdateCharacterSheet");
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Allows player to open target's inventory
		// Target must be a creature or another player
		// Note: only works if player and target are in the same area
		public static void OpenInventory(NWObject player, NWObject target, bool open = true) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "OpenInventory");
			Internal.NativeFunctions.nwnxPushInt(open ? 1 : 0);
			Internal.NativeFunctions.nwnxPushObject(target);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Get player's area exploration state
		public static string GetAreaExplorationState(NWObject player, NWObject area) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetAreaExplorationState");
			Internal.NativeFunctions.nwnxPushObject(area);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
			return Internal.NativeFunctions.nwnxPopString();
		}

		// Set player's area exploration state (str is an encoded string obtained with NWNX_Player_GetAreaExplorationState)
		public static void SetAreaExplorationState(NWObject player, NWObject area, string str) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetAreaExplorationState");
			Internal.NativeFunctions.nwnxPushString(str);
			Internal.NativeFunctions.nwnxPushObject(area);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Override oPlayer's rest animation to nAnimation
		//
		// NOTE: nAnimation does not take ANIMATION_LOOPING_* or ANIMATION_FIREFORGET_* constants
		//       Use NWNX_Consts_TranslateNWScriptAnimation() in nwnx_consts.nss to get their NWNX equivalent
		//       -1 to clear the override
		public static void SetRestAnimation(NWObject oPlayer, int nAnimation) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetRestAnimation");
			Internal.NativeFunctions.nwnxPushInt(nAnimation);
			Internal.NativeFunctions.nwnxPushObject(oPlayer);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Override a visual transform on the given object that only oPlayer will see.
		// - oObject can be any valid Creature, Placeable, Item or Door.
		// - nTransform is one of OBJECT_VISUAL_TRANSFORM_* or -1 to remove the override
		// - fValue depends on the transformation to apply.
		public static void SetObjectVisualTransformOverride(NWObject oPlayer, NWObject oObject, int nTransform,
			float fValue) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetObjectVisualTransformOverride");
			Internal.NativeFunctions.nwnxPushFloat(fValue);
			Internal.NativeFunctions.nwnxPushInt(nTransform);
			Internal.NativeFunctions.nwnxPushObject(oObject);
			Internal.NativeFunctions.nwnxPushObject(oPlayer);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Apply a looping visualeffect to target that only player can see
		// visualeffect: VFX_DUR_*, call again to remove an applied effect
		//               -1 to remove all effects
		//
		// Note: Only really works with looping effects: VFX_DUR_*
		//       Other types *kind* of work, they'll play when reentering the area and the object is in view
		//       or when they come back in view range.
		public static void ApplyLoopingVisualEffectToObject(NWObject player, NWObject target, int visualeffect) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "ApplyLoopingVisualEffectToObject");
			Internal.NativeFunctions.nwnxPushInt(visualeffect);
			Internal.NativeFunctions.nwnxPushObject(target);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Override the name of placeable for player only
		// "" to clear the override
		public static void SetPlaceableNameOverride(NWObject player, NWObject placeable, string name) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetPlaceableNameOverride");
			Internal.NativeFunctions.nwnxPushString(name);
			Internal.NativeFunctions.nwnxPushObject(placeable);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Gets whether a quest has been completed by a player
		// Returns -1 if they don't have the journal entry
		public static int GetQuestCompleted(NWObject player, string sQuestName) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetQuestCompleted");
			Internal.NativeFunctions.nwnxPushString(sQuestName);
			Internal.NativeFunctions.nwnxPushObject(player);
			Internal.NativeFunctions.nwnxCallFunction();
			return Internal.NativeFunctions.nwnxPopInt();
		}

		// This will require storing the PC's cd key or community name (depending on how you store in your vault)
		// and bic_filename along with routinely updating their location in some persistent method like OnRest,
		// OnAreaEnter and OnClentExit.
		//
		// Place waypoints on module load representing where a PC should start
		public static void SetPersistentLocation(string sCDKeyOrCommunityName, string sBicFileName, NWObject oWP,
			bool bFirstConnectOnly = true) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetPersistentLocation");
			Internal.NativeFunctions.nwnxPushInt(bFirstConnectOnly ? 1 : 0);
			Internal.NativeFunctions.nwnxPushObject(oWP);
			Internal.NativeFunctions.nwnxPushString(sBicFileName);
			Internal.NativeFunctions.nwnxPushString(sCDKeyOrCommunityName);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Force an item name to be updated.
		// This is a workaround for bug that occurs when updating item names in open containers.
		public static void UpdateItemName(NWObject oPlayer, NWObject oItem) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "UpdateItemName");
			Internal.NativeFunctions.nwnxPushObject(oItem);
			Internal.NativeFunctions.nwnxPushObject(oPlayer);
			Internal.NativeFunctions.nwnxCallFunction();
		}

		// Possesses a creature by temporarily making them a familiar
		// This command allows a PC to possess an NPC by temporarily adding them as a familiar. It will work
		// if the player already has an existing familiar. The creatures must be in the same area. Unpossession can be
		// done with the regular @nwn{UnpossessFamiliar} commands.
		// The possessed creature will send automap data back to the possessor.
		// If you wish to prevent this you may wish to use NWNX_Player_GetAreaExplorationState() and
		// NWNX_Player_SetAreaExplorationState() before and after the possession.
		// The possessing creature will be left wherever they were when beginning the possession. You may wish
		// to use @nwn{EffectCutsceneImmobilize} and @nwn{EffectCutsceneGhost} to hide them.
		public static bool PossessCreature(NWObject oPossessor, NWObject oPossessed, bool bMindImmune = true,
			bool bCreateDefaultQB = false) {
			Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "PossessCreature");
			Internal.NativeFunctions.nwnxPushInt(bCreateDefaultQB ? 1 : 0);
			Internal.NativeFunctions.nwnxPushInt(bMindImmune ? 1 : 0);
			Internal.NativeFunctions.nwnxPushObject(oPossessed);
			Internal.NativeFunctions.nwnxPushObject(oPossessor);
			Internal.NativeFunctions.nwnxCallFunction();
			return Convert.ToBoolean(Internal.NativeFunctions.nwnxPopInt());
		}
	}
}