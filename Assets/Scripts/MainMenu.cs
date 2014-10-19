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

	// Use this for initialization
	void Start () {
	
		starHeight = Convert.ToInt32( Screen.height * 0.8f );
		starWidth = Convert.ToInt32( starHeight * 0.57014590347924f ); // 508x891
		starOffset = Convert.ToInt32( Screen.height * 0.1f );
		buttonWidth = Convert.ToInt32( Screen.width * 0.3f );
		buttonHeight = Convert.ToInt32( buttonWidth * 0.2112676056338f );
		buttonsLeftSide = Convert.ToInt32( Screen.width * 0.4f );

		Debug.Log ("starHeight: " + starHeight);
		Debug.Log ("buttonWidth: " + buttonWidth + " buttonHeight: " + buttonHeight);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.Label (new Rect ( 0, starOffset, starWidth, starHeight), mainMenuStar);

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/2, buttonWidth, buttonHeight), button1, GUIStyle.none)) {
			Application.LoadLevel(1);
		}

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/2 + buttonHeight + Screen.height * 0.01f, buttonWidth, buttonHeight), button2, GUIStyle.none)) {
			Application.LoadLevel(2);
		}

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/2 + buttonHeight*2 + Screen.height * 0.02f, buttonWidth, buttonHeight), button3, GUIStyle.none)) {
			Application.LoadLevel(3);
		}

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/2 + buttonHeight*3 + Screen.height * 0.03f, buttonWidth, buttonHeight), button4, GUIStyle.none)) {
			Debug.Log ("Clicked the button with an image");
		}

		if (GUI.Button (new Rect (buttonsLeftSide, buttonsLeftSide/2 + buttonHeight*4 + Screen.height * 0.04f, buttonWidth, buttonHeight), buttonExit, GUIStyle.none)) {
			Application.Quit();
		}




	}
	
	
	
}
