using UnityEngine;
using System.Collections;

public class OnTriggerStop : MonoBehaviour
{
	public float grappleSpeed = 0f;
	public float maxDistance = 100f;

	private GameObject player;
	private bool grapplingPlatform = false;
	private bool grapplingGround = false;
	private Vector3 height;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void  OnTriggerEnter (Collider other)
	{
		if (other.tag == "Platform") {
			//if (other.bounds.min.y <= collider.bounds.min.y) {
				grapplingPlatform = true;
			//}
		}
		else if (other.tag == "Ground"){
			grapplingGround = true;
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

		if (grapplingPlatform) {
			StartCoroutine(MoveGrapple());
		}

		if (grapplingGround) {
			StartCoroutine(MoveGrapple());
		}
	}

	IEnumerator MoveGrapple() {
		float t = 0f;

		if (grapplingPlatform) {
			rigidbody.isKinematic = true;
			while (t < 1.0f) {
				t += Time.deltaTime / 2f;
				player.transform.position = Vector3.Lerp (player.transform.position, this.transform.position + new Vector3(0f, 5f, 0f), t);
				yield return null;
			}
			Destroy (gameObject);
		}

		if (grapplingGround) {
			rigidbody.isKinematic = true;

			while (t < 1.0f) {
				t += Time.deltaTime / 2f;
				player.transform.position = Vector3.Lerp (player.transform.position, this.transform.position + new Vector3(0f, 2f, 0f), t);
				yield return null;
			}
			Destroy (gameObject);
		}
	}
}
