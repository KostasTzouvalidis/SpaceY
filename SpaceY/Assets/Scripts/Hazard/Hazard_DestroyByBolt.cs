using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_DestroyByBolt : MonoBehaviour {
	private Hazard_Master hazardMaster;
	
	void Start () {
		InitializeReferences ();
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.layer == 12)
			hazardMaster.CallEventDestroyed ();
	}
	
	private void InitializeReferences() {
		hazardMaster = GetComponent<Hazard_Master> ();
	}
}
