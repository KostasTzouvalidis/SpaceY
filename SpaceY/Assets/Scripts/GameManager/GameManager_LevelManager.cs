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

	// Leveling
	public LevelData[] levelData;
	public static LevelData _levelData;
	public int currentLevel = 1;

	void Awake() {
		InitializeReferences ();
		gmMaster.EventNextLevel += SwitchToNextLevelData;
	}

	void OnEnable() {
		playerMaster.EventInput += EnableEmission;
	}
	
	void OnDisable() {
		gmMaster.EventNextLevel -= SwitchToNextLevelData;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.A))
			gmMaster.CallEventNextLevel ();
	}

	private void SwitchToNextLevelData() {
		if (!NextLevelData ())
			Debug.Log ("Max");
	}

	private bool NextLevelData() {
		currentLevel++;
		if (!(currentLevel > levelData.Length)) {
			_levelData = levelData [currentLevel - 1];
			return true;
		} else {
			return false;
		}
	}

	private void EnableEmission() {
		StartCoroutine (EmitAfterSeconds());
		playerMaster.EventInput -= EnableEmission;
	}

	private IEnumerator EmitAfterSeconds() {
		yield return new WaitForSeconds (startingTimer);
		GameManager_Master.shouldEmit = true;
	}

	private void InitializeLevel() {
		_levelData = levelData[0];
		emitState = EmitState.Regular;
		levelState = LevelState.L1;
	}

	private void InitializeReferences() {
		InitializeLevel ();
		playerMaster = GameObject.Find("Spacecraft").GetComponent<Player_Master>();
		gmMaster = GetComponent<GameManager_Master> ();
	}
}
