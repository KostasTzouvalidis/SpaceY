using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelLevelInfo_Animation : MonoBehaviour {

	private Text levelText;
	private RectTransform panelRect;
	private Color textColor;

	void OnEnable() {
		InitializeReferences ();
		PlaySizeUpAnimation ();
	}
	
	void OnDisable() {
		ResetParameters ();
	}

	private void PlaySizeUpAnimation() {
		GetComponent<Animation> ().Play ();
	}

	private void ResetParameters() {
		panelRect.localScale = new Vector3 (1, 1, 1);
		levelText.color = textColor;
	}

	private void InitializeReferences() {
		levelText = GetComponentInChildren<Text> ();
		panelRect = GetComponent<RectTransform> ();
		textColor = levelText.color;
	}
}
