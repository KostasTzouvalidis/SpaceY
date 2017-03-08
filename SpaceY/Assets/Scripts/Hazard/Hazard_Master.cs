using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Master : MonoBehaviour {
	
	public delegate void GeneralEventHandler();
	public event GeneralEventHandler EventDestroyed;
	public event GeneralEventHandler EventMakeDamage;

	public void CallEventDestroyed() {
		if (EventDestroyed != null)
			EventDestroyed ();
	}

	public void CallEventMakeDamage() {
		if (EventMakeDamage != null)
			EventMakeDamage ();
	}
}
