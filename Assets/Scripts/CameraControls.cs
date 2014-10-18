using UnityEngine;
using System.Collections;

public class CameraControls: MonoBehaviour {

	GameHandler InputManaging;
	Vector3 cameraOffset;

	public float smoothing = 0.8f; // Set it under 1.0 to have a slow movement

	// Use this for initialization
	void Start () {
		InputManaging = GameObject.Find("GameHandlers").GetComponent<GameHandler>();

		// Save the Camera offset at the start
		cameraOffset = this.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
	
		//ip right click or 2 touch pan camera
		// add maximum and minimum
		//optionally add zoom

		// Repositions the camera torwards the selected star
		if(InputManaging.SelectedStar)
			transform.position = Vector3.Lerp (transform.position, InputManaging.SelectedStar.transform.position + cameraOffset, smoothing * Time.deltaTime);
	}
}
