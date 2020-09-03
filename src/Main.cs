using System;
using NWN.Core;

namespace NWN
{
    // This is a simple callback class managed by Internal.cs.
    public static class Main {
        // Called once just before the module will load.
        public static void OnStart() {
            Console.WriteLine("Module loaded.");
        }

        // Called once just before the server will shutdown.
        public static void OnShutdown() {
            Console.WriteLine("Module shutting down.");
        }

        // This function is called once on every main loop of the engine. For this reason it has a large effect
        // on performance and should be used sparingly.
        public static void OnMainLoop(ulong frame) {}

        public static int OnRunScript(string script, uint oidSelf) {
            // All NWScript calls require an int return. For most script calls, this can be zero. For a
            // StartingConditional, it can be zero (false) or one (true). A return value of -1 means to pass
            // through DotNET and call the actual .ncs file in the module.
            int retVal = 0;

            // This switch statement illustrates how the template prompts individual script calls. Most
            // implementations will split this logic into a Dictionary or other sensible arrangement. Note that
            // a script does not need to be in the module for its name to be assigned. Many DotNET modules
            // have no .nss or .ncs files at all. Note that script names must always be shorter than 16
            // characters by an internal engine limitation.
            switch (script) {
                // An ordinary script. No return value set.
                case "x2_mod_def_load":
                    Console.WriteLine("Module started.");
                    break;
                // A conditional script. Return value set appropriately.
                case "chk_is_male":
                    retVal = NWScript.GetGender(NWScript.GetPCSpeaker()) == 0 ? 1 : 0;
                    break;
                // Fall through to NWScript. Note that if the script does not exist, this will not cause an error,
                // simply fail silently.
                default:
                    retVal = -1;
                    break;
            }

            return retVal;
        }
    }
}