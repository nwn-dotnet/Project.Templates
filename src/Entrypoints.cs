using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace NWN {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NWNEventHandler : Attribute {
        private delegate void VoidScriptDelegate(string script);

        private delegate bool BoolScriptDelegate(string script);

        private readonly string _name;
        private static IReadOnlyDictionary<string, List<Delegate>>? _scripts;

        // constructor
        public NWNEventHandler(string script) {
            _name = script;
        }

        // main loop
        public static void OnMainLoop(ulong frame) {
            // Console.WriteLine($"MainLoop frame {frame}");
        }

        // on run script
        public static int OnRunScript(string script, uint oidSelf) {
            var callHash = script.GetHashCode().ToString();
            //Console.WriteLine($"{script} - {callHash} on: {oidSelf.ToString()}");
            if (!_scripts!.ContainsKey(callHash)) return -1;
            // iterate through all delegates stored
            var conditionalReturn = new List<bool>();

            // iterate delegates attached to this script call
            var index = 0;
            foreach (var d in _scripts[callHash]) {
                if (d.Method.ReturnType == typeof(void)) {
                    var del = (VoidScriptDelegate)d;
                    del.Invoke(script);
                    Console.WriteLine($"Script '{script}' | oid: ('{oidSelf.ToString()}') | internal: {callHash}");
                }
                else {
                    var del = (BoolScriptDelegate)d;
                    conditionalReturn[index] = del.Invoke(script);
                    Console.WriteLine($"Conditional script '{script}' | oid  '{oidSelf.ToString()}') | internal: {callHash}");
                    index++;
                }
            }

            return !conditionalReturn.Contains(false) ? 0 : 1;
        }

        public static void OnStart() {
            Console.WriteLine("Starting script registration...");
            _scripts = LoadHandlersFromAssembly();
            Console.WriteLine($"{_scripts.Count.ToString()} scripts registered");
        }

        private static IReadOnlyDictionary<string, List<Delegate>> LoadHandlersFromAssembly() {
            var result = new Dictionary<string, List<Delegate>>();

            var handlers = Assembly.GetExecutingAssembly()
              .GetTypes()
              .SelectMany(t => t.GetMethods())
              .Where(m => m.GetCustomAttributes(typeof(NWNEventHandler), false).Length > 0)
              .ToList();

            foreach (var mi in handlers) {
                foreach (var attr in mi.GetCustomAttributes(typeof(NWNEventHandler), false)) {
                    // name
                    var name = ((NWNEventHandler)attr)._name;
                    var hashName = name.GetHashCode().ToString();

                    // is return void
                    var isReturnVoid = mi.ReturnType == typeof(void);

                    // create delegates as proper types
                    Delegate d;
                    if (isReturnVoid) {
                        d = (VoidScriptDelegate)mi.CreateDelegate(typeof(VoidScriptDelegate));
                    }
                    else {
                        d = (BoolScriptDelegate)mi.CreateDelegate(typeof(BoolScriptDelegate));
                    }

                    // current list of delegates on function
                    var sharedScripts = !result.ContainsKey(name) ? new List<Delegate>() : result[name];

                    // add to list
                    sharedScripts.Add(d);
                    // and to the dictionary
                    result[hashName] = sharedScripts;
                }
            }

            return new ReadOnlyDictionary<string, List<Delegate>>(result);
        }
    }
}