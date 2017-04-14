using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBG_Animation : MonoBehaviour {

	private Animation fadeInAnimation;
	//private GameManager_Master gmMaster;

	void Awake() {
		InitializeReferences ();
	}

	void OnEnable() {
		fadeInAnimation.GetComponent<Image> ().color = new Color(0.5f, 0.4f, 0.0f, 0.5f);
		fadeInAnimation.Play();
		Debug.Log ("Enabled");
	}
	
	void OnDisable() {
		fadeInAnimation.GetComponent<Image> ().color = new Color();
		Debug.Log ("Disabled");
	}
	
	void Start () {
		
	}
	
	private void PlayFadeInAnimation() {
		
			
	}
	
	private void InitializeReferences() {
		fadeInAnimation = GetComponent<Animation> ();
		//gmMaster = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameManager_Master> ();
	}
}
