using System;
using NWN.Core;

namespace NWN
{
  public class ServerCore
  {
    public static int Bootstrap(IntPtr intPtr, int length)
    {
      CoreGameManager coreGameManager = new CoreGameManager();
      coreGameManager.OnSignal += OnSignal;
      coreGameManager.OnRunScript += OnRunScript;
      coreGameManager.OnServerLoop += OnServerLoop;

      return NWNCore.Init(intPtr, length, coreGameManager);
    }

    private static void OnRunScript(string scriptName, uint objectSelf, out int scriptHandleResult) {
      // This switch statement illustrates how the template prompts individual script calls. Most
      // implementations will split this logic into a Dictionary or other sensible arrangement. Note that
      // a script does not need to be in the module for its name to be assigned. Many DotNET modules
      // have no .nss or .ncs files at all. Note that script names must always be shorter than 16
      // characters by an internal engine limitation.
      switch (scriptName)
      {
        // An ordinary script. No return value set.
        case "x2_mod_def_load":
          Console.WriteLine("Module started.");
          break;
        // A conditional script. Return value set appropriately.
        case "chk_is_male":
          scriptHandleResult = NWScript.GetGender(NWScript.GetPCSpeaker()) == 0 ? 1 : 0;
          break;
      }

      // default return value
      scriptHandleResult = -1;
    }

    private static void OnSignal(string signal)
    {
      switch (signal)
      {
        case "ON_MODULE_LOAD_FINISH":
          break;
        case "ON_DESTROY_SERVER":
          break;
      }
    }

    private static void OnServerLoop(ulong frame)
    {
    }
  }
}
