using UnityEngine;
using System.Collections;

public class StopPlayer : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			if (other.gameObject.GetComponent<PlayerAttack>().grappling) {
				other.gameObject.rigidbody.velocity = new Vector3(0f, 0f, 0f);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !collider.isTrigger) {
			if (other.GetComponent<PlayerAttack>().grappling) {
				other.rigidbody.velocity = new Vector3(0f, 0f, 0f);
			}
		}
	}
}
