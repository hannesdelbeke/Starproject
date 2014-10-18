using UnityEngine;
using System.Collections;

public class Probe : MonoBehaviour {

	public float speed;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToStar(GameObject destination) {

		Debug.Log ("Hello from GoToStar");
		iTween.MoveTo(this.gameObject, iTween.Hash( "position", destination.transform.position, "looktarget", destination.transform.position, "time", 1.5f, "oncomplete", "ProbeReachedNewStar", "easetype", iTween.EaseType.linear));

	}

	void ProbeReachedNewStar() {

		Debug.Log ("Reached the new star! :)");
	}

}
