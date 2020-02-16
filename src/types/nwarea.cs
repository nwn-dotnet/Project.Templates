using System.Collections.Generic;

namespace NWN
{
    // NWArea DOES NOT inherit from NWObject
    public partial class NWArea : NWObjectBase
    {
        public NWArea(uint oid) : base(oid) {}

        public int        Width  => NWScript.GetAreaSize(NWScript.AREA_WIDTH, this);
        public int        Height => NWScript.GetAreaSize(NWScript.AREA_HEIGHT, this);
        public bool       IsInterior => NWScript.GetIsAreaInterior(this) == 1;
        public bool       IsNatural => NWScript.GetIsAreaNatural(this) == NWScript.AREA_NATURAL;
        public bool       IsAboveGround => NWScript.GetIsAreaNatural(this) == NWScript.AREA_ABOVEGROUND;
        public string     Tileset => NWScript.GetTilesetResRef(this);
        public int        PlayerCount => NWNX.Area.GetNumberOfPlayersInArea(this);
        public NWCreature LastEntered => NWNX.Area.GetLastEntered(this).AsCreature();
        public NWCreature LastLeft => NWNX.Area.GetLastLeft(this).AsCreature();
        public PvPSetting PvPSetting
        {
            get => NWNX.Area.GetPVPSetting(this);
            set => NWNX.Area.SetPVPSetting(this, value);
        }
        public int SpotModifier
        {
            get => NWNX.Area.GetAreaSpotModifier(this);
            set => NWNX.Area.SetAreaSpotModifier(this, value);
        }
        public int ListenModifier
        {
            get => NWNX.Area.GetAreaListenModifier(this);
            set => NWNX.Area.SetAreaListenModifier(this, value);
        }
        public bool IsRestingAllowed
        {
            get => !NWNX.Area.GetNoRestingAllowed(this);
            set => NWNX.Area.SetNoRestingAllowed(this, !value);
        }
        public int WindPower
        {
            get => NWNX.Area.GetWindPower(this);
            set => NWNX.Area.SetWindPower(this, value);
        }
        public float FogClipDistance
        {
            get => NWNX.Area.GetFogClipDistance(this);
            set => NWNX.Area.SetFogClipDistance(this, value);
        }
        public int ShadowOpacity
        {
            get => NWNX.Area.GetShadowOpacity(this);
            set => NWNX.Area.SetShadowOpacity(this, value);
        }
        public DayNightCycleType DayNightCycle
        {
            get => NWNX.Area.GetDayNightCycle(this);
            set => NWNX.Area.SetDayNightCycle(this, value);
        }
        public WeatherType Weather
        {
            get => (WeatherType)NWScript.GetWeather(this);
            set => NWScript.SetWeather(this, (int)value);
        }
        public int SkyBox
        {
            get => NWScript.GetSkyBox(this);
            set => NWScript.SetSkyBox(value, this);
        }
        public int SunFogColor
        {
            get => NWScript.GetFogColor(NWScript.FOG_TYPE_SUN, this);
            set => NWScript.SetFogColor(NWScript.FOG_TYPE_SUN, value, this);
        }
        public int SunFogAmount
        {
            get => NWScript.GetFogAmount(NWScript.FOG_TYPE_SUN, this);
            set => NWScript.SetFogAmount(NWScript.FOG_TYPE_SUN, value, this);
        }
        public int MoonFogColor
        {
            get => NWScript.GetFogColor(NWScript.FOG_TYPE_MOON, this);
            set => NWScript.SetFogColor(NWScript.FOG_TYPE_MOON, value, this);
        }
        public int MoonFogAmount
        {
            get => NWScript.GetFogAmount(NWScript.FOG_TYPE_MOON, this);
            set => NWScript.SetFogAmount(NWScript.FOG_TYPE_MOON, value, this);
        }

        public void RecomputeStaticLighting()
        {
            NWScript.RecomputeStaticLighting(this);
        }

        public IEnumerable<NWObject> Objects
        {
            get
            {
                for (var obj = NWScript.GetFirstObjectInArea(this).AsObject();
                     obj;
                     obj = NWScript.GetNextObjectInArea(this).AsObject())
                {
                    yield return obj;
                }
            }
        }
        public IEnumerable<NWCreature> Creatures
        {
            get
            {
                for (var obj = NWScript.GetFirstObjectInArea(this).AsCreature();
                     obj;
                     obj = NWScript.GetNextObjectInArea(this).AsCreature())
                {
                    if (obj.IsValidType)
                        yield return obj;
                }
            }
        }
    }
}
