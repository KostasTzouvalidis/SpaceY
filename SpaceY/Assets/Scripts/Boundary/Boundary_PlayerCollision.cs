using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_PlayerCollision : MonoBehaviour {
	
	private Player_Master playerMaster;

	void Start() {
		InitializeReferences ();
	}

	void OnTriggerEnter(Collider col) {
		if (col.name == "Spacecraft" && !playerMaster.isInvulnerable)
			playerMaster.CallEventTakeDamage ();
	}

	private void InitializeReferences() {
		playerMaster = GameManager_References._playerGO.GetComponent<Player_Master> ();
	}
}
