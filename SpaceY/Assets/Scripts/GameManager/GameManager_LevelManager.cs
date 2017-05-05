using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmitState {
	Regular,
	Giant,
	Boss
};

public enum LevelState {
	L1,
	L2,
	L3
};

public class GameManager_LevelManager : MonoBehaviour {

	private GameManager_Master gmMaster;
	private Player_Master playerMaster;
	private float startingTimer = 3;

	// Game States
	public static EmitState emitState;
	public static LevelState levelState;

	// Giant Hazard variables.
	private float nextGEm; // Next Giant Hazard emission.
	private float nextGEmPhase; // Next Giant hazard emission phase.
	private float nextGEmPhaseDelay = 20; // Giant hazard emission phase start check offset.
	private float GEm_PhaseRate = 25; // Giant hazard emission phase start check rate.

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventInput += EnableEmission;
	}
	
	void OnDisable() {
		
	}

	void Update() {
		if (Time.time > nextGEmPhaseDelay) {
			if (Time.time > nextGEmPhase) {
				nextGEmPhase = Time.time + Random.Range (GEm_PhaseRate - 3, GEm_PhaseRate + 3);
				gmMaster.CallEventGiantHazardsPhase ();
			}
		}
		// TODO - Should I use timers?!?
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
