using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager_InitializeUIs : MonoBehaviour {

	private GameManager_Master gmMaster;
	public GameObject healthPanel;
	public GameObject heartSprite;
	public int startingHealth = 3;
	// Misc
	private Quaternion defaultRotation;

	void Awake() {
		InitializeReferences ();
	}

	private void InitializeHealthCanvas() {
		GridLayoutGroup glg = healthPanel.GetComponent<GridLayoutGroup> ();
		for (int i = 0; i < startingHealth; i++) {
			GameObject heart = Instantiate (heartSprite);
			heart.transform.SetParent (glg.transform);
			heart.GetComponent<RectTransform> ().rotation = defaultRotation;
			heart.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
			Debug.Log (heart.GetComponent<RectTransform> ().rotation + "?");
		}
	}

	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		defaultRotation = new Quaternion (1, 0.0f, 0.0f, 1);
		InitializeHealthCanvas ();
	}
}
