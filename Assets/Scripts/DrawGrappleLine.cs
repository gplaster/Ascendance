using UnityEngine;
using System.Collections;

public class DrawGrappleLine : MonoBehaviour
{
	// Line start width
	public float startWidth = 0.1f;
	// Line end width
	public float endWidth = 0.1f;
	// get line going...
	private LineRenderer line;
	
	void Start ()
	{
		line = this.gameObject.AddComponent <LineRenderer>();
		line.SetWidth (startWidth, endWidth);
		line.SetVertexCount (2);
		line.material.color = Color.yellow;
		//we need to see the line... 
		line.renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//get the shooter object...
		var player = GameObject.FindGameObjectWithTag ("Player");
		//set starting point of line to this object, in this case the grappling hook prefab
		line.SetPosition (0, player.transform.position + new Vector3(0f, 1f, 0f));
		//set the ending point of the line to the shooter object
		line.SetPosition (1, this.gameObject.transform.position);
	}
}
