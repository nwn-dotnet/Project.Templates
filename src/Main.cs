using NWN.Core;
using System;
using System.Collections.Generic;

namespace NWN {
    public class ServerCore : IGameManager {
        // Instance of ServerCore singleton.
        public static ServerCore Instance { get; } = new ServerCore();

        //Delegates
        public delegate int ScriptDelegate(string script);

        // Class and struct definitions.
        private struct ScriptContext {
            public uint OwnerObject;
            public string ScriptName;
        }

        private struct Closure {
            public uint OwnerObject;
            public ActionDelegate Run;
        }

        //Object self for scripts
        public uint ObjectSelf { get; private set; } = NWScript.OBJECT_INVALID;

        // Native Management
        private readonly Stack<ScriptContext> ScriptContexts = new Stack<ScriptContext>();
        private readonly Dictionary<ulong, Closure> Closures = new Dictionary<ulong, Closure>();
        private ulong NextEventId = 0;

        // Bootstrap function. Some setup may occur here but it is best done in a module load script (see below)
        public static int Bootstrap(IntPtr ptr, int nativeHandlesLength) {
            // Call internal bootstrap function
            return Internal.Init(ptr, nativeHandlesLength, Instance);
        }

        // This function is called once on every main loop of the engine. For this reason it has a large effect 
        // on performance and should be used sparingly.
        public void OnMainLoop(ulong frame) {
            // Console.WriteLine($"MainLoop frame {frame}");
        }

        public int OnRunScript(string script, uint oidSelf) {
            ObjectSelf = oidSelf;
            ScriptContexts.Push(new ScriptContext { OwnerObject = oidSelf, ScriptName = script });

            // All NWScript calls require an int return. For most script calls, this can be zero. For a 
            // StartingConditional, it can be zero (false) or one (true). A return value of -1 means to pass 
            // through DotNET and call the actual .ncs file in the module.
            int retVal = 0;

            // This switch statement illustrates how the template prompts individual script calls. Most 
            // implementations will split this logic into a Dictionary or other sensible arrangement. Note that 
            // a script does not need to be in the module for its name to be assigned. Many DotNET modules 
            // have no .nss or .ncs files at all.
            switch (script) {
                // An ordinary script. No return value set.
                case "x2_mod_def_load":
                    Console.WriteLine("Module loaded.");
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

            ScriptContexts.Pop();
            ObjectSelf = ScriptContexts.Count == 0 ? NWScript.OBJECT_INVALID : ScriptContexts.Peek().OwnerObject;
            return retVal;
        }

        public void OnClosure(ulong eid, uint oidSelf) {
            var old = ObjectSelf;
            ObjectSelf = oidSelf;
            try {
                Closures[eid].Run();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            Closures.Remove(eid);
            ObjectSelf = old;
        }

        //Closures are for events that happen separately on the stack, specifically AssignCommand, DelayCommand, 
        // and ActionDoCommand. Most implementations do not change these.
        public void ClosureAssignCommand(uint obj, ActionDelegate func) {
            if (Internal.NativeFunctions.ClosureAssignCommand(obj, NextEventId) != 0)
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
        }

        public void ClosureDelayCommand(uint obj, float duration, ActionDelegate func) {
            if (Internal.NativeFunctions.ClosureDelayCommand(obj, duration, NextEventId) != 0)
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
        }

        public void ClosureActionDoCommand(uint obj, ActionDelegate func) {
            if (Internal.NativeFunctions.ClosureActionDoCommand(obj, NextEventId) != 0)
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
        }
    }
}