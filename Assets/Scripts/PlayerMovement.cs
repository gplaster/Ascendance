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
	PlayerAttack playerAttack;
	private float maxVelocity = 10f;

	public Animator anim;
	public bool walking;

	void Awake() {
		playerRigidbody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		Physics.gravity = new Vector3(0, -30.0F, 0);
		playerAttack = GetComponent<PlayerAttack> ();
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

		if(rigidbody.velocity.sqrMagnitude > maxVelocity)
		{
			//smoothness of the slowdown is controlled by the 0.99f, 
			//0.5f is less smooth, 0.9999f is more smooth
			rigidbody.velocity *= 0.99f;
		}
		
		Move (h, j, v);
	}
	
	void Move (float h, float j, float v) {
		
		movement.Set (h, 0f, 0f);
		movement = movement.normalized * speed * Time.deltaTime;

		if (h != 0) {
			transform.forward = new Vector3(-h, 0f, 0f);
			playerAttack.direction = -h;
		}

		playerRigidbody.MovePosition (transform.position + movement);

		if (Input.GetButton("Jump") && canJump) {
			nextJump = Time.time + jumpTime;
			canJump = false;
			//playerRigidbody.MovePosition (transform.position + (transform.up * j));
			playerRigidbody.AddRelativeForce (transform.up * jumpForce);
			//playerRigidbody.velocity *= 5;
		}

		anim.SetBool("isWalking", walking);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ground" && (collider.bounds.min.y + 0.3f >= other.collider.bounds.max.y)) {
			canJump = true;
		}
		else if (other.tag == "Platform" && !other.collider.isTrigger) {
			canJump = true;
		}

		//playerRigidbody.velocity /= 2;
	}
}
