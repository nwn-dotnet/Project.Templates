using NWN.NWNX;

namespace NWN {
	public class NWStationary : NWTrappable {
		public NWStationary(uint oid) : base(oid) {
		}

		public virtual bool IsLocked {
			get => NWScript.GetLocked(this);
			set => NWScript.SetLocked(this, value);
		}

		public virtual bool IsLockable {
			get => NWScript.GetLockLockable(this);
			set => NWScript.SetLockLockable(this, value);
		}

		public virtual bool IsKeyRequired {
			get => NWScript.GetLockKeyRequired(this);
			set => NWScript.SetLockKeyRequired(this, value);
		}

		public virtual int LockDC {
			get => NWScript.GetLockLockDC(this);
			set => NWScript.SetLockLockDC(this, value);
		}

		public virtual int UnlockDC {
			get => NWScript.GetLockUnlockDC(this);
			set => NWScript.SetLockUnlockDC(this, value);
		}

		public virtual string LockKeyTag {
			get => NWScript.GetLockKeyTag(this);
			set => NWScript.SetLockKeyTag(this, value);
		}

		public virtual bool IsOpen => NWScript.GetIsOpen(this);

		public virtual int Hardness {
			get => NWScript.GetHardness(this);
			set => NWScript.SetHardness(value, this);
		}

		public virtual bool IsKeyAutoRemoved {
			get => Object.GetAutoRemoveKey(this);
			set => Object.SetAutoRemoveKey(this, value);
		}
	}
}