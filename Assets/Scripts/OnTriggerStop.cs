using UnityEngine;
using System.Collections;

public class OnTriggerStop : MonoBehaviour
{
	public float grappleSpeed = 0f;
	public float maxDistance = 100f;

	void  OnTriggerEnter (Collider other)
	{
		if (other.tag == "Platform") {
			if (other.bounds.min.y <= collider.bounds.min.y) {
				rigidbody.isKinematic = true;
				GameObject player = GameObject.FindGameObjectWithTag ("Player");
				player.transform.position = Vector3.Lerp (player.transform.position, this.transform.position, grappleSpeed * Time.deltaTime);
				Destroy (gameObject);
			}
		}
		else if (other.tag == "Ground"){
			rigidbody.isKinematic = true;
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.transform.position = Vector3.Lerp (player.transform.position, this.transform.position - new Vector3(0f, 2f, 0f), grappleSpeed * Time.deltaTime);
			Destroy (gameObject);
		}

	}

	void Update () {

		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (transform.position.y < player.transform.position.y) {
			Destroy(gameObject);
		}

		if (Vector3.Distance(player.transform.position, gameObject.transform.position) > maxDistance) {
			Destroy(gameObject);
		}
	}
}
