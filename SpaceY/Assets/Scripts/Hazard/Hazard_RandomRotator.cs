using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_RandomRotator : MonoBehaviour {
	public float minSpeed = 5;
	public float maxSpeed = 10;
	
	void Start () {
		this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Random.Range(minSpeed, maxSpeed); 
	}
}
