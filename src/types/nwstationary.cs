namespace NWN
{
    public class NWStationary : NWTrappable
    {
        public NWStationary(uint oid) : base(oid) {}

        public virtual bool IsLocked
        {
            get => NWScript.GetLocked(this) == 1;
            set => NWScript.SetLocked(this, value ? 1 : 0);
        }
        public virtual bool IsLockable
        {
            get => NWScript.GetLockLockable(this) == 1;
            set => NWScript.SetLockLockable(this, value ? 1 : 0);
        }
        public virtual bool IsKeyRequired
        {
            get => NWScript.GetLockKeyRequired(this) == 1;
            set => NWScript.SetLockKeyRequired(this, value ? 1 : 0);
        }
        public virtual int LockDC
        {
            get => NWScript.GetLockLockDC(this);
            set => NWScript.SetLockLockDC(this, value);
        }
        public virtual int UnlockDC
        {
            get => NWScript.GetLockUnlockDC(this);
            set => NWScript.SetLockUnlockDC(this, value);
        }
        public virtual string LockKeyTag
        {
            get => NWScript.GetLockKeyTag(this);
            set => NWScript.SetLockKeyTag(this, value);
        }

        public virtual bool IsOpen => NWScript.GetIsOpen(this) == 1;

        public virtual int Hardness
        {
            get => NWScript.GetHardness(this);
            set => NWScript.SetHardness(value, this);
        }

        public virtual bool IsKeyAutoRemoved
        {
            get => NWNX.Object.GetAutoRemoveKey(this) == 1;
            set => NWNX.Object.SetAutoRemoveKey(this, value ? 1 : 0);
        }
    }
}
