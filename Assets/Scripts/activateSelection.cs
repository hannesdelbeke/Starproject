using UnityEngine;
using System.Collections;

public class activateSelection : MonoBehaviour {


	public float startScale;
	public float FinalScale;
	private float workScale;

	public float scaletime = 1 ;

	// Use this for initialization
	void Start () {
		resetEffect ();
	}

	// Update is called once per frame
	void Update() {		
		//tween

		//transform.localScale = new Vector3 (workScale,workScale,workScale);

		Vector3 tweenScale = new Vector3 (FinalScale,FinalScale,FinalScale);
		iTween.ScaleTo(gameObject, iTween.Hash( "scale",tweenScale, "time", scaletime, "easetype", iTween.EaseType.easeInBack));

	}
	void resetEffect (){
	// put scale on 0
		Vector3 startScaleVector= new Vector3 (startScale,startScale,startScale);
		transform.localScale = startScaleVector;
		//workScale = startScale;

	//put color on dark for fade

	}
}
