using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_References : MonoBehaviour {

	public static GameObject _playerGO;
	[SerializeField]
	private string playerName;

	void Awake () {
		if (playerName == "") {
			Debug.LogWarning ("GameManager_References: Please add a proper Player name.");
			return;
		}
		_playerGO = GameObject.Find (playerName);
	}

	private void InitializeReferences() {
		if (playerName == "") {
			Debug.LogWarning ("GameManager_References: Please add a proper Player name.");
			return;
		}
		_playerGO = GameObject.Find (playerName);
		if (_playerGO == null)
			Debug.Log ("!");
	}
}