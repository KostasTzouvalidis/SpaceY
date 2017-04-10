using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

	private Player_Master playerMaster;
	private int maxhealth;
	public int health;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventTakeDamage += ReduceHealth;
	}
	
	void OnDisable() {
		playerMaster.EventTakeDamage -= ReduceHealth;
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	private void ReduceHealth() {
		health--;
		if (health <= 0)
			playerMaster.CallEventDie ();
	}
	
	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
		maxhealth = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager_InitializeUIs> ().startingHealth;
		health = maxhealth;
	}
}
