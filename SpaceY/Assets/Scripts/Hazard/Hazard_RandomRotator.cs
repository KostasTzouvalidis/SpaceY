using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_RandomRotator : MonoBehaviour {

	public float minSpeed = 5;
	public float maxSpeed = 10;
	public bool onlyZAxis = false;

	void Start () {
		if (!onlyZAxis)
			this.GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * Random.Range (minSpeed, maxSpeed);
		else {
			Vector3 angVel = this.GetComponent<Rigidbody> ().angularVelocity;
			angVel.z = Random.insideUnitSphere.z * Random.Range(minSpeed, maxSpeed);
			this.GetComponent<Rigidbody> ().angularVelocity = angVel;
		}			
	}
}
