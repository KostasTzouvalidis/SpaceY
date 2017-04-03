using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ammunition : MonoBehaviour {

	private Player_Master playerMaster;
	public int ammo = 0;
	private float checkRate = 0.5f;
	private float nextCheck;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventPickUpAmmo += PickUpAmmo;
	}

	void OnDisable() {
		playerMaster.EventPickUpAmmo -= PickUpAmmo;
	}

	void FixedUpdate() {
		if (Time.time > nextCheck) {
			nextCheck = Time.time + checkRate;
			CheckForAmmo ();
		}
	}

	private void PickUpAmmo(int amount) {
		ammo += amount;
	}

	private void CheckForAmmo() {
		if (ammo <= 0) {
			Debug.Log ("No ammo, but...");
			playerMaster.CallEventNoAmmo ();
		}
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
