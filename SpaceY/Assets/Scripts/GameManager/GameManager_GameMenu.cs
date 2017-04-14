using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_GameMenu : MonoBehaviour {

	private GameManager_Master gmMaster;
	//private Player_Master playerMaster;
	public GameObject gameMenu;

	void OnEnable() {
		InitializeReferences ();
		gmMaster.EventGameMenu += ToggleMenu;
	}
	
	void OnDisable() {
		gmMaster.EventGameMenu -= ToggleMenu;
	}
	
	void Update () {
		CheckForGameMenuToggle ();
		GetBackToGame ();
	}

	private void CheckForGameMenuToggle() {
		if (Input.GetKeyDown (KeyCode.Escape) && !gmMaster.isGameOver) {
			gmMaster.CallEventGameMenu ();
			if(gmMaster.isGameMenuOn)
				gmMaster.EventGameMenu += GetBackToGame;
		}
	}

	private void GetBackToGame() {
		if (Input.GetMouseButtonDown (0) && gmMaster.isGameMenuOn &&
			!RectTransformUtility.RectangleContainsScreenPoint(
				gameMenu.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>(),
				Input.mousePosition)) {
			gmMaster.CallEventGameMenu ();
			gmMaster.EventGameMenu -= GetBackToGame;
		}
	}

	private void ToggleMenu() {
		// Will use this when the main menu scene is built.
		//if (SceneManager.GetActiveScene ().buildIndex != 0) {
		gameMenu.SetActive(!gameMenu.activeSelf);
		gmMaster.isGameMenuOn = !gmMaster.isGameMenuOn;
		//}
	}

	public void UIResume() {
		gmMaster.CallEventGameMenu ();
	}
	
	private void InitializeReferences() {
		gmMaster = GetComponent<GameManager_Master> ();
		//playerMaster = GameObject.Find ("Spacecraft").GetComponent<Player_Master> ();
	}
}
