using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TakeDamage : MonoBehaviour {

	private Player_Master playerMaster;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventTakeDamage += TakeDamage;
		playerMaster.EventTakeDamage += MakeMeInvulnerable;
	}
	
	void OnDisable() {
		playerMaster.EventTakeDamage -= TakeDamage;
		playerMaster.EventTakeDamage -= MakeMeInvulnerable;
	}
	
	private void TakeDamage() {
		playerMaster.health--;
		if (playerMaster.health <= 0)
			playerMaster.CallEventDie ();
	}

	private void MakeMeInvulnerable() {
		playerMaster.isInvulnerable = true;
		StartCoroutine (ResetInvulnerability());
	}

	private IEnumerator ResetInvulnerability() {
		yield return new WaitForSeconds (2);
		playerMaster.isInvulnerable = false;
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
