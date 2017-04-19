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
		//GetComponent<Animation> ().Play ();
		/*this.transform.parent.*/GetComponent<Animator>().SetTrigger("PlayerInvulnerable");
	}
	
	private void InitializeReferences() {
		playerMaster = this.transform.GetChild(0).GetComponent<Player_Master> ();
	}
}
