using System.Collections.Generic;
using NWN.Enums;
using NWN.Enums.Area;
using NWN.NWNX;

namespace NWN {
	// NWArea DOES NOT inherit from NWObject
	public class NWArea : NWObjectBase {
		public NWArea(uint oid) : base(oid) {
		}

		public int Width => NWScript.GetAreaSize(Dimension.Width, this);
		public int Height => NWScript.GetAreaSize(Dimension.Width, this);
		public AboveGround IsInterior => NWScript.GetIsAreaInterior(this);
		public Natural IsNatural => NWScript.GetIsAreaNatural(this);
		public Natural IsAboveGround => NWScript.GetIsAreaNatural(this);
		public string Tileset => NWScript.GetTilesetResRef(this);
		public int PlayerCount => Area.GetNumberOfPlayersInArea(this);
		public NWCreature LastEntered => Area.GetLastEntered(this).AsCreature();
		public NWCreature LastLeft => Area.GetLastLeft(this).AsCreature();

		public PvPSetting PvPSetting {
			get => Area.GetPVPSetting(this);
			set => Area.SetPVPSetting(this, value);
		}

		public int SpotModifier {
			get => Area.GetAreaSpotModifier(this);
			set => Area.SetAreaSpotModifier(this, value);
		}

		public int ListenModifier {
			get => Area.GetAreaListenModifier(this);
			set => Area.SetAreaListenModifier(this, value);
		}

		public bool IsRestingAllowed {
			get => !Area.GetNoRestingAllowed(this);
			set => Area.SetNoRestingAllowed(this, !value);
		}

		public int WindPower {
			get => Area.GetWindPower(this);
			set => Area.SetWindPower(this, value);
		}

		public float FogClipDistance {
			get => Area.GetFogClipDistance(this);
			set => Area.SetFogClipDistance(this, value);
		}

		public int ShadowOpacity {
			get => Area.GetShadowOpacity(this);
			set => Area.SetShadowOpacity(this, value);
		}

		public DayNightCycle DayNightCycle {
			get => Area.GetDayNightCycle(this);
			set => Area.SetDayNightCycle(this, value);
		}

		public WeatherType Weather {
			get => (WeatherType) NWScript.GetWeather(this);
			set => NWScript.SetWeather(this, value);
		}

		public Skybox SkyBox {
			get => NWScript.GetSkyBox(this);
			set => NWScript.SetSkyBox(value, this);
		}

		public FogColor SunFogColor {
			get => NWScript.GetFogColor(FogType.Sun, this);
			set => NWScript.SetFogColor(FogType.Sun, value, this);
		}

		public int SunFogAmount {
			get => NWScript.GetFogAmount(FogType.Sun, this);
			set => NWScript.SetFogAmount(FogType.Sun, value, this);
		}

		public FogColor MoonFogColor {
			get => NWScript.GetFogColor(FogType.Moon, this);
			set => NWScript.SetFogColor(FogType.Moon, value, this);
		}

		public int MoonFogAmount {
			get => NWScript.GetFogAmount(FogType.Moon, this);
			set => NWScript.SetFogAmount(FogType.Moon, value, this);
		}

		public IEnumerable<NWObject> Objects {
			get {
				for (var obj = NWScript.GetFirstObjectInArea(this).AsObject();
					obj;
					obj = NWScript.GetNextObjectInArea(this).AsObject())
					yield return obj;
			}
		}

		public IEnumerable<NWCreature> Creatures {
			get {
				for (var obj = NWScript.GetFirstObjectInArea(this).AsCreature();
					obj;
					obj = NWScript.GetNextObjectInArea(this).AsCreature())
					if (obj.IsValidType)
						yield return obj;
			}
		}

		public void RecomputeStaticLighting() {
			NWScript.RecomputeStaticLighting(this);
		}
	}
}