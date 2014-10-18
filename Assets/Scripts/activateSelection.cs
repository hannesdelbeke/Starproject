using UnityEngine;
using System.Collections;

public class activateSelection : MonoBehaviour {


	public float startScale;
	public float FinalScale;
	private float workScale;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update() {		
		//tween


		transform.localScale = new Vector3 (workScale,workScale,workScale);
		
	}
	void resetEffect (){
	// put scale on 0
		Vector3 startScaleVector= new Vector3 (startScale,startScale,startScale);
		transform.localScale = startScaleVector;
		workScale = startScale;

	//put color on dark for fade

	}
}
