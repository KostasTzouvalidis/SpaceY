using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_RandomMover : MonoBehaviour {

	private float minSpeed;
	private float maxSpeed;

	void OnEnable() {
		if (name.Contains ("_Big")) { // If it is a LowPoly_Rock_1
			minSpeed = GameManager_LevelManager._levelData.hazardsParameters.minSpeed_Big;
			maxSpeed = GameManager_LevelManager._levelData.hazardsParameters.maxSpeed_Big;
		} else { // Else if it is a LowPoly_Rock_1
			minSpeed = GameManager_LevelManager._levelData.hazardsParameters.minSpeed_Reg;
			maxSpeed = GameManager_LevelManager._levelData.hazardsParameters.maxSpeed_Reg;
		}
	}

	void Start() {
		this.GetComponent<Rigidbody>().velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
	}
}
