using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_UI : MonoBehaviour {

	private Player_Master playerMaster;
	private Player_Ammunition playerAmmo;
	public GameObject healthPanel;
	public GameObject ammoPanel;
	//Misc
	private List<Image> imageComponents;
	private Text ammoText;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventTakeDamage += ReduceHealthUI;
		playerMaster.EventShoot += UpdateAmmoUI;
	}
	
	void OnDisable() {
		playerMaster.EventTakeDamage -= ReduceHealthUI;
		playerMaster.EventShoot -= UpdateAmmoUI;
	}
	
	void Start () {
		InitializeImageComponents ();
	}
	
	void Update () {
		
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
		int ammo = playerAmmo.ammo-1;
		Debug.Log (ammo);
		if (ammo != 0)
			ammoText.text = ammo.ToString ();
		else
			ammoText.text = "";
	}

	private List<T> GetChildrenWithoutParent<T>(T[] com) {
		List<T> compWithoutParent = new List<T>();
		for (int i = 1; i < com.Length; i++)
			compWithoutParent.Add (com [i]);
		
		return compWithoutParent;
	}

	private void InitializeImageComponents() {
		//Gets the child = Panel GO and then its Image components = UI.Image
		Image[] images = healthPanel.GetComponentsInChildren<Image> ();
		imageComponents = GetChildrenWithoutParent<Image> (images);
	}

	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
		playerAmmo = GetComponent<Player_Ammunition> ();
		ammoText = ammoPanel.transform.GetChild (0).GetComponent<Text> ();
	}
}
