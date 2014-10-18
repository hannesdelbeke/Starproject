using UnityEngine;
using System.Collections;

public class StarPeriod : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Get the orbital period of a planet, drawn from a random distribution
	//that approximates real Kepler data

	public float GetPeriodInDays () {
		while (true) {
			float r1 = (float)(Random.value);
			float r2 = (float)(Random.value*35.0f);
			float periodDistribution = (float)(0.5f * UnityEngine.Mathf.Exp (-r2 * 0.6f) - r2 * 0.0005d + 0.02f);
			if (r1 < periodDistribution) {
				return r2;
			}
		}
	}
}
