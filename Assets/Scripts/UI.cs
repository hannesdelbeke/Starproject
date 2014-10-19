using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public GameHandler InputManaging;

	// For GUI Stuff
	public Texture2D probeGUITexture;
	public Texture2D menuButton;
	public int probesLeftOffset = 10;
	public int probesTopOffset = 10;
	public float probeSize = 0.05f;
	public float probeSpacing = 0.01f;

	float probeSizeFromPercentage;
	float probeSpacingFromPercentage;

	// Use this for initialization
	void Start () {
	
		InputManaging = GameObject.Find("GameHandlers").GetComponent<GameHandler>();

		probeSizeFromPercentage =  Screen.width * probeSize / 100;
		probeSpacingFromPercentage =  (float)Screen.width * probeSpacing / 100;
	}
	
	void OnGUI() {

		// Menu button
		if (GUI.Button (new Rect (probeSpacingFromPercentage, probeSpacingFromPercentage, probeSizeFromPercentage, probeSizeFromPercentage), menuButton, GUIStyle.none)) {
			Application.LoadLevel(0);
		}

		// Adding bar of probes
		for (int i = 0; i < InputManaging.probesAmount; i++) {
			
			GUI.Label (new Rect (probeSpacingFromPercentage + i*probeSizeFromPercentage, Screen.height - (probeSpacingFromPercentage/2 + probeSizeFromPercentage), probeSizeFromPercentage, probeSizeFromPercentage), probeGUITexture);

		}
		
	}




//	
//	// Update is called once per frame
//	void Update () {
//	
//	}


}
