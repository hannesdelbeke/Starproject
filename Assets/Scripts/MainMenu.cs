using UnityEngine;
using System.Collections;
using System;

public class MainMenu : MonoBehaviour {

	public Texture mainMenuStar;  // 1584x1113
	public Texture button1;  // 426x90
	public Texture button2;  // Width % ~30%
	public Texture button3;
	public Texture button4;
	public Texture buttonExit;

	int starHeight;
	int starWidth;
	int starOffset;

	int buttonWidth;
	int buttonHeight;
	int buttonsLeftSide;

	float leftMultiplier;

	// Use this for initialization
	void Start () {
	
		starHeight = Convert.ToInt32( Screen.height * 0.8f );
		starWidth = Convert.ToInt32( starHeight * 0.57014590347924f ); // 508x891
		starOffset = Convert.ToInt32( Screen.height * 0.1f );
		buttonWidth = Convert.ToInt32( Screen.width * 0.3f );
		buttonHeight = Convert.ToInt32( buttonWidth * 0.2112676056338f );
		buttonsLeftSide = Convert.ToInt32( Screen.width * 0.36f );
		leftMultiplier = 3f; // Use 3f for webplayer and 5f for 16:9
//		float screenRatio = Screen.width / Screen.height;
//		if (screenRatio >= 1.3) {
//			topOffset = starOffset * 3;
//		}
//		if (screenRatio >= 1.5) {
//			topOffset = starOffset * 5;
//		}
//		if (screenRatio >= 1.7) {
//			topOffset = starOffset * 8;
//		}
		
		Debug.Log ("starHeight: " + starHeight);
		Debug.Log ("buttonWidth: " + buttonWidth + " buttonHeight: " + buttonHeight);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.Label (new Rect ( 0, starOffset, starWidth, starHeight), mainMenuStar);

		if (GUI.Button (new Rect (buttonsLeftSide, (buttonsLeftSide/leftMultiplier), buttonWidth, buttonHeight), button1, GUIStyle.none)) {
			Application.LoadLevel(1);
		}

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/leftMultiplier + buttonHeight + Screen.height * 0.01f, buttonWidth, buttonHeight), button2, GUIStyle.none)) {
			Application.LoadLevel(2);
		}

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/leftMultiplier + buttonHeight*2 + Screen.height * 0.02f, buttonWidth, buttonHeight), button3, GUIStyle.none)) {
			Application.LoadLevel(3);
		}

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/leftMultiplier + buttonHeight*3 + Screen.height * 0.03f, buttonWidth, buttonHeight), button4, GUIStyle.none)) {
			Application.LoadLevel(4);
		}

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/leftMultiplier + buttonHeight*4 + Screen.height * 0.04f, buttonWidth, buttonHeight), buttonExit, GUIStyle.none)) {
			Application.Quit();
		}




	}
	
	
	
}
