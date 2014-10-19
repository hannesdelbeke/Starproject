using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class GameHandler : MonoBehaviour {
	
	public float score = 0;
	// get input touch
	//if collides star set active
	public GameObject SelectedStar; // each star keeps track of whats within range // if moving star then fire calculate range function on selection and keep doing it while selected
	//private GameObject EarthStar;
	public int connectedStars; //if 0 earth is the selectedstar
	public GameObject selectionSprite;
	public GameObject rangeSprite ;
	public int probesAmount = 6 ;
	public GameObject probePrefab;
	public AudioClip getStarSound;
	public AudioClip selectStarSound;
	public List<Star> selectedStars;
	public bool probeInSpace = false;
	public int nextLevel = 1;
	public bool lostGame = false;

	void Start() {
		
		selectionSprite = Instantiate(selectionSprite,transform.position, Quaternion.identity) as GameObject;
		rangeSprite = Instantiate(rangeSprite,transform.position, Quaternion.identity) as GameObject;

		rangeSprite.SetActive(false);
		selectionSprite.SetActive(false);
		//EarthStar = GameObject.Find("StarEarth");
	}

	public void clickStar(GameObject starInput)
	{ 
		Star starInputComp = starInput.GetComponent<Star>()as Star;
		//print ( " currently selected star");
		//print (selectedStar);

		//check if star is part of your network
		if(starInputComp.connected)
		{
			//if part of network select
			setSelectedStar( starInput);

		}
		//if not part of network see if in range
		else {	
			if(SelectedStar){
				print("test1");
				List<Star> inReachOfSelected = getStarsInReach(SelectedStar);
				print("test12");
				print("in reach of selected");
				print(inReachOfSelected);
				//if in range connect
				if (inReachOfSelected.Contains(starInputComp) ){
					if(!probeInSpace && probesAmount>0) {
						// Launch probe
						probeInSpace = true;
						Debug.Log ("Trying to launch probe");
						GameObject newProbe;
						newProbe = Instantiate(probePrefab, SelectedStar.transform.position, Quaternion.identity) as GameObject;
						newProbe.GetComponent<Probe>().GoToStar(starInput);
						// Make sure to activate the connected star
						probesAmount -= 1;
					}
				}
			}
		}




			/*
		_previous = _current;
		_current = this.gameObject.GetComponent<Star>();
		
		Debug.Log("Pressed left click.");
		this.renderer.material.color = Color.red; 
		
		if (_previous != null) 
		{
			if(!_previous.inMyConnections(_current))
			{
				_previous.connections.Add (_current);
				_current.connections.Add (_previous);
				Debug.Log ("New connection made.");
			}
		}
		*/
	}
		
	public void setSelectedStar(GameObject selStar)
	{
		trackGameOver();
		if (lostGame== false){
			float _scale = selStar.GetComponent<Star>().range;
			_scale /= 5;
			
			rangeSprite.SetActive(true);
			rangeSprite.GetComponent<activateSelection>().setRangeScale(_scale);
			rangeSprite.GetComponent<activateSelection>().resetEffect();
			selectionSprite.SetActive(true);
			selectionSprite.GetComponent<activateSelection>().resetEffect();

			SelectedStar = selStar;
			selectionSprite.transform.position = SelectedStar.transform.position;
			rangeSprite.transform.position = SelectedStar.transform.position;

			//rangeSprite.transform.localScale = new Vector3(_scale,_scale,_scale);
			audio.PlayOneShot(selectStarSound, 1); 

			for (var i = 0; i < selectedStars.Count ; i++) {
				selectedStars[i].selSprite.SetActive(false);
			}
			selectedStars.Clear();//clear selected stars

			List<Star> inReach = getStarsInReach(selStar) as List<Star>;	
			for (var i = 0; i < inReach.Count; i++) {
				if (inReach[i].selSprite!= null){

					if(inReach[i].connected == false){
						inReach[i].selSprite.SetActive(true);
						selectedStars.Add(inReach[i]); 
					}
				}
			}
		}
	}
	
	public void captureStar (GameObject targetStar) {
		//setSelectedStar( targetStar);
		//targetStar.renderer.material.color = Color.red;
		//targetStar.GetComponent<Star>().connected = true; 
		targetStar.GetComponent<Star>().connectStar(); 
		probesAmount+= targetStar.GetComponent<Star>().getBonusProbes();
		score += 1; 
		GetComponent<UI>().score = score;
		if(targetStar.GetComponent<Star>().nextLevel )
		{
			Application.LoadLevel(nextLevel);
		}
		//audio.PlayOneShot(getStarSound, 1);
	}

	public List<Star> getStarsInReach (GameObject centerStar)
	{
		List<Star> StarInReach = new List<Star>();

		Vector3 center = centerStar.transform.position;
		float radius = centerStar.GetComponent<Star>().range;		
		var hitColliders = Physics.OverlapSphere(center, radius);	

		for (var i = 0; i < hitColliders.Length; i++) {
			//hitColliders[i].SendMessage("AddDamage");

			//if (hitColliders[i].gameObject != SelectedStar)
			//hitColliders[i].gameObject.renderer.material.color = Color.blue; //shows who is in range


			GameObject c = hitColliders[i].gameObject;
			if((c.GetComponent<Star>() as Star) != null)//if object is a star 
			{			
				Star _star =c.GetComponent<Star>() as Star;
				StarInReach.Add(_star);			
			}	
		}
		return StarInReach;
	}
	
	public void deselectStar(){
		//click on background
		SelectedStar = null;
		for (var i = 0; i < selectedStars.Count ; i++) {
			selectedStars[i].selSprite.SetActive(false);
		}
		selectedStars.Clear();//clear selected stars


		//hide selection circle
		//hide radius
		rangeSprite.SetActive(false);
		selectionSprite.SetActive(false);

	}
	public void trackGameOver(){
		if (probeInSpace == false && probesAmount <= 0){
			//you lost/ are stuck
			lostGame = true;			
			rangeSprite.SetActive(false);
			selectionSprite.SetActive(false);

				
			for (var i = 0; i < selectedStars.Count; i++) {
				if (selectedStars[i].selSprite!= null){
					selectedStars[i].selSprite.SetActive(false);
				}
			}


		}


	}
	void Update () {
		trackGameOver();
	}
}
