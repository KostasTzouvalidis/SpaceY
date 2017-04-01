using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRandom {

	private List<float> fixedFValues;
	private List<double> fixedDValues;
	private float fClamp;
	private double dClamp;
	private float minFValue;
	private double minDValue;
	private float maxFValue;
	private double maxDValue;

	public FixedRandom(float min, float max, float clamp) {
		fixedFValues = new List<float> ();
		fClamp = clamp;
		minFValue = min;
		maxFValue = max;
		for (float i = min; i <= max; i += clamp) {
			fixedFValues.Add (i);
		}
	}

	public FixedRandom(double min, double max, double clamp) {
		fixedDValues = new List<double> ();
		dClamp = clamp;
		minDValue = min;
		maxDValue = max;
		for (double i = min; i < max; i += clamp)
			fixedDValues.Add (i);
	}

	/*
	 * METHODS
	 */

	public float GetFloatRange() {
		if (fixedFValues == null)
			return -1;
		if (fClamp < minFValue || fClamp > maxFValue)
			return 0;

		return fixedFValues[Random.Range (0, fixedFValues.Count)];
	}

	public double GetDoubleRange() {
		if (fixedDValues == null)
			return -1;
		if (dClamp < minDValue || dClamp > maxDValue)
			return 0;

		return fixedDValues[Random.Range (0, fixedDValues.Count)];
	}

	public static float Range(float min, float max, float clamp) {
		if (clamp < min || clamp > max)
			return 0;

		float overallRange = Mathf.Abs (min) + Mathf.Abs (max);
		List<float> acceptedValues = new List<float> ();
		for (float i = min; i < overallRange; i += clamp)
			acceptedValues.Add (i);
		
		return acceptedValues[Random.Range (0, acceptedValues.Count)];
	}

	public static double Range(double min, double max, double clamp) {
		if (clamp < min || clamp > max)
			return 0;

		double overallRange = Abs (min) + Abs (max);
		List<double> acceptedValues = new List<double> ();
		for (double i = min; i < overallRange; i += clamp)
			acceptedValues.Add (i);

		return acceptedValues[Random.Range (0, acceptedValues.Count)];
	}

	public static double Abs(double value) {
		if (value < 0)
			value = -1 * value;
		return value;
	}
}
