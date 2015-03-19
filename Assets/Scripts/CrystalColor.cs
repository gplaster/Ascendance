using UnityEngine;
using System.Collections;

public class CrystalColor : MonoBehaviour {

	private CrystalScript script;
	private Material newMat;

	// Use this for initialization
	void Awake () {
		script = GetComponentInChildren<CrystalScript> ();
		newMat = new Material (Shader.Find ("Diffuse"));
		newMat.color = script.crystalParticles.startColor;
		renderer.material = newMat;
	}
	
	// Update is called once per frame
	void Update () {
		if (script.doneCleansing) {
			newMat.color = Color.white;
		}
		else {
			newMat.color = script.crystalParticles.startColor;
		}
	}
}
