using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {
	
	private Player_Master playerMaster;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventTakeDamage += PlayInvulnerableAnimation;
	}

	void OnDisable() {
		playerMaster.EventTakeDamage -= PlayInvulnerableAnimation;
	}

	private void PlayInvulnerableAnimation() {
		GetComponent<Animation> ().Play ();
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
