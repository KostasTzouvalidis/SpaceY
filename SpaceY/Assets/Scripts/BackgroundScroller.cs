using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSize;
	private Vector3 startPosition;

	void Start() {
		InitializeReferences ();
	}

	void Update() {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSize);
		transform.position = startPosition + Vector3.back * newPosition;
	}

	private void InitializeReferences() {
		startPosition = this.transform.position;
	}
}
