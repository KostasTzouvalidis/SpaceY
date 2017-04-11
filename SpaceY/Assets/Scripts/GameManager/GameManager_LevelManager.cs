using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_LevelManager : MonoBehaviour {

	private Player_Master playerMaster;
	private float startingTimer = 3;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventInput += EnableEmission;
	}
	
	void OnDisable() {
	}

	private void EnableEmission() {
		StartCoroutine (EmitAfterSeconds());
		playerMaster.EventInput -= EnableEmission;
	}

	private IEnumerator EmitAfterSeconds() {
		yield return new WaitForSeconds (startingTimer);
		GameManager_Master.shouldEmit = true;
	}

	private void InitializeReferences() {
		playerMaster = GameObject.Find("Spacecraft").GetComponent<Player_Master>();		
	}
}
