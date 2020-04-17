using NWN.NWNX.Enum;

namespace NWN.NWNX {
  public static class Feedback {
    private const string PLUGIN_NAME = "NWNX_Feedback";

    public static int GetFeedbackMessageHidden(FeedbackMessageTypes messageType, NWObject? player = null) {
      if (player == null) player = NWScript.OBJECT_INVALID.AsObject();
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetMessageHidden");
      Internal.NativeFunctions.nwnxPushInt((int) messageType);
      Internal.NativeFunctions.nwnxPushInt(0);
      Internal.NativeFunctions.nwnxPushObject(player);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt();
    }

    public static void SetFeedbackMessageHidden(FeedbackMessageTypes messageType, int hide, NWObject? player = null) {
      if (player == null) player = NWScript.OBJECT_INVALID.AsObject();
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetMessageHidden");
      Internal.NativeFunctions.nwnxPushInt(hide);
      Internal.NativeFunctions.nwnxPushInt((int) messageType);
      Internal.NativeFunctions.nwnxPushInt(0);
      Internal.NativeFunctions.nwnxPushObject(player);
      Internal.NativeFunctions.nwnxCallFunction();
    }

    public static int GetCombatLogMessageHidden(FeedbackMessageTypes messageType, NWObject? player = null) {
      if (player == null) player = NWScript.OBJECT_INVALID.AsObject();
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetMessageHidden");
      Internal.NativeFunctions.nwnxPushInt((int) messageType);
      Internal.NativeFunctions.nwnxPushInt(1);
      Internal.NativeFunctions.nwnxPushObject(player);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt();
    }

    public static void SetCombatLogMessageHidden(FeedbackMessageTypes messageType, int hide,
      NWObject? player = null) {
      if (player == null) player = NWScript.OBJECT_INVALID.AsObject();
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetMessageHidden");
      Internal.NativeFunctions.nwnxPushInt(hide);
      Internal.NativeFunctions.nwnxPushInt((int) messageType);
      Internal.NativeFunctions.nwnxPushInt(1);
      Internal.NativeFunctions.nwnxPushObject(player);
      Internal.NativeFunctions.nwnxCallFunction();
    }

    public static int GetJournalUpdatedMessageHidden(NWObject? player = null) {
      if (player == null) player = NWScript.OBJECT_INVALID.AsObject();
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetMessageHidden");
      Internal.NativeFunctions.nwnxPushInt(0);
      Internal.NativeFunctions.nwnxPushInt(2);
      Internal.NativeFunctions.nwnxPushObject(player);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt();
    }

    public static void SetFeedbackMessageMode(int whiteList) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetFeedbackMode");
      Internal.NativeFunctions.nwnxPushInt(whiteList);
      Internal.NativeFunctions.nwnxPushInt(0);
      Internal.NativeFunctions.nwnxCallFunction();
    }

    public static void SetCombatLogMessageMod(int whiteList) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetFeedbackMode");
      Internal.NativeFunctions.nwnxPushInt(whiteList);
      Internal.NativeFunctions.nwnxPushInt(1);
      Internal.NativeFunctions.nwnxCallFunction();
    }
  }
}