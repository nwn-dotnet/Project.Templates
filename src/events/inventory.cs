namespace NWN.Events
{
    public class InventoryEvent : NWNXEvent
    {
        public const string BEFORE_INVENTORY_ADD_ITEM	    = "NWNX_ON_INVENTORY_ADD_ITEM_BEFORE";
        public const string AFTER_INVENTORY_ADD_ITEM    	= "NWNX_ON_INVENTORY_ADD_ITEM_AFTER";
        public const string BEFORE_INVENTORY_REMOVE_ITEM	= "NWNX_ON_INVENTORY_REMOVE_ITEM_BEFORE";
        public const string AFTER_INVENTORY_REMOVE_ITEM	    = "NWNX_ON_INVENTORY_REMOVE_ITEM_AFTER";
    
        public delegate void EventDelegate(InventoryEvent e);
    
        public static EventDelegate BeforeAddItem	    = delegate {};
        public static EventDelegate AfterAddItem    	= delegate {};
        public static EventDelegate BeforeRemoveItem	= delegate {};
        public static EventDelegate AfterRemoveItem	    = delegate {};
    
        public NWObject Container => Internal.OBJECT_SELF.AsObject();
        public NWItem Item => GetEventObject("ITEM").AsItem();
    
        public InventoryEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_INVENTORY_ADD_ITEM)]
        [NWNEventHandler(AFTER_INVENTORY_ADD_ITEM)]
        [NWNEventHandler(BEFORE_INVENTORY_REMOVE_ITEM)]
        [NWNEventHandler(AFTER_INVENTORY_REMOVE_ITEM)]
        public static void EventHandler(string script)
        {
            var e = new InventoryEvent(script);
            switch (script)
            {
                case BEFORE_INVENTORY_ADD_ITEM:	    BeforeAddItem(e); break;
                case AFTER_INVENTORY_ADD_ITEM:	    AfterAddItem(e); break;
                case BEFORE_INVENTORY_REMOVE_ITEM:	BeforeRemoveItem(e); break;
                case AFTER_INVENTORY_REMOVE_ITEM:	AfterRemoveItem(e); break;
            }
        }
    }

    public class InventoryOpenEvent : NWNXEvent
    {
        public const string BEFORE_INVENTORY_OPEN	= "NWNX_ON_INVENTORY_OPEN_BEFORE";
        public const string AFTER_INVENTORY_OPEN	= "NWNX_ON_INVENTORY_OPEN_AFTER";
    
        public delegate void EventDelegate(InventoryOpenEvent e);
    
        public static EventDelegate BeforeInventoryOpen	= delegate {};
        public static EventDelegate AfterInventoryOpen	= delegate {};
    
        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
    
        public InventoryOpenEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_INVENTORY_OPEN)]
        [NWNEventHandler(AFTER_INVENTORY_OPEN)]
        public static void EventHandler(string script)
        {
            var e = new InventoryOpenEvent(script);
            switch (script)
            {
                case BEFORE_INVENTORY_OPEN:	BeforeInventoryOpen(e); break;
                case AFTER_INVENTORY_OPEN:	AfterInventoryOpen(e); break;
            }
        }
    }

    public class InventorySelectPanelEvent : NWNXEvent
    {
        public const string BEFORE_INVENTORY_SELECT_PANEL	= "NWNX_ON_INVENTORY_SELECT_PANEL_BEFORE";
        public const string AFTER_INVENTORY_SELECT_PANEL	= "NWNX_ON_INVENTORY_SELECT_PANEL_AFTER";
    
        public delegate void EventDelegate(InventorySelectPanelEvent e);
    
        public static EventDelegate BeforeSelectPanel	= delegate {};
        public static EventDelegate AfterSelectPanel	= delegate {};
    
        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public int CurrentPanelIndex => GetEventInt("CURRENT_PANEL");
        public int SelectedPanelIndex => GetEventInt("SELECTED_PANEL");
    
        public InventorySelectPanelEvent(string script) { EventType = script; }
    
        [NWNEventHandler(BEFORE_INVENTORY_SELECT_PANEL)]
        [NWNEventHandler(AFTER_INVENTORY_SELECT_PANEL)]
        public static void EventHandler(string script)
        {
            var e = new InventorySelectPanelEvent(script);
            switch (script)
            {
                case BEFORE_INVENTORY_SELECT_PANEL:	BeforeSelectPanel(e); break;
                case AFTER_INVENTORY_SELECT_PANEL:	AfterSelectPanel(e); break;
            }
        }
    }
}