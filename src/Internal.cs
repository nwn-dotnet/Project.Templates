using NWN.Core;
using System;
using System.Collections.Generic;

namespace NWN {
    public class Internal : IGameManager {
        // Instance of ServerCore singleton.
        public static Internal Instance { get; } = new Internal();

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

        // Entrypoint from NWNX.
        public static int Bootstrap(IntPtr ptr, int nativeHandlesLength) {
            // Call internal bootstrap function
            return NWNCore.Init(ptr, nativeHandlesLength, Instance);
        }

        public void OnMainLoop(ulong frame) => Main.OnMainLoop(frame);

        public void OnSignal(string signal) {
            switch (signal) {
                case "ON_MODULE_LOAD_FINISH":
                    Main.OnStart();
                    break;
                case "ON_DESTROY_SERVER":
                    Main.OnShutdown();
                    break;
            }
        }

        public int OnRunScript(string script, uint oidSelf) {
            ObjectSelf = oidSelf;
            ScriptContexts.Push(new ScriptContext { OwnerObject = oidSelf, ScriptName = script });

            int retVal = Main.OnRunScript(script, oidSelf);

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

        public void ClosureAssignCommand(uint obj, ActionDelegate func) {
            if (VM.ClosureAssignCommand(obj, NextEventId) != 0)
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
        }

        public void ClosureDelayCommand(uint obj, float duration, ActionDelegate func) {
            if (VM.ClosureDelayCommand(obj, duration, NextEventId) != 0)
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
        }

        public void ClosureActionDoCommand(uint obj, ActionDelegate func) {
            if (VM.ClosureActionDoCommand(obj, NextEventId) != 0)
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
        }
    }
}