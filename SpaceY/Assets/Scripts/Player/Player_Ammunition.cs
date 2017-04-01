using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ammunition : MonoBehaviour {

	private Player_Master playerMaster;
	[SerializeField]
	private int ammo = 0;
	private float checkRate = 0.5f;
	private float nextCheck;
	public int specialHazardLayer;

	void Start() {
		InitializeReferences ();
	}

	void FixedUpdate() {
		if (Time.time > nextCheck) {
			nextCheck = Time.time + checkRate;
			CheckForAmmo ();
		}
	}

	private void PickUpAmmo(int amount) {
		ammo += amount;
		playerMaster.GetComponent<Player_Shoot> ().canShoot = true;
	}

	private void CheckForAmmo() {
		if (ammo == 0) {
			playerMaster.CallEventNoAmmo ();
		}
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
