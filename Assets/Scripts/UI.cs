using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public GameHandler InputManaging;

	// For GUI Stuff
	public Texture2D probeGUITexture;
	public int probesLeftOffset = 10;
	public int probesTopOffset = 10;
	public float probeSize = 5f;
	public float probeSpacing = 1f;

	float probeSizeFromPercentage;
	float probeSpacingFromPercentage;

	// Use this for initialization
	void Start () {
	
		InputManaging = GameObject.Find("GameHandlers").GetComponent<GameHandler>();

		probeSizeFromPercentage =  (float)Screen.width / probeSize;
		probeSpacingFromPercentage =  (float)Screen.width / probeSpacing;
		Debug.Log ("probeSizeFromPercentage: " + probeSizeFromPercentage + " probeSpacingFromPercentage: " + probeSpacingFromPercentage);

	}
	
	void OnGUI() {
		
		for (int i = 0; i < InputManaging.probesAmount; i++) {
			
			GUI.Label (new Rect ( 10 + i*50, 10, 50, 50), probeGUITexture);
			
			
		}
		
	}




//	
//	// Update is called once per frame
//	void Update () {
//	
//	}


}
