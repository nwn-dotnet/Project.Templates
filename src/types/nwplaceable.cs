namespace NWN
{
    public class NWPlaceable : NWStationary
    {
        public NWPlaceable(uint oid) : base(oid) {}

        public virtual bool IsUseable
        {
            get => NWScript.GetUseableFlag(this) == 1;
            set => NWScript.SetUseableFlag(this, value ? 1 : 0);
        }
        public virtual bool IsIlluminated
        {
            get => NWScript.GetPlaceableIllumination(this) == 1;
            set => NWScript.SetPlaceableIllumination(this, value ? 1 : 0);
        }
        public virtual NWCreature SittingCreature => NWScript.GetSittingCreature(this).AsCreature();

        public bool IsStatic
        {
            get => NWNX.Object.GetPlaceableIsStatic(this) == 1;
            set => NWNX.Object.SetPlaceableIsStatic(this, value ? 1 : 0);
        }
    }
}
