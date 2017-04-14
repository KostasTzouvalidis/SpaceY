using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour {
	private Player_Master playerMaster;
	public GameObject staticCanvas;

	void Start () {
		InitializeReferences ();		
	}
	
	void Update () {
		CheckIfCanMove ();
	}

	private void CheckIfCanMove() {
		if(Input.GetMouseButtonDown(0) &&
			!RectTransformUtility.RectangleContainsScreenPoint(
				staticCanvas.transform.GetChild(0).GetComponent<RectTransform>(),
				Input.mousePosition))
			playerMaster.CallEventInput ();
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}