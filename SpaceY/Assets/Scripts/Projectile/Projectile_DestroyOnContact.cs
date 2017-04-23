using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_DestroyOnContact : MonoBehaviour {

	public GameObject hitSparcle;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.layer == 8) {
			GameObject sparcle = Instantiate (hitSparcle, transform.position + (transform.localScale - transform.localScale / 2), Quaternion.identity);
			GameObject.Destroy (sparcle.gameObject, 1);
			GameObject.Destroy (this.gameObject);
		}
	}
}