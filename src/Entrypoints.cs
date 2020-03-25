using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NWN.Events;

namespace NWN {
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class NWNEventHandler : Attribute {
		public delegate void ScriptDelegate(string script);

		public const int MaxCharsInScriptName = 16;
		public const int ScriptHandled = 0;
		public const int ScriptNotHandled = -1;

		public static Dictionary<string, string> EventNamesShortLong = new Dictionary<string, string>();
		public static Dictionary<string, ScriptDelegate>? Scripts;
		private static int _numFakeNames;

		public string Script;

		public NWNEventHandler(string script) {
			Script = script;
		}

		public static void OnMainLoop(ulong frame) {
			// Console.WriteLine($"MainLoop frame {frame}");
		}

		public static int OnRunScript(string script, uint oidSelf) {
			if (EventNamesShortLong.ContainsKey(script)) {
				var longName = EventNamesShortLong[script];
				Console.WriteLine($"Handling '{script}' ('{longName}') on oid {oidSelf}");
				Scripts![longName](longName);
				return ScriptHandled;
			}

			Console.WriteLine($"Passing '{script}' on oid {oidSelf} to nwscript");
			return ScriptNotHandled;
		}

		public static void OnStart() {
			Console.WriteLine("OnStart() called");
			Scripts = GetHandlersFromAssembly();
		}

		public static void SubscribeToNwnxEvents() {
			if (EventNamesShortLong == null) return;
			var count = 0;
			foreach (var (key, value) in EventNamesShortLong) {
				if (!key.StartsWith("nx-")) continue;
				count++;
				NWNX.Events.SubscribeEvent(value, key);
			}
			Console.WriteLine($"Registered {count} NWNXEE Events");
		}

		public static string GetShortName(string script) {
			//Console.WriteLine($"GetShortName({script})");
			if (EventNamesShortLong.ContainsValue(script))
				return EventNamesShortLong.First(p => p.Value == script).Key;
			if (script.Length <= MaxCharsInScriptName)
				return script;
			const string prefix = "NWNX_";
			if (!script.StartsWith(prefix))
				return script.Substring(0, MaxCharsInScriptName);

			var suffix = script.Substring(script.LastIndexOf('_') + 1);
			var name = script.Substring(prefix.Length, script.Length - suffix.Length - prefix.Length - 1);
			if (name.Length > MaxCharsInScriptName - 5)
				name = name.Substring(0, MaxCharsInScriptName - 10) + $"-{_numFakeNames++}";
			return $"nx-{name.Replace('_', '-')}-{suffix.Substring(0, 1)}".ToLower();
		}

		public static Dictionary<string, ScriptDelegate> GetHandlersFromAssembly() {
			var result = new Dictionary<string, ScriptDelegate>();
			var handlers = Assembly.GetExecutingAssembly()
				.GetTypes()
				.SelectMany(t => t.GetMethods())
				.Where(m => m.GetCustomAttributes(typeof(NWNEventHandler), false).Length > 0)
				.ToArray();

			foreach (var mi in handlers) {
				var del = (ScriptDelegate) mi.CreateDelegate(typeof(ScriptDelegate));
				foreach (var attr in mi.GetCustomAttributes(typeof(NWNEventHandler), false)) {
					var script = ((NWNEventHandler) attr).Script;
					var shortName = GetShortName(script);
					Console.WriteLine("Registered " + script + ":" + shortName);
					if (shortName.Length > MaxCharsInScriptName || shortName.Length == 0) {
						Console.WriteLine($"Bad short name for {script}: {shortName}");
						throw new ApplicationException();
					}

					if (EventNamesShortLong.ContainsKey(shortName)) {
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