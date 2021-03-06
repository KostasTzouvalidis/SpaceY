﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EmitHazards : MonoBehaviour {

	private GameManager_Master gmMaster;
	[SerializeField] private GameObject[] hazards;
	[SerializeField] private GameObject specialHazard;
	private FixedRandom fr;
	private float nextEm; // Next Hazard emission

	public float minRate;
	public float maxRate;
	public static float fixedZPosition = 20;
	public float burstRate = 0.2f;
	public float specialHazardDelay = 15;
	public float specialHazardRate = 0.05f;
	public float specialHazardEmitOffset = 4;
	private float specialHazardTimer;
	private float specialHazardEmitOffsetTimer;
	private readonly float _specialHazardTimerStart = 9;

	//Debug
	private float instantiatedXPos;

	void OnEnable() {
		InitializeReferences ();
		gmMaster.EventNextLevel += InitializeLevelParameters;
	}

	void OnDisable() {
		gmMaster.EventNextLevel -= InitializeLevelParameters;
	}

	void Update () {
		if (GameManager_Master.shouldEmit) {
			if (Time.time > nextEm) {
				nextEm = Time.time + Random.Range (minRate, maxRate);
				RunHazardEmissionActions ();
			}
			specialHazardTimer -= Time.deltaTime;
			specialHazardEmitOffsetTimer -= Time.deltaTime;
		}
	}

	private void RunHazardEmissionActions() {
		float probability;
		if (specialHazardEmitOffsetTimer <= 0) {
			probability = Random.Range (0.0f, 1);
			if (probability < specialHazardRate) {
				if (Time.time > specialHazardDelay)
					SpecialHazardEmission ();
			}
		}

		probability = Random.Range (0.0f, 1);
		if (probability < burstRate) {
			HazardBurst ();
		} else
			HazardEmission ();

		//Prevent special hazards from missing for a long time (_specialHazardTimerStart).
		if (specialHazardTimer <= 0) {
			SpecialHazardEmission ();
		}
	}

	private void HazardEmission() {
		float xPos = fr.GetFloatRange();
		instantiatedXPos = xPos;
		Instantiate (hazards [Random.Range (0, hazards.Length)], new Vector3(xPos, 0.0f, fixedZPosition), Quaternion.identity);
	}

	private void HazardBurst() {
		float newXPos, oldXPos = 8; // An invalid value.
		int i = 0;
		int numOfHazards = (int)Random.Range (2, 3);
		while (i < numOfHazards) {
			newXPos = fr.GetFloatRange();
			if (newXPos != oldXPos && Mathf.Abs (newXPos - oldXPos) >= 2) {
				Instantiate (hazards [Random.Range (0, hazards.Length)], new Vector3 (newXPos, 0.0f, fixedZPosition), Quaternion.identity);
				oldXPos = newXPos;
				i++;
			} else {
				continue;
			}
		}
	}

	private void SpecialHazardEmission() {
		float xPos = fr.GetFloatRange();
		Vector3 position = new Vector3 (xPos, 0.0f, fixedZPosition);
		// Prevent from instantiating in the same X position of a random hazard.
		while (true) {
			if (xPos != instantiatedXPos) {
				Instantiate (specialHazard, position, Quaternion.identity);
				break;
			} else {
				xPos = fr.GetFloatRange();
				position = new Vector3 (xPos, 0.0f, fixedZPosition);
			}
		}
		specialHazardEmitOffsetTimer = specialHazardEmitOffset;
		specialHazardTimer = _specialHazardTimerStart;
	}

	private void InitializeLevelParameters() {
		minRate = GameManager_LevelManager._levelData.minRegularEmissionRate;
		maxRate = GameManager_LevelManager._levelData.maxRegularEmissionRate;
		burstRate = GameManager_LevelManager._levelData.burstRate;
		specialHazardRate = GameManager_LevelManager._levelData.specialHazardRate;
	}

	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		specialHazardTimer = _specialHazardTimerStart;
		fr = new FixedRandom(-7, 7, 1.4f);
		InitializeLevelParameters();
	}
}