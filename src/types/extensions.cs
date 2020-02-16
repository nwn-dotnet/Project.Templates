namespace NWN
{
    public static class UIntToObject
    {
        public static NWObjectBase AsObjectBase(this uint oid) => new NWObjectBase(oid);
        public static NWObject AsObject(this uint oid) => new NWObject(oid);
        public static NWArea AsArea(this uint oid) => new NWArea(oid);
        public static NWCreature AsCreature(this uint oid) => new NWCreature(oid);
        public static NWItem AsItem(this uint oid) => new NWItem(oid);
        public static NWModule AsModule(this uint oid) => new NWModule(oid);
        public static NWPlaceable AsPlaceable(this uint oid) => new NWPlaceable(oid);
        public static NWPlayer AsPlayer(this uint oid) => new NWPlayer(oid);
        public static NWStationary AsStationary(this uint oid) => new NWStationary(oid);
        public static NWTrappable AsTrappable(this uint oid) => new NWTrappable(oid);
    }
}