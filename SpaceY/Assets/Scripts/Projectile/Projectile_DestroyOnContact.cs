using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_DestroyOnContact : MonoBehaviour {
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.layer == 8) {
			GameObject.Destroy (this.gameObject);
		}
		Debug.Log ("1");
	}
}