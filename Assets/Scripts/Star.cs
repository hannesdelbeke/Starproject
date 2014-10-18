using UnityEngine;
using System.Collections.Generic;

public class Star : MonoBehaviour {

    public enum Type { cl0, cl1, cl2, cl3, cl4, cl5, cl6, cl7, cl8, cl9 }
    public Type type;
	
    public List<Star> connections;
	public bool connected;
	public float age;
	public float range  ;
	public GameObject selSprite;
	public GameObject capSprite;

    void Awake()	
    {
		
		foreach (Transform child in transform){
			if (child.name == "SelectionSprite"){
				// the code here is called
				// for each child named Bone
				selSprite = child.gameObject;
			}
		}
		foreach (Transform child in transform){
			if (child.name == "capturedSprite"){
				// the code here is called
				// for each child named Bone
				capSprite = child.gameObject;
			}
		}
    }
	public bool inMyConnections (Star _newStar)
	{	
		bool ans = false;

		foreach (Star _star in connections)
		{
			if(_newStar == _newStar)
			{
				ans = true;
			}
		}

		return ans;
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

	void Update() 
 //* THIS IS NOT WORKING
		//because they dont have any connections currently

		//you wile have double conenctions so add something that makes you not add linerender on start and the conencted star but only one of them
	{
				
		foreach (Star _star in connections) 
		{
			LineRenderer line = this.gameObject.AddComponent<LineRenderer>();
			line.SetWidth(10, 10);
			line.SetVertexCount(2);
			line.material = this.gameObject.renderer.material;
			line.renderer.enabled = true;
			line.SetPosition(0, _star.gameObject.transform.position);
			line.SetPosition(1, this.gameObject.transform.position);		
		}
	}


	public void connectStar(){
		connected = true;
		if(capSprite)
			capSprite.SetActive(true);
		if(selSprite)
			selSprite.SetActive(false);
	}

}
