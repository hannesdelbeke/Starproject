using UnityEngine;
using System.Collections;

public class Probe : MonoBehaviour {

	public float speed;
	GameHandler gameHandler;

	// Use this for initialization
	void Start () {
		gameHandler = GameObject.Find("GameHandlers").GetComponent<GameHandler>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToStar(GameObject destination) {

		iTween.MoveTo(this.gameObject, iTween.Hash( "position", destination.transform.position, "looktarget", destination.transform.position, "speed", speed, "oncomplete", "ProbeReachedNewStar", "easetype", iTween.EaseType.linear));

	}

	void ProbeReachedNewStar() {

		Debug.Log ("Reached the new star! :)");

		// Claim the new star
		gameHandler.probeInSpace = false;

		Destroy (this.gameObject);
	}

}
