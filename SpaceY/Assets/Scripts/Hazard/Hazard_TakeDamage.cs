using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_TakeDamage : MonoBehaviour {
	
	private Hazard_Master hazardMaster;
	public int health = 1;
	
	void OnEnable() {
		InitializeReferences ();
		hazardMaster.EventTakeDamage += ReduceHealth;
	}
	
	void OnDisable() {
		hazardMaster.EventTakeDamage -= ReduceHealth;
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.layer == 12) {
			hazardMaster.CallEventTakeDamage (col.GetComponent<Projectile_Attributes>().damageAmount);
		}
	}

	private void ReduceHealth(int amount) {
		health -= amount;
		if (health <= 0)
			hazardMaster.CallEventDestroyed ();
	}
	
	private void InitializeReferences() {
		hazardMaster = GetComponent<Hazard_Master> ();		
	}
}
