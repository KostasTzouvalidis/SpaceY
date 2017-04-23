using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Material : MonoBehaviour {
	
	void OnEnable() {
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		Color col = mat.color;
		col = new Color ((float)Random.Range(28, 41) / 255, 
			(float)Random.Range(14, 28) / 255,
			(float)Random.Range(10, 22) / 255, 1);
		mat.color = col;
	}
}
