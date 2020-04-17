namespace NWN {
	public static class UIntToObject {
		public static NWObjectBase AsObjectBase(this uint oid) {
			return new NWObjectBase(oid);
		}

		public static NWObject AsObject(this uint oid) {
			return new NWObject(oid);
		}

		public static NWArea AsArea(this uint oid) {
			return new NWArea(oid);
		}

		public static NWCreature AsCreature(this uint oid) {
			return new NWCreature(oid);
		}

		public static NWItem AsItem(this uint oid) {
			return new NWItem(oid);
		}

		public static NWModule AsModule(this uint oid) {
			return new NWModule(oid);
		}

		public static NWPlaceable AsPlaceable(this uint oid) {
			return new NWPlaceable(oid);
		}

		public static NWPlayer AsPlayer(this uint oid) {
			return new NWPlayer(oid);
		}

		public static NWStationary AsStationary(this uint oid) {
			return new NWStationary(oid);
		}

		public static NWTrappable AsTrappable(this uint oid) {
			return new NWTrappable(oid);
		}
	}
}