namespace NWN.Events {
    public class UseItemEvent : NWNXEvent {
        public delegate void EventDelegate(UseItemEvent e);

        public const string BEFORE_USE = "NWNX_ON_USE_ITEM_BEFORE";
        public const string AFTER_USE = "NWNX_ON_USE_ITEM_AFTER";

        public static EventDelegate BeforeUseItem = delegate { };
        public static EventDelegate AfterUseItem = delegate { };

        public UseItemEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
        public NWItem Item => GetEventObject("ITEM_OBJECT_ID").AsItem();
        public NWObject TargetObject => GetEventObject("TARGET_OBJECT_ID").AsObject();
        public int ItemPropertyIndex => GetEventInt("ITEM_PROPERTY_INDEX");
        public int ItemSubPropertyIndex => GetEventInt("ITEM_SUB_PROPERTY_INDEX");
        public Vector TargetVector => GetEventVector("TARGET_POSITION");

        [NWNEventHandler(BEFORE_USE)]
        [NWNEventHandler(AFTER_USE)]
        public static void EventHandler(string script) {
            var e = new UseItemEvent(script);
            switch (script) {
                case BEFORE_USE:
                    BeforeUseItem(e);
                    break;
                case AFTER_USE:
                    AfterUseItem(e);
                    break;
            }
        }
    }
    public class ItemDestroyEvent : NWNXEvent {
        public delegate void EventDelegate(ItemDestroyEvent e);

        public const string ITEM_DESTROY_OBJECT_BEFORE = "NWNX_ON_ITEM_DESTROY_OBJECT_BEFORE";
        public const string ITEM_DESTROY_OBJECT_AFTER = "NWNX_ON_ITEM_DESTROY_OBJECT_AFTER";
        public const string ITEM_DECREMENT_STACKSIZE_BEFORE = "NWNX_ON_ITEM_DECREMENT_STACKSIZE_BEFORE";
        public const string ITEM_DECREMENT_STACKSIZE_AFTER = "NWNX_ON_ITEM_DECREMENT_STACKSIZE_AFTER";

        public static EventDelegate BeforeDestroyItem = delegate { };
        public static EventDelegate AfterDestroyItem = delegate { };
        public static EventDelegate BeforeDecrementStackSize = delegate { };
        public static EventDelegate AfterDecrementStackSize = delegate { };

        public ItemDestroyEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWItem TriggeringItem => Internal.OBJECT_SELF.AsItem();

        [NWNEventHandler(ITEM_DESTROY_OBJECT_BEFORE)]
        [NWNEventHandler(ITEM_DESTROY_OBJECT_AFTER)]
        [NWNEventHandler(ITEM_DECREMENT_STACKSIZE_BEFORE)]
        [NWNEventHandler(ITEM_DECREMENT_STACKSIZE_AFTER)]
        public static void EventHandler(string script) {
            var e = new ItemDestroyEvent(script);
            switch (script) {
                case ITEM_DESTROY_OBJECT_BEFORE:
                    BeforeDestroyItem(e);
                    break;
                case ITEM_DESTROY_OBJECT_AFTER:
                    AfterDestroyItem(e);
                    break;
                case ITEM_DECREMENT_STACKSIZE_BEFORE:
                    BeforeDecrementStackSize(e);
                    break;
                case ITEM_DECREMENT_STACKSIZE_AFTER:
                    AfterDecrementStackSize(e);
                    break;
            }
        }
    }
    public class ValidateUseItemEvent : NWNXEvent {
            public delegate void EventDelegate(ValidateUseItemEvent e);

            public const string VALIDATE_USE_ITEM_BEFORE = "NWNX_ON_VALIDATE_USE_ITEM_BEFORE";
            public const string VALIDATE_USE_ITEM_AFTER = "NWNX_ON_VALIDATE_USE_ITEM_AFTER";

            public static EventDelegate BeforeValidateUseItem = delegate { };
            public static EventDelegate AfterValidateUseItem = delegate { };

            public ValidateUseItemEvent(string script) {
                EventType = script;
            }

            public override bool Skippable => true;

            public NWCreature User => Internal.OBJECT_SELF.AsCreature();
            public NWItem Item => GetEventObject("ITEM_OBJECT_ID").AsItem();            

            [NWNEventHandler(VALIDATE_USE_ITEM_BEFORE)]
            [NWNEventHandler(VALIDATE_USE_ITEM_AFTER)]
            public static void EventHandler(string script) {
                var e = new ValidateUseItemEvent(script);
                switch (script) {
                    case VALIDATE_USE_ITEM_BEFORE:
                        BeforeValidateUseItem(e);
                        break;
                    case VALIDATE_USE_ITEM_AFTER:
                        AfterValidateUseItem(e);
                        break;
                }
            }
        }
        public class ValidateEquipItemEvent : NWNXEvent {
            public delegate void EventDelegate(ValidateEquipItemEvent e);

            public const string VALIDATE_ITEM_EQUIP_BEFORE = "NWNX_ON_VALIDATE_ITEM_EQUIP_BEFORE";
            public const string VALIDATE_ITEM_EQUIP_AFTER = "NWNX_ON_VALIDATE_ITEM_EQUIP_AFTER";

            public static EventDelegate BeforeValidateEquipItem = delegate { };
            public static EventDelegate AfterValidateEquipItem = delegate { };

            public ValidateEquipItemEvent(string script) {
                EventType = script;
            }

            public override bool Skippable => true;

            public NWCreature User => Internal.OBJECT_SELF.AsCreature();
            public NWItem Item => GetEventObject("ITEM_OBJECT_ID").AsItem();
            public Enums.InventorySlot Slot => (Enums.InventorySlot) GetEventInt("SLOT");
            public bool BeforeResult => GetEventInt("BEFORE_RESULT") == 1;

