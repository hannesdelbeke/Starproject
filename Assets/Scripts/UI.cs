﻿using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public GameHandler InputManaging;

	// For GUI Stuff
	public Texture2D probeGUITexture;
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
		
		for (int i = 0; i < InputManaging.probesAmount; i++) {
			
			GUI.Label (new Rect ( probeSpacingFromPercentage + i*probeSizeFromPercentage, probeSpacingFromPercentage/2, probeSizeFromPercentage, probeSizeFromPercentage), probeGUITexture);

		}
		
	}




//	
//	// Update is called once per frame
//	void Update () {
//	
//	}


}
