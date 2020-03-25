using System;
using Object = NWN.NWNX.Object;

namespace NWN.Events {
	public abstract class NWNXEvent {
		public virtual bool Skippable => false;
		public bool Skipped { get; protected set; }
		public string? EventType { get; protected set; }

		protected void SetEventResult(string result) => NWNX.Events.SetEventResult(result);

		protected static uint GetEventObject(string eventDataTag) => Object.StringToObject(NWNX.Events.GetEventData(eventDataTag));

		protected static string GetEventString(string eventDataTag) => NWNX.Events.GetEventData(eventDataTag);

		protected static int GetEventInt(string eventDataTag) => int.Parse(NWNX.Events.GetEventData(eventDataTag));

		protected static float GetEventFloat(string eventDataTag) =>float.Parse(NWNX.Events.GetEventData(eventDataTag));

		protected static Vector GetEventVector(string eventDataPrefix) {
			var x = float.Parse(NWNX.Events.GetEventData(eventDataPrefix + "_X"));
			var y = float.Parse(NWNX.Events.GetEventData(eventDataPrefix + "_Y"));
			var z = float.Parse(NWNX.Events.GetEventData(eventDataPrefix + "_Z"));
			return new Vector(x, y, z);
		}

		public void Skip() {
			if (!Skippable || EventType!.EndsWith("_AFTER"))
				throw new ApplicationException($"Can't skip {EventType}");
			NWNX.Events.SkipEvent();
			Skipped = true;
		}
	}
}