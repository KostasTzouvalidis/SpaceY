using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_UI : MonoBehaviour {

	private Player_Master playerMaster;
	public GameObject healthCanvas;
	public GameObject AmmoCanvas;
	//Misc
	private List<Image> imageComponents;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventTakeDamage += ReduceHealthUI;
	}
	
	void OnDisable() {
		playerMaster.EventTakeDamage -= ReduceHealthUI;
	}
	
	void Start () {
		InitializeImageComponents ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			playerMaster.CallEventTakeDamage ();
		}
	}

	/*
	 * Sets the last heartSprite inactive and removes it from the imageComponent list
	 */
	private void ReduceHealthUI() {
		if (imageComponents.Count > 0) {
			int lastIndex = imageComponents.Count - 1;
			imageComponents [lastIndex].gameObject.SetActive (false);
			imageComponents.RemoveAt (lastIndex);
		}
	}

	private void IncreaseHealthUI() {

	}

	private void UpdateAmmoUI() {

	}

	private List<T> GetChildrenWithoutParent<T>(T[] com) {
		List<T> compWithoutParent = new List<T>();
		for (int i = 1; i < com.Length; i++)
			compWithoutParent.Add (com [i]);
		
		return compWithoutParent;
	}

	private void InitializeImageComponents() {
		Canvas hCanvas = healthCanvas.GetComponent<Canvas> ();
		//Gets the child = Panel GO and then its Image components = UI.Image
		Image[] images = hCanvas.transform.GetChild (0).GetComponentsInChildren<Image> ();
		imageComponents = GetChildrenWithoutParent<Image> (images);
	}

	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
	}
}
