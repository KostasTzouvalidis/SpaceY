using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Master : MonoBehaviour {
	
	public delegate void GeneralEventHandler();
	public delegate void OneParameterEventHandler(int val);
	public event GeneralEventHandler EventInput;
	public event GeneralEventHandler EventTakeDamage;
	public event GeneralEventHandler EventIncreaseHealth;
	public event GeneralEventHandler EventDie;
	public event GeneralEventHandler EventNoAmmo;
	public event GeneralEventHandler EventShoot;
	public event OneParameterEventHandler EventPickUpAmmo;

	public bool isInvulnerable = false;
	public bool canMove = true;

	public void CallEventInput() {
		if (EventInput != null)
			EventInput ();
	}

	public void CallEventTakeDamage() {
		if (EventTakeDamage != null)
			EventTakeDamage ();
	}

	public void CallEventIncreaseHealth() {
		if (EventIncreaseHealth != null) {
			EventIncreaseHealth ();
		}
	}

	public void CallEventDie() {
		if (EventDie != null)
			EventDie ();
	}
		
	public void CallEventNoAmmo() {
		if (EventNoAmmo != null)
			EventNoAmmo ();
	}

	public void CallEventShoot() {
		if (EventShoot != null)
			EventShoot ();
	}

	public void CallEventPickUpAmmo(int value) {
		if (EventPickUpAmmo != null)
			EventPickUpAmmo (value);
	}

}
