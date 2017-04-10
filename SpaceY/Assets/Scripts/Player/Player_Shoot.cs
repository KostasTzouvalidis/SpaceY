using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour {

	private Player_Master playerMaster;
	private float nextShoot;
	public GameObject laserBolt;
	public Transform shootingPosition;
	public float shootRate = 0.25f;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventShoot += ShootEm;
	}

	void OnDisable() {
		playerMaster.EventShoot -= ShootEm;
	}

	void FixedUpdate () {
		if (Time.time > nextShoot && GetComponent<Player_Ammunition> ().ammo > 0) {
			nextShoot = Time.time + shootRate;
			playerMaster.CallEventShoot ();
		}
	}

	private void ShootEm() {
		//Testing
		GetComponent<Player_Ammunition> ().ammo--;
		Instantiate(laserBolt, shootingPosition.position, Quaternion.LookRotation(Vector3.up));
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
