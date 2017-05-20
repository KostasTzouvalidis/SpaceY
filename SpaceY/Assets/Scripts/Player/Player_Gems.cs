using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gems : MonoBehaviour {

	private Player_Master playerMaster;
	private int numberOfGems;
	private GameObject gemsPanel;
	
	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventPickUpGem += GotMoreGems;
	}
	
	void OnDisable() {
		playerMaster.EventPickUpGem -= GotMoreGems;
	}
	
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Gem") {
			playerMaster.CallEventPickUpGem (1);
		}
	}

	private void GotMoreGems(int number) {
		numberOfGems += number;
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
		numberOfGems = 0;
	}
}
