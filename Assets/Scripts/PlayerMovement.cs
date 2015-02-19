using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;
	public float jumpSpeed = 10f;
	public float nextJump = 0.0f;
	public float jumpTime = 10f;
	public float jumpForce = 400f;
	public bool canJump = true;
	Vector3 movement;
	Vector3 rotation;
	Rigidbody playerRigidbody;

	public Animator anim;
	public bool walking;

	void Awake() {
		playerRigidbody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		float j = Input.GetAxisRaw ("Jump");

		if (h != 0) {
			walking = true;
		}
		else {
			walking = false;
		}

		Move (h, j, v);
	}

	void Move (float h, float j, float v) {

		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		if (h != 0) {
			transform.forward = new Vector3(-h, 0f, 0f);
		}

		playerRigidbody.MovePosition (transform.position + movement);

		if (Input.GetButton("Jump") && canJump) {
			nextJump = Time.time + jumpTime;
			canJump = false;
			//playerRigidbody.MovePosition (transform.position + (transform.up * j));
			playerRigidbody.AddForce (transform.up * jumpForce);
		}

		anim.SetBool("isWalking", walking);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ground") {
			canJump = true;
		}
		else if (other.tag == "Platform" && !other.collider.isTrigger) {
			canJump = true;
		}
	}
}
