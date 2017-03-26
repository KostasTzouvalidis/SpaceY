using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EmitHazards : MonoBehaviour {

	private GameManager_Master gmMaster;
	[SerializeField]
	private GameObject[] hazards;
	public float minRate;
	public float maxRate;

	void OnEnable() {
		
	}
	
	void OnDisable() {
		
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	public void HazardEmission() {
		//TODO - Random hazard emission...
	}
	
	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
	}
}
