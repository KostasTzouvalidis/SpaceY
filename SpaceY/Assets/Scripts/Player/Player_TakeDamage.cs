using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TakeDamage : MonoBehaviour {

	private Player_Master playerMaster;
	public float invulnerabilityDuration = 2;

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
		playerMaster.gameObject.layer = 9;
		StartCoroutine (ResetInvulnerability());
	}

	private IEnumerator ResetInvulnerability() {
		yield return new WaitForSeconds (invulnerabilityDuration);
		playerMaster.gameObject.layer = 8;
		playerMaster.isInvulnerable = false;
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
