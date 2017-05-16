using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager_UIMaster : MonoBehaviour {

	private GameManager_Master gmMaster;
	public GameObject healthPanel;
	public GameObject heartSprite;
	public GameObject gameMenuCanvas;
	public GameObject levelBanner;
	public int startingHealth = 3;

	private readonly string LEVEL_TAG = "Level ";

	void Awake() {
		InitializeReferences ();
	}

	void OnEnable() {
		gmMaster.EventNextLevel += NextLevelBanner;
	}

	void OnDisable() {
		gmMaster.EventNextLevel -= NextLevelBanner;
	}

	private void NextLevelBanner() {
		levelBanner.GetComponentInChildren<Text> ().text = LEVEL_TAG + GameManager_LevelManager._currentLevel;
		StartCoroutine (showNextLevelBanner());
	}

	private IEnumerator showNextLevelBanner() {
		levelBanner.SetActive (true);
		yield return new WaitForSeconds (1);
		levelBanner.SetActive (false);
	}

	private void InitializeHealthPanel() {
		GridLayoutGroup glg = healthPanel.GetComponent<GridLayoutGroup> ();
		for (int i = 0; i < startingHealth; i++) {
			GameObject heart = Instantiate (heartSprite);
			heart.transform.SetParent (glg.transform, false);
		}
	}

	private void InitializeGameMenuCanvas() {
		gameMenuCanvas.SetActive (false);
		gmMaster.isGameMenuOn = false;
	}

	private void InitializeLevelbanner() {
		levelBanner.SetActive(false);
	}

	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		InitializeHealthPanel ();
		InitializeGameMenuCanvas ();
		InitializeLevelbanner ();
	}
}
