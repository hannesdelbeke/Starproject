using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture mainMenuStar;

	float starHeight;
	float starWidth;
	float starOffset;


	// Use this for initialization
	void Start () {
	
		starHeight = Screen.height * 0.8f;
		starWidth = starHeight * 0.57014590347924f; // 508x891
		starOffset = Screen.height * 0.1f;

		Debug.Log ("starHeight: " + starHeight);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.Label (new Rect ( 0, starOffset, starWidth, starHeight), mainMenuStar);

		
	}



}
