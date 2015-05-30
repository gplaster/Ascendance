using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {

		if (other.tag == "Player") {
			Application.LoadLevel(Application.loadedLevel);
		}
		Destroy (other.gameObject);
	}
}
