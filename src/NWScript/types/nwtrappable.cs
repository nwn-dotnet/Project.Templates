namespace NWN {
	public class NWTrappable : NWObject {
		public NWTrappable(uint oid) : base(oid) {
		}

		public virtual bool IsTrapped => NWScript.GetIsTrapped(this) == 1;

		//set => NWScript.SetTrapDisabled(this);
		public virtual bool IsTrapActive {
			get => NWScript.GetTrapActive(this);
			set => NWScript.SetTrapActive(this, value);
		}

		public virtual bool IsTrapDisarmable {
			get => NWScript.GetTrapDisarmable(this);
			set => NWScript.SetTrapDisarmable(this, value);
		}

		public virtual bool IsTrapDetectable {
			get => NWScript.GetTrapDetectable(this);
			set => NWScript.SetTrapDetectable(this, value);
		}

		public virtual bool IsTrapFlagged => NWScript.GetTrapFlagged(this);
		// set => NWScript.SetTrapFlagged(this, value ? 1 : 0);

		public virtual int TrapBaseType => NWScript.GetTrapBaseType(this);
		//set => NWScript.SetTrapBaseType(this, value);

		public virtual bool IsTrapOneShot {
			get => NWScript.GetTrapOneShot(this);
			set => NWScript.SetTrapOneShot(this, value);
		}

		public virtual NWObject TrapCreator => NWScript.GetTrapCreator(this).AsObject();
		// set => NWScript.SetTrapCreator(this, value);

		public virtual string TrapKeyTag {
			get => NWScript.GetTrapKeyTag(this);
			set => NWScript.SetTrapKeyTag(this, value);
		}

		public virtual int TrapDisarmDC {
			get => NWScript.GetTrapDisarmDC(this);
			set => NWScript.SetTrapDisarmDC(this, value);
		}

		public virtual bool IsTrapDetectedBy(NWCreature creature) {
			return NWScript.GetTrapDetectedBy(this, creature);
		}

		public virtual void SetTrapDetectedBy(NWCreature creature, bool detected) {
			NWScript.SetTrapDetectedBy(this, creature, detected);
		}

		public virtual void DisableTrap() {
			NWScript.SetTrapDisabled(this);
		}
	}
}