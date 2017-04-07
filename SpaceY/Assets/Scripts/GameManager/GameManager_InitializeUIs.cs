using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager_InitializeUIs : MonoBehaviour {

	private GameManager_Master gmMaster;
	public GameObject healthCanvas;
	public GameObject heartSprite;
	public int startingHealth = 3;

	void Awake() {
		InitializeReferences ();
	}

	private void InitializeHealthCanvas() {
		Canvas hCanvas = healthCanvas.GetComponent<Canvas> ();
		Transform panel = hCanvas.transform.GetChild (0);
		GridLayoutGroup glg = panel.GetComponent<GridLayoutGroup> ();
		for (int i = 0; i < startingHealth; i++) {
			GameObject heart = Instantiate (heartSprite);
			heart.transform.SetParent (glg.transform);
		}
		Debug.Log (panel.name);
	}

	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		InitializeHealthCanvas ();
	}
}
