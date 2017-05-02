using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class GameManager_ComponentManager : MonoBehaviour {

	private GameManager_Master gmMaster;
	private Dictionary<string, Component> scriptComponents = new Dictionary<string, Component> ();

	public class NamedComponent {
		[SerializeField] private string componentName;
		[SerializeField] private Component component;

		public NamedComponent() {}

		public NamedComponent(string cN, Component c) {
			componentName = cN;
			c = component;
		}

		public string GetComponentName() {return componentName;}
		public Component GetComponent() {return component;}
	}

	void OnEnable() {
		InitializeScriptComponents ();
		//gmMaster.EventGiantHazardsPhase +=
	}
	
	void OnDisable() {
		
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	private void InitializeScriptComponents() {
		Component[] cs = GetComponents (typeof(Component));
		foreach (Component c in cs) {
			if (Regex.IsMatch (c.GetType ().ToString (), "_Emit"))
				scriptComponents.Add (c.GetType ().ToString ().Substring(12), c);
		}
	}

	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		InitializeScriptComponents ();
	}
}
