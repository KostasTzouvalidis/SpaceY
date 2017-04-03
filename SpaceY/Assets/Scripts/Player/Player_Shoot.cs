using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour {

	private Player_Master playerMaster;
	private float nextShoot;
	public GameObject laserBolt;
	public Transform shootingPosition;
	public float shootRate = 0.25f;

	void Start() {
		InitializeReferences ();
	}

	void FixedUpdate () {
		if (Time.time > nextShoot && GetComponent<Player_Ammunition> ().ammo > 0) {
			nextShoot = Time.time + shootRate;
			ShootEm ();
		}
	}

	private void ShootEm() {
		//Testing
		Instantiate(laserBolt, shootingPosition.position, Quaternion.LookRotation(Vector3.up));
		GetComponent<Player_Ammunition> ().ammo--;
		Debug.Log ("Pat");
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
