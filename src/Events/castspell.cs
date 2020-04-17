using NWN.Enums;

namespace NWN.Events {
  public class CastSpellEvent : NWNXEvent {
    public delegate void EventDelegate(CastSpellEvent e);

    public const string BEFORE_CAST_SPELL = "NWNX_ON_CAST_SPELL_BEFORE";
    public const string AFTER_CAST_SPELL = "NWNX_ON_CAST_SPELL_AFTER";

    public static EventDelegate BeforeCastSpell = delegate { };
    public static EventDelegate AfterCastSpell = delegate { };

    public CastSpellEvent(string script) {
      EventType = script;
    }

    public NWCreature Caster => Internal.OBJECT_SELF.AsCreature();
    public Spell SpellID => (Spell) GetEventInt("SPELL_ID");
    public Vector TargetPosition => GetEventVector("TARGET_POSITION");
    public NWObject TargetObject => GetEventObject("TARGET_OBJECT").AsObject();
    public NWItem Item => GetEventObject("ITEM_OBJECT_ID").AsItem();
    public int MultiClass => GetEventInt("MULTI_CLASS"); // ?
    public bool SpellCountered => GetEventInt("SPELL_COUNTERED") == 1;
    public bool CounteringSpell => GetEventInt("COUNTERING_SPELL") == 1;
    public ProjectilePathType ProjectilePathType => (ProjectilePathType) GetEventInt("PROJECTILE_PATH_TYPE");
    public bool IsInstantSpell => GetEventInt("IS_INSTANT_SPELL") == 1;

    [NWNEventHandler(BEFORE_CAST_SPELL)]
    [NWNEventHandler(AFTER_CAST_SPELL)]
    public static void EventHandler(string script) {
      var e = new CastSpellEvent(script);
      switch (script) {
        case BEFORE_CAST_SPELL:
          BeforeCastSpell(e);
          break;
        case AFTER_CAST_SPELL:
          AfterCastSpell(e);
          break;
      }
    }
  }
}