using UnityEngine;
using System.Collections;

public class blink : MonoBehaviour {
	public float blinkRate ;
	public float blinkTimer ;
	public float startAlpha;
	public float workAlpha;
	public Color blinkColor;
	public bool goUp;
	public bool blinking;
	// Use this for initialization
	void Start () {
		blinkRate = GetPeriodInDays();
		blinkRate+=0.5f;
		goUp = true;
		
		// renderer.material.SetColor ("_TintColor", Color);
		blinkColor = renderer.material.GetColor("_TintColor");
		startAlpha = blinkColor.a;
	}
	
	// Update is called once per frame
	void Update () {		
		blinkTimer -= Time.deltaTime;
		if (blinkTimer<0) {
			blinkTimer = blinkRate;
			workAlpha= startAlpha;
		}

		if (blinkTimer < blinkRate/2f){
			goUp=true;}
		else{
			goUp=false;}
		
		if(goUp){
			workAlpha += Time.deltaTime/blinkRate;			
		}
		else{			
			workAlpha -= Time.deltaTime/blinkRate;
		}
		if(workAlpha<0){
			workAlpha=0	;		
		}
		if(workAlpha>1){
			workAlpha=1;			
		}
		blinkColor.a = workAlpha;
		renderer.material.SetColor ("_TintColor", blinkColor);
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
