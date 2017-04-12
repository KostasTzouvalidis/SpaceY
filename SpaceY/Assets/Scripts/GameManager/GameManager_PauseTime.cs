using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_PauseTime : MonoBehaviour {

	private GameManager_Master gmMaster;
	private bool isPaused;

	void OnEnable() {
		InitializeReferences ();
		gmMaster.EventGameMenu += ToggleFreezeTime;
	}
	
	void OnDisable() {
		gmMaster.EventGameMenu -= ToggleFreezeTime;
	}
	
	private void ToggleFreezeTime() {
		if(isPaused) {
			Time.timeScale = 1;
			isPaused = false;
		}
		else {
			Time.timeScale = 0;
			isPaused = true;
		}
	}
	
	private void InitializeReferences() {
		isPaused = false;
		gmMaster = GetComponent<GameManager_Master> ();
	}
}
