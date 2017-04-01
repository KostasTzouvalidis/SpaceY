using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Destroy : MonoBehaviour {

	private Hazard_Master hazardMaster;
	private Player_Master playerMaster;
	public GameObject destroyParticleEffect;

	void OnEnable() {
		InitializeReferences ();
		hazardMaster.EventDestroyed += DestroyMe;
	}
	
	void OnDisable() {
		hazardMaster.EventDestroyed -= DestroyMe;
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Spacecraft") {
			hazardMaster.CallEventDestroyed ();
			playerMaster.CallEventTakeDamage ();
		}
	}

	private void DestroyMe() {
		if (destroyParticleEffect != null) {
			GameObject par = Instantiate (destroyParticleEffect, this.transform.position, destroyParticleEffect.transform.rotation);
			GameObject.Destroy (par, 1.5f);
		}
		GameObject.Destroy (this.gameObject);
	}
	
	private void InitializeReferences() {
		hazardMaster = GetComponent<Hazard_Master> ();
		playerMaster = GameObject.Find ("Spacecraft").GetComponent<Player_Master> ();
	}
}
