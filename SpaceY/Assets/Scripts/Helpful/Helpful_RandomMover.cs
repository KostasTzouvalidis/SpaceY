using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpful_RandomMover : MonoBehaviour {
	
	public float speed = 7;

	void Start () {
		Rigidbody myRig = this.GetComponent<Rigidbody> ();
		myRig.velocity = Vector3.back * speed;
		foreach (Rigidbody r in this.gameObject.GetComponentsInChildren<Rigidbody>()) {
			r.velocity = Vector3.back * speed;
		}
	}
}
