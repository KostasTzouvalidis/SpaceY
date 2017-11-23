using UnityEditor;
using UnityEngine;

public static class UsefulShortcuts {
	[MenuItem("Tools/Clear Console &#c")] //Alt + Shift + C
	static void ClearConsole() {
		var logEntries = System.Type.GetType ("UnityEditor.LogEntries, UnityEditor.dll"); // For 2017 UnityEditor instead of UnityEditorInternal
		var clearMethod = logEntries.GetMethod ("Clear", System.Reflection.BindingFlags.Static |
		                  System.Reflection.BindingFlags.Public);
		clearMethod.Invoke (null, null);
	}
}
