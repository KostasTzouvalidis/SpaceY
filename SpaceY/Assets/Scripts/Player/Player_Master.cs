using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Master : MonoBehaviour {
	
	public delegate void GeneralEventHandler();
	public event GeneralEventHandler EventInput;

	public void CallEventInput() {
		if (EventInput != null)
			EventInput ();
	}
}
