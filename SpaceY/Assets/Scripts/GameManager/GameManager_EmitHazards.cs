using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EmitHazards : MonoBehaviour {

	//private GameManager_Master gmMaster;
	[SerializeField] private GameObject[] hazards;
	[SerializeField] private GameObject specialHazard;
	[SerializeField] private GameObject giantHazard;
	private FixedRandom fr;
	private float nextEm; // Next Hazard emission

	public float minRate;
	public float maxRate;
	public float fixedZPosition;
	public float burstRate = 0.2f;
	public float specialHazardDelay = 15;
	public float specialHazardRate = 0.05f;

	void Start () {
		InitializeReferences ();
	}
	
	void FixedUpdate () {
		if (GameManager_Master.shouldEmit) {
			if (Time.time > nextEm) {
				nextEm = Time.time + Random.Range (minRate, maxRate);
				RunHazardEmissionActions ();
			}
		}
	}

	private void RunHazardEmissionActions() {
		float probability = Random.Range (0.0f, 1);
		if (probability < specialHazardRate) {
			if (Time.time > specialHazardDelay)
				SpecialHazardEmission ();
		}
		probability = Random.Range (0.0f, 1);

		if (probability < burstRate) {
			HazardBurst ();
			nextEm += nextEm * 0.013f;
		} else
			HazardEmission ();
	}

	private void HazardEmission() {
		float xPos = fr.GetFloatRange();
		Instantiate (hazards [Random.Range (0, hazards.Length)], new Vector3(xPos, 0.0f, fixedZPosition), Quaternion.identity);
	}

	private void HazardBurst() {
		float xPos;
		for (int i = 0; i < (int)Random.Range (2, 3); i++) {
			xPos = fr.GetFloatRange();
			Instantiate (hazards [Random.Range (0, hazards.Length)], new Vector3(xPos, 0.0f, fixedZPosition), Quaternion.identity);
		}
	}

	private void SpecialHazardEmission() {
		float xPos = fr.GetFloatRange();
		Instantiate (specialHazard, new Vector3(xPos, 0.0f, fixedZPosition), Quaternion.identity);
	}

	private void InitializeReferences() {
		//gmMaster = GetComponent<GameManager_Master> ();
		fr = new FixedRandom(-7, 7, 1);
	}
}