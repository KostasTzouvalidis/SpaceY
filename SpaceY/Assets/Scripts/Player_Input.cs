using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour {
	private Player_Master playerMaster;
	//TODO - GameManager_Master reference.

	void Start () {
		InitializeReferences ();		
	}
	
	void Update () {
		CheckIfCanMove ();
	}

	private void CheckIfCanMove() {
		if(Input.GetMouseButtonDown(0))
			playerMaster.CallEventInput ();
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
