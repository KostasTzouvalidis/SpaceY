using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_RandomMover : MonoBehaviour {

	public float minSpeed = 5;
	public float maxSpeed = 10;

	void Start() {
		this.GetComponent<Rigidbody>().velocity = Vector3.back * Random.Range(minSpeed, maxSpeed); 
	}
}
