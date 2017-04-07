using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_PlayerCollision : MonoBehaviour {
	
	private Player_Master playerMaster;
	private GameObject playerGO;

	void Start() {
		InitializeReferences ();
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Spacecraft" && !playerMaster.isInvulnerable) {
			playerMaster.CallEventTakeDamage ();
		}
	}

	/*void OnCollisionStay (Collision col) {
		if (col.gameObject.name == "Spacecraft" && !playerMaster.isInvulnerable)
			playerMaster.CallEventTakeDamage ();
	}*/

	private void RepulsePlayer() {
		Rigidbody playerRig = playerGO.GetComponent<Rigidbody> ();
		Vector3 playerVelocity = playerRig.velocity;

		Debug.Log (playerVelocity.x);
		playerVelocity.x = -playerVelocity.x;
		playerRig.AddForce (playerVelocity * 3500);
	}

	private void InitializeReferences() {
		playerGO = GameObject.Find ("Spacecraft");
		playerMaster = GameManager_References._playerGO.GetComponent<Player_Master> ();
	}
}
