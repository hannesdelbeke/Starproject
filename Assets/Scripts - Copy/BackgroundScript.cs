using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	public GameHandler InputManaging;
	
	
	void Start () {
		InputManaging = GameObject.Find("GameHandlers").GetComponent<GameHandler>();
	}
	
	void OnMouseDown() {
		
		InputManaging.deselectStar();

	}
}
