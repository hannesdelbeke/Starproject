using UnityEngine;
using System.Collections;

public class Probe : MonoBehaviour {

	public float speed;
	public GameHandler InputManaging;
	public GameObject destinationStar;

	LineRenderer lineRenderer;
	Vector3 startPosition;  // Used to copy the LineRenderer at the end

	// Use this for initialization
	void Start () {
		
		InputManaging = GameObject.Find("GameHandlers").GetComponent<GameHandler>();

		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(Color.cyan, Color.magenta);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.SetVertexCount (2);
		lineRenderer.SetPosition (0, this.transform.position);
		lineRenderer.SetPosition (1, this.transform.position);

		startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		lineRenderer.SetPosition (1, this.transform.position);	
	}

	public void GoToStar(GameObject destination) {

		iTween.MoveTo(this.gameObject, iTween.Hash( "position", destination.transform.position, "looktarget", destination.transform.position, "speed", speed, "oncomplete", "ProbeReachedNewStar", "easetype", iTween.EaseType.linear));
		destinationStar = destination;
	}

	void ProbeReachedNewStar() {

		// Claim the new star
		InputManaging.captureStar(destinationStar);
		// Make it possible to launch another probe
		InputManaging.probeInSpace = false;
		// Set the cursor on the new star and the camera will follow
		InputManaging.setSelectedStar (destinationStar);

		//Copy the Linerenderer
		LineRenderer clonedLinerender;
		GameObject lineRenders;
		lineRenders = GameObject.Find ("LineRenders");

		GameObject newLineRender = new GameObject("LineRender");
		newLineRender.gameObject.transform.parent = lineRenders.transform;

		clonedLinerender = newLineRender.AddComponent<LineRenderer> ();
		clonedLinerender.material = new Material(Shader.Find("Particles/Additive"));
		clonedLinerender.SetColors(Color.cyan, Color.magenta);
		clonedLinerender.SetWidth(0.2F, 0.2F);
		clonedLinerender.SetVertexCount (2);
		clonedLinerender.SetPosition (0, startPosition);
		clonedLinerender.SetPosition (1, this.transform.position);

		Destroy (this.gameObject);
	}

}
