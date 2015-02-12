using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Animator anim;
	public bool walking;

	void Awake() {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		if (Input.GetKeyDown(KeyCode.B)) {
			walking = !walking;
		}

		anim.SetBool("isWalking", walking);
	}
}
