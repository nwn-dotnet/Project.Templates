namespace NWN.Events
{
    public class EquipEvent : NWNXEvent
    {
        public const string BEFORE_EQUIP      = "NWNX_ON_ITEM_EQUIP_BEFORE";
        public const string AFTER_EQUIP       = "NWNX_ON_ITEM_EQUIP_AFTER";
        public const string BEFORE_UNEQUIP    = "NWNX_ON_ITEM_UNEQUIP_BEFORE";
        public const string AFTER_UNEQUIP     = "NWNX_ON_ITEM_UNEQUIP_AFTER";

        public delegate void EventDelegate(EquipEvent e);

        public static EventDelegate BeforeEquipItem          = delegate {};
        public static EventDelegate AfterEquipItem           = delegate {};
        public static EventDelegate BeforeUnequipItem        = delegate {};
        public static EventDelegate AfterUnequipItem         = delegate {};

        public NWCreature Owner => Internal.OBJECT_SELF.AsCreature();
        public NWItem Item => GetEventObject("ITEM").AsItem();
        public int Slot => GetEventInt("SLOT");  // Equip only

        public EquipEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_EQUIP)]
        [NWNEventHandler(AFTER_EQUIP)]
        [NWNEventHandler(BEFORE_UNEQUIP)]
        [NWNEventHandler(AFTER_UNEQUIP)]
        public static void EventHandler(string script)
        {
            var e = new EquipEvent(script);
            switch (script)
            {
                case BEFORE_EQUIP:   BeforeEquipItem(e); break;
                case AFTER_EQUIP:    AfterEquipItem(e); break;
                case BEFORE_UNEQUIP:  BeforeUnequipItem(e); break;
                case AFTER_UNEQUIP:   AfterUnequipItem(e); break;
                default: break;
            }
        }
    }
}