using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ComponentManager : MonoBehaviour {

	private GameManager_Master gmMaster;
	public HashSet<Component> hs;

	void OnEnable() {
		//gmMaster.EventGiantHazardsPhase += 
	}
	
	void OnDisable() {
		
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
	}
}
