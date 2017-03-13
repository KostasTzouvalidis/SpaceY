using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_PlayerRepulsion : MonoBehaviour {

	private Player_Master playerMaster;
	private GameObject playerGO;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventTakeDamage += RepulsePlayer;
	}
	
	void OnDisable() {
		playerMaster.EventTakeDamage -= RepulsePlayer;
	}
	
	private void RepulsePlayer() {
		//if (!playerMaster.isInvulnerable) {
			Rigidbody playerRig = playerGO.GetComponent<Rigidbody> ();
			Vector3 playerVelocity = playerRig.velocity;

			playerVelocity.x = -playerVelocity.x;
			playerRig.AddForce (playerVelocity * 1500);
			//playerVelocity.x = -playerVelocity.x;
			//playerRig.velocity = playerVelocity * 0.01f;
		//}
	}
	
	private void InitializeReferences() {
		playerGO = GameObject.Find ("Spacecraft");
		playerMaster = playerGO.GetComponent<Player_Master> ();
	}
}
