using System.Collections.Generic;

namespace NWN {
	public class NWModule : NWObjectBase {
		public static NWModule Module = new NWModule(0);

		public NWModule(uint oid) : base(oid) {
		}

		public Location StartingLocation => NWScript.GetStartingLocation();

		public override string Name => NWScript.GetName(this);

		//set => NWNX.Admin.SetModuleName(value);
		public int XPScale {
			get => NWScript.GetModuleXPScale();
			set => NWScript.SetModuleXPScale(value);
		}

		public int Year {
			get => NWScript.GetCalendarYear();
			set => NWScript.SetCalendar(value, Month, Day);
		}

		public int Month {
			get => NWScript.GetCalendarMonth();
			set => NWScript.SetCalendar(Year, value, Day);
		}

		public int Day {
			get => NWScript.GetCalendarDay();
			set => NWScript.SetCalendar(Year, Month, value);
		}

		public int Hour {
			get => NWScript.GetTimeHour();
			set => NWScript.SetTime(value, Minute, Second, Millisecond);
		}

		public int Minute {
			get => NWScript.GetTimeMinute();
			set => NWScript.SetTime(Hour, value, Second, Millisecond);
		}

		public int Second {
			get => NWScript.GetTimeSecond();
			set => NWScript.SetTime(Hour, Minute, value, Millisecond);
		}

		public int Millisecond {
			get => NWScript.GetTimeMillisecond();
			set => NWScript.SetTime(Hour, Minute, Second, value);
		}

		public bool IsDay => NWScript.GetIsDay();
		public bool IsNight => NWScript.GetIsNight();
		public bool IsDawn => NWScript.GetIsDawn();
		public bool IsDusk => NWScript.GetIsDusk();
		public float SecondsPerHour => NWScript.HoursToSeconds(1);


		public IEnumerable<NWPlayer> Players {
			get {
				for (var pc = NWScript.GetFirstPC(); pc != NWScript.OBJECT_INVALID; pc = NWScript.GetNextPC())
					yield return pc.AsPlayer();
			}
		}

		public IEnumerable<NWArea> Areas {
			get {
				for (var area = NWScript.GetFirstArea(); area != NWScript.OBJECT_INVALID; area = NWScript.GetNextArea())
					yield return area.AsArea();
			}
		}
	}
}