using System.Collections.Generic;

namespace NWN.Events {
    public class BarterStartEvent : NWNXEvent {
        public delegate void EventDelegate(BarterStartEvent e);

        public const string BEFORE_BARTER_START = "NWNX_ON_BARTER_START_BEFORE";
        public const string AFTER_BARTER_START = "NWNX_ON_BARTER_START_AFTER";

        public static EventDelegate BeforeBarterStart = delegate { };
        public static EventDelegate AfterBarterStart = delegate { };

        public BarterStartEvent(string script) {
            EventType = script;
        }

        public override bool Skippable => true;

        public NWPlayer Initiator => Internal.OBJECT_SELF.AsPlayer();
        public NWPlayer Target => GetEventObject("BARTER_TARGET").AsPlayer();

        [NWNEventHandler(BEFORE_BARTER_START)]
        [NWNEventHandler(AFTER_BARTER_START)]
        public static void EventHandler(string script) {
            var e = new BarterStartEvent(script);
            switch (script) {
                case BEFORE_BARTER_START:
                    BeforeBarterStart(e);
                    break;
                case AFTER_BARTER_START:
                    AfterBarterStart(e);
                    break;
            }
        }
    }

    public class BarterEndEvent : NWNXEvent {
        public delegate void EventDelegate(BarterEndEvent e);

        public const string BEFORE_BARTER_END = "NWNX_ON_BARTER_END_BEFORE";
        public const string AFTER_BARTER_END = "NWNX_ON_BARTER_END_AFTER";

        public static EventDelegate BeforeBarterEnd = delegate { };
        public static EventDelegate AfterBarterEnd = delegate { };

        public BarterEndEvent(string script) {
            EventType = script;
        }

        public NWPlayer Initiator => Internal.OBJECT_SELF.AsPlayer();
        public NWPlayer Target => GetEventObject("BARTER_TARGET").AsPlayer();
        public bool BarterComplete => GetEventInt("BARTER_COMPLETE") == 1;

        // Only in BEFORE:
        public IEnumerable<NWItem> InitiatorItemsGiven() {
            for (var i = 0; i < GetEventInt("BARTER_INITIATOR_ITEM_COUNT"); i++)
                yield return GetEventObject($"BARTER_INITIATOR_ITEM_{i}").AsItem();
        }

        public IEnumerable<NWItem> TargetItemsGiven() {
            for (var i = 0; i < GetEventInt("BARTER_TARGET_ITEM_COUNT"); i++)
                yield return GetEventObject($"BARTER_TARGET_ITEM_{i}").AsItem();
        }

        [NWNEventHandler(BEFORE_BARTER_END)]
        [NWNEventHandler(AFTER_BARTER_END)]
        public static void EventHandler(string script) {
            var e = new BarterEndEvent(script);
            switch (script) {
                case BEFORE_BARTER_END:
                    BeforeBarterEnd(e);
                    break;
                case AFTER_BARTER_END:
                    AfterBarterEnd(e);
                    break;
            }
        }
    }
}