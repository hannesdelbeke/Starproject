using UnityEngine;
using System.Collections.Generic;

public class Star : MonoBehaviour {

    //public enum Type { cl0, cl1, cl2, cl3, cl4, cl5, cl6, cl7, cl8, cl9 }
    //public Type type;

	//public enum startype{NoLife, Life1, Enemy1,Enemy2 };
	//public startype myType;

	//public List<Star> connections;
	public bool connected;
//	public float age;
	public float range  ;
	public GameObject selSprite;
	public GameObject capSprite;	
	public int bonusprobes = 0 ;
	public bool nextLevel = false;

    void Awake()	
	{
		foreach (Transform child in transform){
			if (child.name == "SelectionSprite"){
				selSprite = child.gameObject;
			}
		}
		foreach (Transform child in transform){
			if (child.name == "capturedSprite"){
				capSprite = child.gameObject;
			}
		}
		if(connected == false){
			if(capSprite)
				capSprite.SetActive(false);
			if(selSprite)
				selSprite.SetActive(false);
		}
    }
	public void getStarsInReach ()
	{
		Vector3 center = this.transform.position;
		float radius = range;

		var hitColliders = Physics.OverlapSphere(center, radius);
		
		for (var i = 0; i < hitColliders.Length; i++) {
			//hitColliders[i].SendMessage("AddDamage");
		}	
	}
	public void connectStar(){
		connected = true;
		if(capSprite)
			capSprite.SetActive(true);
		if(selSprite)
			selSprite.SetActive(false);
	}
	public int getBonusProbes(){
		return bonusprobes;
	}
}
