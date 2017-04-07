using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager_InitializeUIs : MonoBehaviour {

	private GameManager_Master gmMaster;
	public GameObject healthPanel;
	public GameObject heartSprite;
	public int startingHealth = 3;

	void Awake() {
		InitializeReferences ();
	}

	private void InitializeHealthCanvas() {
		GridLayoutGroup glg = healthPanel.GetComponent<GridLayoutGroup> ();
		for (int i = 0; i < startingHealth; i++) {
			GameObject heart = Instantiate (heartSprite);
			heart.transform.SetParent (glg.transform);
		}
		Debug.Log (healthPanel.name);
	}

	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		InitializeHealthCanvas ();
	}
}
