using NWN.Enums;
using System;

namespace NWN.Events {
    public delegate void ModuleEventDelegate();

    public delegate void PlayerEventDelegate(NWPlayer pc);

    public delegate void ItemEventDelegate(NWItem item);

    public delegate void ItemLostEventDelegate(NWItem item, NWCreature lostBy);

    public delegate void AreaEventDelegate(NWArea area); //, NWCreature subject);

    public class PlayerChatEvent {
        public delegate void EventDelegate(PlayerChatEvent e);

        public PlayerChatEvent() {
            Speaker = NWScript.GetPCChatSpeaker().AsPlayer();
            OriginalText = NWScript.GetPCChatMessage();
            OriginalVolume = NWScript.GetPCChatVolume();
        }

        public NWPlayer Speaker { get; protected set; }
        public string? OriginalText { get; protected set; }
        public string? ModifiedText { get; protected set; }
        public int OriginalVolume { get; protected set; }
        public int ModifiedVolume { get; protected set; }

        public void ModifyText(string newText) {
            ModifiedText = newText;
            NWScript.SetPCChatMessage(newText);
        }

        public void ModifyVolume(TalkVolume newVolume) {
            ModifiedVolume = (int)newVolume;
            NWScript.SetPCChatVolume(newVolume);
        }
    }

    public class ItemActivatedEvent {
        public delegate void EventDelegate(ItemActivatedEvent e);

        public ItemActivatedEvent() {
            Item = NWScript.GetItemActivated().AsItem();
            Activator = NWScript.GetItemActivator().AsCreature();
            TargetLocation = NWScript.GetItemActivatedTargetLocation();
            TargetObject = NWScript.GetItemActivatedTarget().AsObject();
        }

        public NWItem Item { get; }
        public NWCreature Activator { get; }
        public Location TargetLocation { get; }
        public NWObject TargetObject { get; }
    }

    public class BuiltinEvents {
        public static ModuleEventDelegate OnModuleShutdown = delegate { };
        public static ModuleEventDelegate OnModulePreload = delegate { };
        public static ModuleEventDelegate OnModuleLoad = delegate { };
        public static ModuleEventDelegate OnModuleReload = delegate { };
        public static ModuleEventDelegate OnModuleStart = delegate { };
        public static ModuleEventDelegate OnModuleHeartbeat = delegate { };
        public static ModuleEventDelegate OnClientEnter = delegate { };
        public static ModuleEventDelegate OnClientLeave = delegate { };

        public static PlayerEventDelegate OnCancelCutscene = delegate { };
        public static PlayerEventDelegate OnPlayerDeath = delegate { };
        public static PlayerEventDelegate OnPlayerDying = delegate { };
        public static PlayerEventDelegate OnPlayerLevelUp = delegate { };
        public static PlayerEventDelegate OnPlayerRest = delegate { };
        public static PlayerEventDelegate OnPlayerRespawn = delegate { };
        public static PlayerEventDelegate OnPlayerHeartbeat = delegate { };
        public static PlayerChatEvent.EventDelegate OnPlayerChat = delegate { };

        public static ItemEventDelegate OnItemEquipped = delegate { };
        public static ItemEventDelegate OnItemUnequipped = delegate { };
        public static ItemEventDelegate OnItemAcquired = delegate { };
        public static ItemLostEventDelegate OnItemLost = delegate { };
        public static ItemActivatedEvent.EventDelegate OnItemActivated = delegate { };

        public static AreaEventDelegate OnAreaEnter = delegate { };
        public static AreaEventDelegate OnAreaExit = delegate { };
    }

    public class EventHandlers {
        private static bool _isConfigured;

        [NWNEventHandler("mod_shutdown")]
        // just an example
        public static void OnModuleShutdown(string script) {
            var players = NWModule.Module.Players;
            if (players == null) return;
            foreach (var player in players) {
                player.Boot("Server shutting down!");
                Console.WriteLine($"kicked {player.PlayerName}");
            }

            Console.WriteLine("SHUTDOWN");
        }

        [NWNEventHandler("mod_preload")]
        public static void OnModulePreload(string script) {
        }

        [NWNEventHandler("on_module_load")]
        public static void OnModuleLoad(string script) {
            if (_isConfigured) {
                BuiltinEvents.OnModuleReload();
                return;
            }

            // an example of calling your own code
            MyCode.MyCode.SubscribeToEvents();

            var module = NWModule.Module;
            module.Scripts![EventScript.Module_OnClientEnter] = "mod-client-enter";
            module.Scripts![EventScript.Module_OnClientExit] = "mod-client-exit";
            module.Scripts![EventScript.Module_OnHeartbeat] = "mod-heartbeat";
            module.Scripts![EventScript.Module_OnAcquireItem] = "mod-acquire";
            module.Scripts![EventScript.Module_OnActivateItem] = "mod-activate";
            module.Scripts![EventScript.Module_OnEquipItem] = "mod-equip";
            module.Scripts![EventScript.Module_OnUnequipItem] = "mod-unequip";
            module.Scripts![EventScript.Module_OnLoseItem] = "mod-loseitem";
            module.Scripts![EventScript.Module_OnModuleStart] = "mod-start";
            module.Scripts![EventScript.Module_OnPlayerCancelCutscene] = "mod-cutscene";
            module.Scripts![EventScript.Module_OnPlayerChat] = "mod-pc-chat";
            module.Scripts![EventScript.Module_OnPlayerDeath] = "mod-pc-death";
            module.Scripts![EventScript.Module_OnPlayerDying] = "mod-pc-dying";
            module.Scripts![EventScript.Module_OnPlayerLevelUp] = "mod-pc-levelup";
            module.Scripts![EventScript.Module_OnPlayerRest] = "mod-pc-rest";
            module.Scripts![EventScript.Module_OnRespawnButtonPressed] = "mod-pc-respawn";

            foreach (var area in module.Areas) {
                area.Scripts![EventScript.Area_OnEnter] = "area-enter";
                area.Scripts![EventScript.Area_OnExit] = "area-exit";
                area.Scripts![EventScript.Area_OnHeartbeat] = "area-heartbeat";
                area.Scripts![EventScript.Area_OnUserDefined] = "area-userDefined";
            }

            _isConfigured = true;
            BuiltinEvents.OnModuleLoad();
        }

