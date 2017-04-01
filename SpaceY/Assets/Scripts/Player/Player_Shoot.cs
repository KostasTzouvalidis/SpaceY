using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour {

	private Player_Master playerMaster;
	public bool canShoot = false;

	void OnEnable() {
		
	}
	
	void OnDisable() {
		
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
