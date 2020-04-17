using NWN.NWNX.Enum;

namespace NWN.NWNX {
  public class Rename {
    private const string PLUGIN_NAME = "NWNX_Rename";

    public static void SetPCNameOverride(NWObject target, string newName, string prefix, string suffix,
      NameOverrideType playerNameState = NameOverrideType.Default, NWObject? observer = null) {
      if (observer == null) observer = NWScript.OBJECT_INVALID.AsObject();
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetPCNameOverride");
      Internal.NativeFunctions.nwnxPushObject(observer);
      Internal.NativeFunctions.nwnxPushInt((int) playerNameState);
      Internal.NativeFunctions.nwnxPushString(suffix);
      Internal.NativeFunctions.nwnxPushString(prefix);
      Internal.NativeFunctions.nwnxPushString(newName);
      Internal.NativeFunctions.nwnxPushObject(target);
      Internal.NativeFunctions.nwnxCallFunction();
    }

    public static string GetPCNameOverride(NWObject target, NWObject? observer = null) {
      if (observer == null) observer = NWScript.OBJECT_INVALID.AsObject();
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetPCNameOverride");
      Internal.NativeFunctions.nwnxPushObject(observer);
      Internal.NativeFunctions.nwnxPushObject(target);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopString();
    }

    public static void ClearPCNameOverride(NWObject target, NWObject? observer = null, bool clearAll = false) {
      if (observer == null) observer = NWScript.OBJECT_INVALID.AsObject();
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "ClearPCNameOverride");
      Internal.NativeFunctions.nwnxPushInt(clearAll ? 1 : 0);
      Internal.NativeFunctions.nwnxPushObject(observer);
      Internal.NativeFunctions.nwnxPushObject(target);
      Internal.NativeFunctions.nwnxCallFunction();
    }
  }
}