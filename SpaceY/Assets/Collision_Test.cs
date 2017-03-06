using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Test : MonoBehaviour {
	
	void OnTriggerEnter(Collider col) {
		if (col.name == "Spacecraft")
			Debug.Log("asd");
	}
}
