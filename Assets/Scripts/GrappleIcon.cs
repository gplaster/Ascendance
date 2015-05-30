using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GrappleIcon : MonoBehaviour {

	private float angle = 0f;
	public PlayerAttack playerAttack;
	public Text text;

	void Start() {
		text.text = "";
	}

	void Update () {
		angle += .05f;
		transform.position += new Vector3(0f, .05f*(Mathf.Sin (angle)), 0f);
	}

	IEnumerator OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			playerAttack.canGrapple = true;
			text.text = "You've acquired the grappling hook! Toggle it with the 'E' key!";
			//PauseWaitResume(3f);
			GetComponentInChildren <MeshRenderer>().enabled = false;
			GetComponentInChildren<Light>().enabled = false;
			yield return new WaitForSeconds(3);
			text.text = "";
			Destroy (gameObject);
		}
	}

	IEnumerator PauseWaitResume (float pauseDelay) {
		Time.timeScale = 0.0000001f;
		yield return new WaitForSeconds(pauseDelay * Time.timeScale);
		Time.timeScale = 1.0f;
	}
}
