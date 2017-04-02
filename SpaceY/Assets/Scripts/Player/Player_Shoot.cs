using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour {

	private Player_Master playerMaster;
	private float nextShoot;
	public bool canShoot = false;
	public float shootRate = 0.25f;

	void OnEnable() {
		InitializeReferences ();
	}
	
	void OnDisable() {
		playerMaster.EventNoAmmo += StopShooting;
	}
	
	void Start () {
		playerMaster.EventNoAmmo -= StopShooting;
	}
	
	void FixedUpdate () {
		if (Time.time > nextShoot) {
			nextShoot = Time.time + shootRate;
			ShootEm ();
		}
	}

	private void ShootEm() {
		//Testing
		if (canShoot) {
			playerMaster.GetComponent<Player_Ammunition> ().ammo--;
			Debug.Log ("Pat");
		}
	}

	private void StopShooting() {
		canShoot = false;
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
