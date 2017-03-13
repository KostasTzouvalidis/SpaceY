using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Master : MonoBehaviour {
	
	public delegate void GeneralEventHandler();
	public event GeneralEventHandler EventInput;
	public event GeneralEventHandler EventTakeDamage;
	public event GeneralEventHandler EventDie;

	public int health = 3;
	[SerializeField]
	public bool isInvulnerable = false;

	public void CallEventInput() {
		if (EventInput != null)
			EventInput ();
	}

	public void CallEventTakeDamage() {
		if (EventTakeDamage != null)
			EventTakeDamage ();
	}

	public void CallEventDie() {
		if (EventDie != null)
			EventDie ();
	}
}
