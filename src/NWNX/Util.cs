using NWN.NWNX.Enum;

namespace NWN.NWNX {
  public static class Util {
    private const string PLUGIN_NAME = "NWNX_Util";

    public static string GetCurrentScriptName(int depth = 0) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetCurrentScriptName");
      Internal.NativeFunctions.nwnxPushInt(depth);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopString();
    }

    public static string GetAsciiTableString() {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetAsciiTableString");
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopString();
    }

    public static int Hash(string str) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "Hash");
      Internal.NativeFunctions.nwnxPushString(str);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt();
    }

    public static string GetCustomToken(int customTokenNumber) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "customTokenNumber");
      Internal.NativeFunctions.nwnxPushInt(customTokenNumber);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopString();
    }

    public static NWN.ItemProperty EffectToItemProperty(NWN.Effect effect) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "EffectTypeCast");
      Internal.NativeFunctions.nwnxPushEffect(effect.Handle);
      Internal.NativeFunctions.nwnxCallFunction();
      return new NWN.ItemProperty(Internal.NativeFunctions.nwnxPopItemProperty());
    }

    public static NWN.Effect ItemPropertyToEffect(NWN.ItemProperty ip) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "EffectTypeCast");
      Internal.NativeFunctions.nwnxPushItemProperty(ip.Handle);
      Internal.NativeFunctions.nwnxCallFunction();
      return new NWN.Effect(Internal.NativeFunctions.nwnxPopEffect());
    }

    public static int IsValidResRef(string resRef, int type = (int) ResRefType.Creature) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "IsValidResRef");
      Internal.NativeFunctions.nwnxPushInt(type);
      Internal.NativeFunctions.nwnxPushString(resRef);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt();
    }

    public static int GetMinutesPerHour() {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetMinutesPerHour");
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt();
    }

    public static void SetMinutesPerHour(int minutes) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "SetMinutesPerHour");
      Internal.NativeFunctions.nwnxPushInt(minutes);
      Internal.NativeFunctions.nwnxCallFunction();
    }

    public static string EncodeStringForURL(string url) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "EncodeStringForURL");
      Internal.NativeFunctions.nwnxPushString(url);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopString();
    }

    public static int Get2DARowCount(string str) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "Get2DARowCount");
      Internal.NativeFunctions.nwnxPushString(str);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt();
    }

    public static string GetFirstResRef(ResRefType type, string regexFilter = "", bool moduleResourcesOnly = true) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetFirstResRef");
      Internal.NativeFunctions.nwnxPushInt(moduleResourcesOnly ? 1 : 0);
      Internal.NativeFunctions.nwnxPushString(regexFilter);
      Internal.NativeFunctions.nwnxPushInt((int) type);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopString();
    }

    public static string GetNextResRef() {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetNextResRef");
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopString();
    }

    public static int GetServerTicksPerSecond() {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetServerTicksPerSecond");
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt();
    }

    public static bool PluginExists(string plugin) {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "PluginExists");
      Internal.NativeFunctions.nwnxPushString(plugin);
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopInt() != 0;
    }

    public static string GetUserDirectory() {
      Internal.NativeFunctions.nwnxSetFunction(PLUGIN_NAME, "GetUserDirectory");
      Internal.NativeFunctions.nwnxCallFunction();
      return Internal.NativeFunctions.nwnxPopString();
    }
  }
}