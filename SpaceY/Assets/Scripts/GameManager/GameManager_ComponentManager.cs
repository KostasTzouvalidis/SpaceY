using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class GameManager_ComponentManager : MonoBehaviour {

	private GameManager_Master gmMaster;
	private Dictionary<string, Component> scriptComponents = new Dictionary<string, Component> ();

	void OnEnable() {
		InitializeReferences ();
		gmMaster.EventPhaseChanged += EnableCurrentPhase;
	}

	void OnDisable() {
		gmMaster.EventPhaseChanged -= EnableCurrentPhase;
	}

	private void InitializeScriptComponents() {
		Component[] cs = GetComponents (typeof(Component));
		foreach (Component c in cs) {
			if (Regex.IsMatch (c.GetType ().ToString (), "_Emit*"))
				scriptComponents.Add (c.GetType ().ToString ().Substring(12), c);
		}
	}

	private void EnableCurrentPhase(string toPhaseIndex) {
		if (toPhaseIndex != "EmitHazards") {
			Component script;
			if (scriptComponents.TryGetValue (toPhaseIndex, out script))
				DisableAllOtherScripts (toPhaseIndex);
		} else {
			EnableAllScripts ();
		}
	}

	private void DisableAllOtherScripts(string toPhaseIndex) {
		MonoBehaviour scriptMB;
		foreach (KeyValuePair<string, Component> script in scriptComponents) {
			if (script.Key != toPhaseIndex) {
				scriptMB = (MonoBehaviour)script.Value;
				scriptMB.enabled = false;
			}
		}
	}

	private void EnableAllScripts() {
		MonoBehaviour scriptMB;
		foreach(Component script in scriptComponents.Values) {
			scriptMB = (MonoBehaviour)script;
			scriptMB.enabled = true;
		}
	}

	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		InitializeScriptComponents ();
	}
}
