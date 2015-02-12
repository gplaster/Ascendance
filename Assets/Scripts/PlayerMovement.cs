using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;
	public float jumpSpeed = 10f;
	public float nextJump = 0.0f;
	public float jumpTime = 10f;
	public float jumpForce = 500f;
	private bool canJump = true;
	Vector3 movement;
	Rigidbody playerRigidbody;

	void Awake() {
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		float j = Input.GetAxisRaw ("Jump");

		Move (h, j, v);
	}

	void Move (float h, float j, float v) {
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);

		if (Input.GetButton("Jump") && canJump) {
			nextJump = Time.time + jumpTime;
			canJump = false;
			//playerRigidbody.MovePosition (transform.position + (transform.up * j));
			playerRigidbody.AddForce (transform.up * jumpForce);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ground") {
			canJump = true;
		}
	}
}
