using System.Collections.Generic;

namespace NWN {
	public class NWPlayer : NWCreature {
		// public virtual string BicFile => NWNX.Player.GetBicFileName(this);

		public NWPlayer(uint oid) : base(oid) {
		}

		public virtual IEnumerable<NWPlayer> PartyMembers {
			get {
				for (var member = NWScript.GetFirstFactionMember(this).AsPlayer();
					member;
					member = NWScript.GetNextFactionMember(this).AsPlayer())
					yield return member;
			}
		}

		public virtual string PlayerName => NWScript.GetPCPlayerName(this);
		public virtual string IPAddress => NWScript.GetPCIPAddress(this);

		public virtual string CDKey => NWScript.GetPCPublicCDKey(this);

		private void SetLikes(NWPlayer other, bool likes) {
			if (likes)
				NWScript.SetPCLike(this, other);
			else
				NWScript.SetPCDislike(this, other);
		}

		public virtual void SendMessage(string text) {
			NWScript.SendMessageToPC(this, text);
		}

		public virtual void Boot(string text) {
			NWScript.BootPC(this, text);
		}

		public virtual void AddToParty(NWPlayer partyLeader) {
			NWScript.AddToParty(this, partyLeader);
		}

		public virtual void RemoveFromParty() {
			NWScript.RemoveFromParty(this);
		}

		public class QuickBarSlot {
			public enum QuickBarSlotType {
				Empty = 0,
				Item = 1,
				Spell = 2,
				Skill = 3,
				Feat = 4,
				Script = 5,
				Dialog = 6,
				Attack = 7,
				Emote = 8,
				ItemPropertyCastspell = 9,
				ModeToggle = 10,
				DMCreateCreature = 11,
				DMCreateItem = 12,
				DMCreateEncounter = 13,
				DMCreateWaypoint = 14,
				DMCreateTrigger = 15,
				DMCreatePortal = 16,
				DMCreatePlaceable = 17,
				CommandLine = 18,
				DMMakeInvulnerable = 19,
				DMForceRest = 20,
				DMGoto = 21,
				DMHeal = 22,
				DMKill = 23,
				DMPossess = 24,
				DMImpersonate = 25,
				DMGiveGold = 27,
				DMTakeGold = 28,
				DMGiveItem = 29,
				DMTakeItem = 30,
				DMGiveXP = 31,
				DMTakeXP = 32,
				DMGiveLevel = 33,
				DMTakeLevel = 34,
				DMLimbo = 35,
				DMToggleAI = 36,
				RollDie = 37,
				PossessFamiliar = 38,
				AssociateCommand = 39,
				Examine = 40,
				Barter = 41,
				QuickChat = 42,
				CancelPolymorph = 43,
				SpellLikeAbility = 44,
				DMGiveGood = 45,
				DMGiveEvil = 46,
				DMGiveLawful = 47,
				DMGiveChaotic = 48
			}

			public NWItem? Item { get; set; }
			public NWItem? SecondaryItem { get; set; }
			public QuickBarSlotType ObjectType { get; set; }
			public int MultiClass { get; set; }
			public string? Resref { get; set; }
			public string? CommandLabel { get; set; }
			public string? CommandLine { get; set; }
			public string? ToolTip { get; set; }
			public int IntParam1 { get; set; }
			public int MetaType { get; set; }
			public int DomainLevel { get; set; }
			public int AssociateType { get; set; }
			public NWObject? Associate { get; set; }
		}
	}
}