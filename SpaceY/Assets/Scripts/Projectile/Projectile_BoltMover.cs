﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_BoltMover : MonoBehaviour {

	public float speed = 20;

	void Start() {
		this.GetComponent<Rigidbody>().velocity = Vector3.forward * speed; 
	}
}
