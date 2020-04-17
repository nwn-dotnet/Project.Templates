namespace NWN.Events {
	public class AttackObjectEvent : NWNXEvent {
		public delegate void EventDelegate(AttackObjectEvent e);

		public const string BEFORE_ATTACK_OBJECT = "NWNX_ON_INPUT_ATTACK_OBJECT_BEFORE";
		public const string AFTER_ATTACK_OBJECT = "NWNX_ON_INPUT_ATTACK_OBJECT_AFTER";

		public static EventDelegate BeforeAttackObject = delegate { };
		public static EventDelegate AfterAttackObject = delegate { };

		public AttackObjectEvent(string script) {
			EventType = script;
		}

		public NWCreature Attacker => Internal.OBJECT_SELF.AsCreature();
		public int MaterialType => GetEventInt("MATERIAL_TYPE");

		public uint Target => NWNX.Object.StringToObject(GetEventString("TARGET"));
		public bool Passive => GetEventInt("Passive") != 0;
		public bool ClearAllActions => GetEventInt("CLEAR_ALL_ACTIONS") != 0;
		public bool AddToFront => GetEventInt("ADD_TO_FRONT") != 0;

		[NWNEventHandler(BEFORE_ATTACK_OBJECT)]
		[NWNEventHandler(AFTER_ATTACK_OBJECT)]
		public static void EventHandler(string script) {
			var e = new AttackObjectEvent(script);
			switch (script) {
				case BEFORE_ATTACK_OBJECT:
					BeforeAttackObject(e);
					break;
				case AFTER_ATTACK_OBJECT:
					AfterAttackObject(e);
					break;
			}
		}
	}
}