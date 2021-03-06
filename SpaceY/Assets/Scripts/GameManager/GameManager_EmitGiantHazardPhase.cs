﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EmitGiantHazardPhase : MonoBehaviour {

	private GameManager_Master gmMaster;
	private float nextGEm; // Next Giant Hazard emission.
	private float nextGEmPhase; // Next Giant hazard emission phase.
	private float nextGEmPhaseDelay = 20; // Giant hazard emission phase start check offset.
	private float GEm_PhaseRate = 30; // Giant hazard emission phase start check rate.
	private int hazardsNumber;
	private bool shouldEmitGiant;

	public GameObject giantHazard;
	public float delay = 1.5f;
	public int numberOfHazards = 5;
	public float minRate;
	public float maxRate;

	void OnEnable() {
		InitializeReferences ();
		gmMaster.EventGiantHazardsPhase += RunGiantHazardEmissionActions;
		gmMaster.EventNextLevel += InitializeLevelParameters;
	}
	
	void OnDisable() {
		StopCoroutine("GiantHazardEmission");
		gmMaster.EventGiantHazardsPhase -= RunGiantHazardEmissionActions;
		gmMaster.EventNextLevel -= InitializeLevelParameters;
	}

	void Update () {
		if (Time.time > nextGEmPhaseDelay && shouldEmitGiant) {
			if (Time.time > nextGEmPhase) {
				nextGEmPhase = Time.time + Random.Range (GEm_PhaseRate - 3, GEm_PhaseRate + 7);
				gmMaster.CallEventGiantHazardsPhase ();
				gmMaster.CallEventPhaseChanged ("EmitGiantHazardPhase");
			}
		}
	}

	private void RunGiantHazardEmissionActions() {
		if (GameManager_Master.shouldEmit) {
			StartCoroutine (GiantHazardEmission(minRate, maxRate));
		}
	}

	private IEnumerator GiantHazardEmission(float minRate, float maxRate) {
		GameManager_LevelManager.emitState = EmitState.Giant;
		//emitHazardsComponent.enabled = false;
		float oldXPos = 5; // Out of valid X range value.
		yield return new WaitForSeconds (delay);
		//hazardsNumber = numberOfHazards;
		int i = 0;
		while(i < numberOfHazards) {
			float newXPos = FixedRandom.Range (-4, 4, 2);
			if (newXPos != oldXPos) {
				Instantiate (giantHazard, new Vector3 (newXPos, 0.0f, GameManager_EmitHazards.fixedZPosition), Quaternion.identity);
				oldXPos = newXPos;
				i++;
			} else {
				continue;
			}
			yield return new WaitForSeconds (Random.Range (minRate, maxRate));
		}
		yield return new WaitForSeconds (1);
		gmMaster.CallEventPhaseChanged ("EmitHazards");
		GameManager_LevelManager.emitState = EmitState.Regular;
	}

	private void InitializeLevelParameters() {
		minRate = GameManager_LevelManager._levelData.minGiantEmissionRate;
		maxRate = GameManager_LevelManager._levelData.maxGiantEmissionRate;
		numberOfHazards = GameManager_LevelManager._levelData.numberOfGiantHazards;
		shouldEmitGiant = GameManager_LevelManager._levelData.shouldEmitGiantHazards;
	}
	
	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		InitializeLevelParameters ();
	}
}