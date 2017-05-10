using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_LevelManager : MonoBehaviour {

	private GameManager_Master gmMaster;
	private Player_Master playerMaster;
	private float startingTimer = 3;

	// Game States
	public static EmitState emitState;
	public static LevelState levelState;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventInput += EnableEmission;
	}
	
	void OnDisable() {
		
	}

	private void NextLevel() {
		
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
		gmMaster = GetComponent<GameManager_Master> ();
		emitState = EmitState.Regular;
		levelState = LevelState.L1;
	}
}