        [NWNEventHandler("mod-heartbeat")]
        public static void OnModuleHeartBeat(string script) {
            var module = NWScript.OBJECT_SELF;
            BuiltinEvents.OnModuleHeartbeat();
        }

        [NWNEventHandler("mod-start")]
        public static void OnModuleStart(string script) {
            BuiltinEvents.OnModuleStart();
        }

        [NWNEventHandler("mod-client-enter")]
        public static void OnClientEnter(string script) {
            BuiltinEvents.OnClientEnter();
        }

        [NWNEventHandler("mod-client-exit")]
        public static void OnClientLeave(string script) {
            var pc = NWScript.GetExitingObject().AsPlayer();

            BuiltinEvents.OnClientLeave();
        }

        [NWNEventHandler("default")]
        public static void OnDefault(string script) {
            BuiltinEvents.OnPlayerHeartbeat(Internal.OBJECT_SELF.AsPlayer());
        }

        [NWNEventHandler("mod-cutscene")]
        public static void OnCancelCutscene(string script) {
            BuiltinEvents.OnCancelCutscene(NWScript.GetLastPCToCancelCutscene().AsPlayer());
        }

        [NWNEventHandler("mod-pc-death")]
        public static void OnPlayerDeath(string script) {
            BuiltinEvents.OnPlayerDeath(NWScript.GetLastPlayerDied().AsPlayer());
        }

        [NWNEventHandler("mod-pc-dying")]
        public static void OnPlayerDying(string script) {
            BuiltinEvents.OnPlayerDying(NWScript.GetLastPlayerDying().AsPlayer());
        }

        [NWNEventHandler("mod-pc-levelup")]
        public static void OnPlayerLevelUp(string script) {
            BuiltinEvents.OnPlayerLevelUp(NWScript.GetPCLevellingUp().AsPlayer());
        }

        [NWNEventHandler("mod-pc-rest")]
        public static void OnPlayerRest(string script) {
            BuiltinEvents.OnPlayerRest(NWScript.GetLastPCRested().AsPlayer());
        }

        [NWNEventHandler("mod-pc-respawn")]
        public static void OnPlayerRespawn(string script) {
            BuiltinEvents.OnPlayerRespawn(NWScript.GetLastRespawnButtonPresser().AsPlayer());
        }

        [NWNEventHandler("mod-pc-chat")]
        public static void OnPlayerChat(string script) {
            BuiltinEvents.OnPlayerChat(new PlayerChatEvent());
        }

        [NWNEventHandler("mod-acquire")]
        public static void OnItemAcquired(string script) {
            var item = NWScript.GetModuleItemAcquired().AsItem();
            var stackSize = NWScript.GetModuleItemAcquiredStackSize();

            var pc = NWScript.GetModuleItemAcquiredBy().AsPlayer();
            var oldOwner = NWScript.GetModuleItemAcquiredFrom().AsObject();

            BuiltinEvents.OnItemAcquired(NWScript.GetModuleItemAcquired().AsItem());
        }

        [NWNEventHandler("mod-itemlost")]
        public static void OnItemLost(string script) {
            BuiltinEvents.OnItemLost(NWScript.GetModuleItemLost().AsItem(),
              NWScript.GetModuleItemLostBy().AsCreature());
        }

        [NWNEventHandler("mod-activate")]
        public static void OnItemActivated(string script) {
            BuiltinEvents.OnItemActivated(new ItemActivatedEvent());
        }

        [NWNEventHandler("mod-equip")]
        public static void OnItemEquipped(string script) {
            BuiltinEvents.OnItemEquipped(NWScript.GetPCItemLastEquipped().AsItem());
        }

        [NWNEventHandler("mod-unequip")]
        public static void OnItemUnequipped(string script) {
            BuiltinEvents.OnItemUnequipped(NWScript.GetPCItemLastUnequipped().AsItem());
        }

        [NWNEventHandler("area-enter")]
        public static void OnAreaEnter(string script) {
            BuiltinEvents.OnAreaEnter(Internal.OBJECT_SELF.AsArea());
        }

        [NWNEventHandler("area-exit")]
        public static void OnAreaExit(string script) {
            BuiltinEvents.OnAreaExit(Internal.OBJECT_SELF.AsArea());
        }

        [NWNEventHandler("area-heartbeat")]
        public static void OnAreaHeartbeat(string script) {
            //BuiltinEvents.OnAreaHeartbeat(Internal.OBJECT_SELF.AsArea());
        }

        [NWNEventHandler("area-userDefined")]
        public static void OnAreaUserDefined(string script) {
            //BuiltinEvents.OnAreaUserDefined(Internal.OBJECT_SELF.AsArea());
        }
    }
}