using System;
using System.Linq;
using System.Collections.Generic;

namespace NWN
{
    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple=true)]
    public class NWNEventHandler : System.Attribute
    {
        public delegate void ScriptDelegate(string script);
        public static Dictionary<string, string> EventNamesShortLong = new Dictionary<string, string>();
        public static Dictionary<string, ScriptDelegate> Scripts;
        public const int MAX_CHARS_IN_SCRIPT_NAME = 16;
        public const int SCRIPT_HANDLED = 0;
        public const int SCRIPT_NOT_HANDLED = -1;
        private static int numFakeNames;

        public string Script;
        public NWNEventHandler(string script) { Script = script; }

        public static void OnMainLoop(ulong frame)
        {
            // Console.WriteLine($"MainLoop frame {frame}");
        }

        public static int OnRunScript(string script, uint oidSelf)
        {
            if (EventNamesShortLong.ContainsKey(script)) {
                var longName = EventNamesShortLong[script];
                Console.WriteLine($"Handling '{script}' ('{longName}') on oid {oidSelf}");
                Scripts[longName](longName);
                return SCRIPT_HANDLED;
            }
            Console.WriteLine($"Passing '{script}' on oid {oidSelf} to nwscript");
            return SCRIPT_NOT_HANDLED;
        }

        public static void OnStart()
        {
            Console.WriteLine("OnStart() called");
            Scripts = GetHandlersFromAssembly();

            Events.ExamineEvent.AfterExamineObject += e => Console.WriteLine($"{e.Player.Name} examined {e.ExaminedObject.Name}");
        }

        public static void SubscribeToNWNXEvents()
        {
            foreach (var (key, value) in EventNamesShortLong.Where(p=>p.Key.StartsWith("nx-")))
            {
                Console.WriteLine($"Registering {key} -> {value}");
                NWNX.Events.SubscribeEvent(value, key);
            }
        }

        public static string GetShortName(string script)
        {
            // Console.WriteLine($"GetShortName({script})");
            if (EventNamesShortLong.ContainsValue(script))
                return EventNamesShortLong.First(p => p.Value==script).Key;
            if (script.Length <= MAX_CHARS_IN_SCRIPT_NAME)
                return script;
            const string prefix = "NWNX_";
            if (!script.StartsWith(prefix))
                return script.Substring(0, MAX_CHARS_IN_SCRIPT_NAME);

            var suffix = script.Substring(script.LastIndexOf('_') + 1);
            var name = script.Substring(prefix.Length, script.Length-suffix.Length-prefix.Length-1);
            if (name.Length > MAX_CHARS_IN_SCRIPT_NAME - 5)
                name = name.Substring(0, MAX_CHARS_IN_SCRIPT_NAME-10) + $"-{numFakeNames++}";
            return $"nx-{name.Replace('_', '-')}-{suffix.Substring(0, 1)}".ToLower();
        }

        public static Dictionary<string, ScriptDelegate> GetHandlersFromAssembly()
        {
            var result = new Dictionary<string, ScriptDelegate>();
            var handlers = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(NWNEventHandler), false).Length > 0)
                .ToArray();

            foreach (var mi in handlers)
            {
                var del = (ScriptDelegate) mi.CreateDelegate(typeof(ScriptDelegate));
                foreach (var attr in mi.GetCustomAttributes(typeof(NWNEventHandler), false))
                {
                    var script = (attr as NWNEventHandler).Script;
                    var shortName = GetShortName(script);
                    if (shortName.Length > MAX_CHARS_IN_SCRIPT_NAME || shortName.Length == 0)
                    {
                        Console.WriteLine($"Bad short name for {script}: {shortName}");
                        throw new ApplicationException();
                    }
                    if (EventNamesShortLong.ContainsKey(shortName))
                    {
                        Console.WriteLine($"Attempting to register script twice: {script} ({shortName})");
                        throw new ApplicationException();
                    }
                    EventNamesShortLong[shortName] = script;
                    result[script] = del;
                }
            }
            return result;
        }
    }
}
