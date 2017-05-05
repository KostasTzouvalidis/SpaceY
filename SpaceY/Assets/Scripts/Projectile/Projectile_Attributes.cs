using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Attributes : MonoBehaviour {

	public float speed = 20;
	public int damageAmount = 1;

	void Start() {
		this.GetComponent<Rigidbody>().velocity = Vector3.forward * speed; 
	}
}
