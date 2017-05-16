using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager_UIMaster : MonoBehaviour {

	private GameManager_Master gmMaster;
	public GameObject healthPanel;
	public GameObject heartSprite;
	public GameObject gameMenuCanvas;
	public int startingHealth = 3;

	void Awake() {
		InitializeReferences ();
	}

	void OnEnable() {

	}

	void OnDisable() {

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

	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		InitializeHealthPanel ();
		InitializeGameMenuCanvas ();
	}
}
