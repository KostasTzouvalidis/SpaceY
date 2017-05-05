using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Master : MonoBehaviour {
	
	public delegate void GeneralEventHandler();
	public delegate void DamageEventHandler (int health);
	public event GeneralEventHandler EventDestroyed;
	public event DamageEventHandler EventTakeDamage;

	public void CallEventDestroyed() {
		if (EventDestroyed != null)
			EventDestroyed ();
	}

	public void CallEventTakeDamage(int health) {
		if (EventTakeDamage != null)
			EventTakeDamage (health);
	}
}
