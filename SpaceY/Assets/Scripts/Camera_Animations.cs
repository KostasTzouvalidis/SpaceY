using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Animations : MonoBehaviour {

	private Player_Master playerMaster;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventTakeDamage += PlayShakingAnimation;
	}
	
	void OnDisable() {
		playerMaster.EventTakeDamage -= PlayShakingAnimation;
	}

	private void PlayShakingAnimation() {
		GetComponent<Animation> ().Play ();
	}
	
	private void InitializeReferences() {
		playerMaster = GameObject.Find ("Spacecraft").GetComponent<Player_Master> ();
	}
}
