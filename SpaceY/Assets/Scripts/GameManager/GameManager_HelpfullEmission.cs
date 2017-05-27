using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_HelpfullEmission : MonoBehaviour {

	private GameManager_Master gmMaster;
	public float emitRate;
	public float healthRate;
	public float shieldRate;
	public static bool shouldEmitHelpful;
	private float nextEm;

	void OnEnable() {
		InitializeReferences ();
		gmMaster.EventNextLevel += InitializeParameters;
	}
	
	void OnDisable() {
		gmMaster.EventNextLevel -= InitializeParameters;
	}
	
	void Update () {
		if (GameManager_Master.shouldEmit) {
			if (shouldEmitHelpful) {
				if (Time.time > nextEm) {
					nextEm = Time.time + Random.Range (emitRate - (0.15f * emitRate), emitRate + (0.35f * emitRate));
					RunHelpfulEmissionActions ();
				}
			}
		}
	}

	private void RunHelpfulEmissionActions() {

	}

	private void InitializeParameters() {
		emitRate = GameManager_LevelManager._levelData.helpfulEmissionRate;
	}
	
	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		InitializeParameters ();
	}
}
