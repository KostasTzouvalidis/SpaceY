using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Destroy : MonoBehaviour {

	private Hazard_Master hazardMaster;
	public GameObject destroyParticleEffect;

	void OnEnable() {
		InitializeReferences ();
		hazardMaster.EventDestroyed += DestroyMe;
	}
	
	void OnDisable() {
		hazardMaster.EventDestroyed -= DestroyMe;
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "Spacecraft")
			hazardMaster.CallEventDestroyed ();
	}

	private void DestroyMe() {
		Instantiate (destroyParticleEffect, this.transform.position, destroyParticleEffect.transform.rotation);
		GameObject.Destroy (this.gameObject);
	}
	
	private void InitializeReferences() {
		hazardMaster = GetComponent<Hazard_Master> ();
	}
}
