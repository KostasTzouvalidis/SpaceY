using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Ammo : MonoBehaviour {

	private Player_Master playerMaster;
	private readonly int AMMO_AMOUNT = 30;

	void Start() {
		InitializeReferences ();
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "Spacecraft") {
			playerMaster.CallEventPickUpAmmo (AMMO_AMOUNT);
		}
	}
	
	private void InitializeReferences() {
		playerMaster = GameObject.Find ("Spacecraft").GetComponent<Player_Master> ();
	}
}
