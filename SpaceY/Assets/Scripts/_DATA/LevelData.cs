using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Assets/Levels/Level")]
public class LevelData : ScriptableObject {

	/*
	 * Game Manager Parameters
	 */

	// Regular hazard emission parameters
	public float minRegularEmissionRate;
	public float maxRegularEmissionRate;
	public float specialHazardRate;

	// Giant hazard emission parameters
	public float giantHazardDuration;
	public float minGiantEmissionRate;
	public float maxGiantEmissionRate;

	/*
	 * Level Parameters
	 */
}
