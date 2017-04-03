using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_DestroyByBoundary : MonoBehaviour {

	//Value of Z axis where it should be destroyed.
	public float minZToDestroy = -15;

	void Update () {
		CheckIfShouldDestroy ();
	}

	private void CheckIfShouldDestroy() {
		if(this.transform.position.z < minZToDestroy) {
			Destroy (this.gameObject);
		}
	}
}
