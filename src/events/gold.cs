namespace NWN.Events
{
    public class GoldEvent : NWNXEvent
    {
        public const string BEFORE_INVENTORY_ADD_GOLD	 = "NWNX_ON_INVENTORY_ADD_GOLD_BEFORE";
        public const string AFTER_INVENTORY_ADD_GOLD	 = "NWNX_ON_INVENTORY_ADD_GOLD_AFTER";
        public const string BEFORE_INVENTORY_REMOVE_GOLD = "NWNX_ON_INVENTORY_REMOVE_GOLD_BEFORE";
        public const string AFTER_INVENTORY_REMOVE_GOLD	 = "NWNX_ON_INVENTORY_REMOVE_GOLD_AFTER";
    
        public delegate void EventDelegate(GoldEvent e);
    
        public static EventDelegate BeforeAddGold	 = delegate {};
        public static EventDelegate AfterAddGold	 = delegate {};
        public static EventDelegate BeforeRemoveGold = delegate {};
        public static EventDelegate AfterRemoveGold	 = delegate {};
    
        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public int Amount => GetEventInt("GOLD");
    
        public GoldEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_INVENTORY_ADD_GOLD)]
        [NWNEventHandler(AFTER_INVENTORY_ADD_GOLD)]
        [NWNEventHandler(BEFORE_INVENTORY_REMOVE_GOLD)]
        [NWNEventHandler(AFTER_INVENTORY_REMOVE_GOLD)]
        public static void EventHandler(string script)
        {
            var e = new GoldEvent(script);
            switch (script)
            {
                case BEFORE_INVENTORY_ADD_GOLD:	   BeforeAddGold(e); break;
                case AFTER_INVENTORY_ADD_GOLD:	   AfterAddGold(e); break;
                case BEFORE_INVENTORY_REMOVE_GOLD: BeforeRemoveGold(e); break;
                case AFTER_INVENTORY_REMOVE_GOLD:  AfterRemoveGold(e); break;
            }
        }
    }
}