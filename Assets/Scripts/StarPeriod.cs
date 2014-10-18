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
	double GetPeriodInDays () {
		while (true) {
			float r1 = Random.value;
			float r2 = Random.value*35.0;
			float periodDistribution = 0.5 * UnityEngine.Mathf.Exp (-r2 * 0.6) - r2 * 0.0005 + 0.02;
			if (r1 < periodDistribution) {
				return r2;
			}
		}
	}
}
