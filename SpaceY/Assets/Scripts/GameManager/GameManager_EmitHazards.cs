using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EmitHazards : MonoBehaviour {

	//private GameManager_Master gmMaster;
	[SerializeField]
	private GameObject[] hazards;
	[SerializeField]
	private GameObject specialHazard;
	private FixedRandom fr;
	private float nextEm;
	public float minRate;
	public float maxRate;
	public float fixedZPosition;
	public float burstRate = 0.2f;
	public float specialHazardDelay = 15;
	public float specialHazardRate = 0.05f;

	void Start () {
		fr = new FixedRandom(-7, 7, 1);
	}
	
	void FixedUpdate () {
		if (Time.time > nextEm && GameManager_Master.shouldEmit) {
			nextEm = Time.time + Random.Range (minRate, maxRate);
			RunHazardEmissionActions ();
		}
	}

	private void RunHazardEmissionActions() {
		float probability = Random.Range (0.0f, 1);
		if (probability < specialHazardRate) {
			if(Time.time > specialHazardDelay)
				SpecialHazardEmmision ();
		}
		else if (probability < burstRate) {
			HazardBurst ();
			nextEm += nextEm * 0.016f;
		}
		else
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

	private void SpecialHazardEmmision() {
		float xPos = fr.GetFloatRange();
		Instantiate (specialHazard, new Vector3(xPos, 0.0f, fixedZPosition), Quaternion.identity);
	}

	private void InitializeReferences() {
		//gmMaster = GetComponent<GameManager_Master> ();
	}
}
