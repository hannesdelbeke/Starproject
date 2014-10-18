using UnityEngine;
using System.Collections;

public class activateSelection : MonoBehaviour {


	public float startScale;
	private float finalScale = -1;

	public float scaletime = 1 ;

	// Use this for initialization
	void Start () {

		resetEffect ();
	}

	// Update is called once per frame
	void Update() {		
		//tween


	}
	public void resetEffect (){
	// put scale on 0
		if (finalScale<=0){
			finalScale = transform.localScale.x;
			print (finalScale);
		}

		Vector3 startScaleVector= new Vector3 (startScale,startScale,startScale);
		transform.localScale = startScaleVector;
		
		Vector3 tweenScale = new Vector3 (finalScale,finalScale,finalScale);
		iTween.ScaleTo(gameObject, iTween.Hash( "scale",tweenScale, "time", scaletime, "easetype", iTween.EaseType.easeOutBack));
	//put color on dark for fade

	}
}
