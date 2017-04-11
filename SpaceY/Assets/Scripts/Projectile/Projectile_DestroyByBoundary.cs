using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_DestroyByBoundary : MonoBehaviour {

	//Value of Z axis where it should be destroyed.
	public float zToDestroy = -15;
	public bool upwardDirection = false;

	void Update () {
		CheckIfShouldDestroy ();
	}

	private void CheckIfShouldDestroy() {
		if(this.transform.position.z < zToDestroy && !upwardDirection) {
			Destroy (this.gameObject);
		}
		if (this.transform.position.z > zToDestroy && upwardDirection) {
			Destroy (this.gameObject);
		}			
	}
}
