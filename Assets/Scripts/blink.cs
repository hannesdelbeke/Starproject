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
		/*
		if(){
			
			
		}

*/
		if(workAlpha<0){
			workAlpha=0	;		
		}
		if(workAlpha>1){
			workAlpha=1;			
		}
		blinkColor.a = workAlpha;
		//Color temp = Color.white;
		renderer.material.SetColor ("_TintColor", blinkColor);
		//float blinkColorA = blinkColor.a;









		/*
		blinkTimer -= Time.deltaTime;
		if (blinkTimer<0) {
			blinkTimer = blinkRate;
			//blink
			//renderer.material
				// renderer.material.GetColor("_SpecColor");
				// renderer.material.SetColor ("_TintColor", Color);

			//iTween.ValueTo  (gameObject, iTween.Hash("from",blinkColorA,"to",1f, "speed",0.5f,"easetype", iTween.EaseType.easeOutBack));
			//blinkColor2 = iTween.FloatUpdate( blinkColorA,  blinkColor2,  1);
			workAlpha = startAlpha;
			blinking = true;
			goUp = true;
		}
			if(goUp){
				workAlpha += Time.deltaTime; 
				if (workAlpha>=1){
					workAlpha = 1;
					goUp= false;
				}
			}else{
				workAlpha -= Time.deltaTime;
				if(workAlpha < startAlpha ){
					workAlpha = startAlpha;
					}
				}
		*/

		/*
		blinkColor = renderer.material.GetColor("_TintColor");
		float blinkColorA = blinkColor.a;
		*/
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
