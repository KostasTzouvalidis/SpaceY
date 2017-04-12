using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Master : MonoBehaviour {

	public delegate void GeneralEventHandler();
	public event GeneralEventHandler EventGameMenu;

	public static bool shouldEmit = false;
	public bool isGameMenuOn = false;
	public bool isGameOver = false;

	public void CallEventGameMenu() {
		if (EventGameMenu != null)
			EventGameMenu ();
	}
}
