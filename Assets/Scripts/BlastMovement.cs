using UnityEngine;
using System.Collections;

public class BlastMovement : MonoBehaviour {

	public float speed = 6f;

	Vector3 movement;
	
	void Start() {
		rigidbody.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

			if (enemyHealth != null) {
				enemyHealth.TakeDamage(25);
			}
		}
	}
}
