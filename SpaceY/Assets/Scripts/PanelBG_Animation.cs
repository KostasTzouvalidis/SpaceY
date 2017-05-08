using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBG_Animation : MonoBehaviour {

	public float fadeInRate = 0.02f;

	void OnEnable() {
		StartCoroutine (PlayFadeInAnimation());
	}

	void OnDisable() {
		GetComponent<Image> ().color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
	}

	private IEnumerator PlayFadeInAnimation() {
		Color col = GetComponent<Image> ().color;
		while(col.a < 0.4f) {
			col.a += fadeInRate;
			GetComponent<Image> ().color = col;
			yield return new WaitForEndOfFrame ();
		}
		yield return null;
	}
}