            [NWNEventHandler(VALIDATE_ITEM_EQUIP_BEFORE)]
            [NWNEventHandler(VALIDATE_ITEM_EQUIP_AFTER)]
            public static void EventHandler(string script) {
                var e = new ValidateEquipItemEvent(script);
                switch (script) {
                    case VALIDATE_ITEM_EQUIP_BEFORE:
                        BeforeValidateEquipItem(e);
                        break;
                    case VALIDATE_ITEM_EQUIP_AFTER:
                        AfterValidateEquipItem(e);
                        break;
                }
            }
        }
    public class ItemUseLoreEvent : NWNXEvent {
        public delegate void EventDelegate(ItemUseLoreEvent e);

        public const string ITEM_USE_LORE_BEFORE = "NWNX_ON_ITEM_USE_LORE_BEFORE";
        public const string ITEM_USE_LORE_AFTER = "NWNX_ON_ITEM_USE_LORE_AFTER";

        public static EventDelegate BeforeUseLore = delegate { };
        public static EventDelegate AfterUseLore = delegate { };

        public ItemUseLoreEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public NWItem Item => GetEventObject("ITEM").AsItem();

        [NWNEventHandler(ITEM_USE_LORE_BEFORE)]
        [NWNEventHandler(ITEM_USE_LORE_AFTER)]
        public static void EventHandler(string script) {
            var e = new ItemUseLoreEvent(script);
            switch (script) {
                case ITEM_USE_LORE_BEFORE:
                    BeforeUseLore(e);
                    break;
                case ITEM_USE_LORE_AFTER:
                    AfterUseLore(e);
                    break;
            }
        }
    }
    public class ItemSplitEvent : NWNXEvent {
        public delegate void EventDelegate(ItemSplitEvent e);

        public const string BEFORE_SPLIT = "NWNX_ON_ITEM_SPLIT_BEFORE";
        public const string AFTER_SPLIT = "NWNX_ON_ITEM_SPLIT_AFTER";

        public static EventDelegate BeforeItemSplit = delegate { };
        public static EventDelegate AfterItemSplit = delegate { };

        public ItemSplitEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public NWItem Item => GetEventObject("ITEM").AsItem();
        public int Amount => GetEventInt("NUMBER_SPLIT_OFF");

        [NWNEventHandler(BEFORE_SPLIT)]
        [NWNEventHandler(AFTER_SPLIT)]
        public static void EventHandler(string script) {
            var e = new ItemSplitEvent(script);
            switch (script) {
                case BEFORE_SPLIT:
                    BeforeItemSplit(e);
                    break;
                case AFTER_SPLIT:
                    AfterItemSplit(e);
                    break;
            }
        }
    }
    public class ItemEquipEvent : NWNXEvent {
        public delegate void EventDelegate(ItemEquipEvent e);

        public const string BEFORE_EQUIP = "NWNX_ON_ITEM_EQUIP_BEFORE";
        public const string AFTER_EQUIP = "NWNX_ON_ITEM_EQUIP_AFTER";
        public const string BEFORE_UNEQUIP = "NWNX_ON_ITEM_UNEQUIP_BEFORE";
        public const string AFTER_UNEQUIP = "NWNX_ON_ITEM_UNEQUIP_AFTER";

        public static EventDelegate BeforeEquipItem = delegate { };
        public static EventDelegate AfterEquipItem = delegate { };
        public static EventDelegate BeforeUnequipItem = delegate { };
        public static EventDelegate AfterUnequipItem = delegate { };

        public ItemEquipEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWCreature Owner => Internal.OBJECT_SELF.AsCreature();
        public NWItem Item => GetEventObject("ITEM").AsItem();
        public int Slot => GetEventInt("SLOT"); // Equip only

        [NWNEventHandler(BEFORE_EQUIP)]
        [NWNEventHandler(AFTER_EQUIP)]
        [NWNEventHandler(BEFORE_UNEQUIP)]
        [NWNEventHandler(AFTER_UNEQUIP)]
        public static void EventHandler(string script) {
            var e = new ItemEquipEvent(script);
            switch (script) {
                case BEFORE_EQUIP:
                    BeforeEquipItem(e);
                    break;
                case AFTER_EQUIP:
                    AfterEquipItem(e);
                    break;
                case BEFORE_UNEQUIP:
                    BeforeUnequipItem(e);
                    break;
                case AFTER_UNEQUIP:
                    AfterUnequipItem(e);
                    break;
            }
        }
    }
    public class ItemScrollLearnEvent : NWNXEvent {
        public delegate void EventDelegate(ItemScrollLearnEvent e);

        public const string ITEM_SCROLL_LEARN_BEFORE = "NWNX_ON_ITEM_SCROLL_LEARN_BEFORE";
        public const string ITEM_SCROLL_LEARN_AFTER = "NWNX_ON_ITEM_SCROLL_LEARN_AFTER";

        public static EventDelegate BeforeLearnScroll = delegate { };
        public static EventDelegate AfterLearnScroll = delegate { };

        public ItemScrollLearnEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();
        public NWItem Scroll => GetEventObject("SCROLL").AsItem();

        [NWNEventHandler(ITEM_SCROLL_LEARN_BEFORE)]
        [NWNEventHandler(ITEM_SCROLL_LEARN_AFTER)]
        public static void EventHandler(string script) {
            var e = new ItemScrollLearnEvent(script);
            switch (script) {
                case ITEM_SCROLL_LEARN_BEFORE:
                    BeforeLearnScroll(e);
                    break;
                case ITEM_SCROLL_LEARN_AFTER:
                    AfterLearnScroll(e);
                    break;
            }
        }
    }
}