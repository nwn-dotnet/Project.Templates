namespace NWN.Events {
  public class UseSkillEvent : NWNXEvent {
    public delegate void EventDelegate(UseSkillEvent e);

    public const string BEFORE_USE_SKILL = "NWNX_ON_USE_SKILL_BEFORE";
    public const string AFTER_USE_SKILL = "NWNX_ON_USE_SKILL_AFTER";

    public static EventDelegate BeforeUseSkill = delegate { };
    public static EventDelegate AfterUseSkill = delegate { };

    public UseSkillEvent(string script) {
      EventType = script;
    }

    public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();
    public NWItem Item => GetEventObject("USED_ITEM_OBJECT_ID").AsItem();
    public NWObject Target => GetEventObject("TARGET_OBJECT_ID").AsObject();
    public Vector TargetPosition => GetEventVector("TARGET_POSITION");
    public int SkillID => GetEventInt("SKILL_ID");
    public int SubSkillID => GetEventInt("SUB_SKILL_ID");

    [NWNEventHandler(BEFORE_USE_SKILL)]
    [NWNEventHandler(AFTER_USE_SKILL)]
    public static void EventHandler(string script) {
      var e = new UseSkillEvent(script);
      switch (script) {
        case BEFORE_USE_SKILL:
          BeforeUseSkill(e);
          break;
        case AFTER_USE_SKILL:
          AfterUseSkill(e);
          break;
      }
    }
  }
}