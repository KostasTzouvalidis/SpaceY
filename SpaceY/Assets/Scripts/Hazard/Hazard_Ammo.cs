using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Ammo : MonoBehaviour {

	private Player_Master playerMaster;
	private readonly int AMMO_AMOUNT = 10;

	void OnEnable() {
		InitializeReferences ();
	}
	
	void OnDisable() {
		
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "Spacecraft") {
			playerMaster.CallEventPickUpAmmo (AMMO_AMOUNT);
			Debug.Log ("!");
		}
	}
	
	private void InitializeReferences() {
		playerMaster = GameObject.Find ("Spacecraft").GetComponent<Player_Master> ();
	}
}
