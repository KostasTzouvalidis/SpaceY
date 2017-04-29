using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EmitGiantHazardPhase : MonoBehaviour {

	private GameManager_Master gmMaster;
	private GameManager_EmitHazards emitHazardsComponent;
	private float nextGEm; // Next Giant Hazard emission.
	private float nextGEmPhase; // Next Giant hazard emission phase.
	private float nextGEmPhaseDelay = 20; // Giant hazard emission phase start check offset.
	private float GEm_PhaseRate = 25; // Giant hazard emission phase start check rate.
	private int hazardsNumber;

	public GameObject giantHazard;
	public float delay = 1.5f;
	public float duration = 5; // Fixed time of the phase.
	public float minRate;
	public float maxRate;

	void OnEnable() {
		InitializeReferences ();
		gmMaster.EventGiantHazardsPhase += RunGiantHazardEmissionActions;
	}
	
	void OnDisable() {
		gmMaster.EventGiantHazardsPhase -= RunGiantHazardEmissionActions;
	}
	
	void Start () {
		
	}
	
	void Update () {
		/*if (Time.time > nextGEmPhaseDelay) {
			if (Time.time > nextGEmPhase) {
				nextGEmPhase = Time.time + Random.Range (GEm_PhaseRate - 3, GEm_PhaseRate + 3);
				gmMaster.CallEventGiantHazardsPhase ();
			}
		}*/
	}

	private void RunGiantHazardEmissionActions() {
		if (GameManager_Master.shouldEmit) {
			StartCoroutine (GiantHazardEmission(minRate, maxRate));
		}
	}

	private IEnumerator GiantHazardEmission(float minRate, float maxRate) {
		GameManager_LevelManager.emitState = EmitState.Giant;
		emitHazardsComponent.enabled = false;
		float oldXPos = 5; // Out of valid X range value.
		yield return new WaitForSeconds (delay);
		hazardsNumber = Random.Range (5, 7);
		int i = 0;
		while(i < hazardsNumber) {
			float newXPos = FixedRandom.Range (-4, 4, 2);
			if (newXPos != oldXPos) {
				Instantiate (giantHazard, new Vector3 (newXPos, 0.0f, emitHazardsComponent.fixedZPosition), Quaternion.identity);
				oldXPos = newXPos;
				i++;
			} else {
				continue;
			}
			yield return new WaitForSeconds (Random.Range (minRate, maxRate));
		}
		yield return new WaitForSeconds (1);
		emitHazardsComponent.enabled = true;
		GameManager_LevelManager.emitState = EmitState.Regular;
	}
	
	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		emitHazardsComponent = GetComponent<GameManager_EmitHazards> ();
	}
}
