using UnityEngine;
using System.Collections;

public class CameraControls: MonoBehaviour {

	public float smoothing = 5f;
	GameHandler InputManaging;
	Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
		InputManaging = GameObject.Find("GameHandlers").GetComponent<GameHandler>();
		cameraOffset = this.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
	
		//ip right click or 2 touch pan camera
		// add maximum and minimum
		//optionally add zoom
		//Debug.Log ("selected star: " + InputManaging.SelectedStar.transform.position);
		//this.transform.position = InputManaging.SelectedStar.transform.position + cameraOffset;
		transform.position = Vector3.Lerp (transform.position, InputManaging.SelectedStar.transform.position + cameraOffset, smoothing * Time.deltaTime);
	}
}
