using UnityEditor;
using UnityEngine;

public static class UsefulShortcuts {
	[MenuItem("Tools/Clear Console &#c")] //Alt + Shift + C
	static void ClearConsole() {
		var logEntries = System.Type.GetType ("UnityEditorInternal.LogEntries, UnityEditor.dll");
		var clearMethod = logEntries.GetMethod ("Clear", System.Reflection.BindingFlags.Static |
		                  System.Reflection.BindingFlags.Public);
		clearMethod.Invoke (null, null);
	}
}
