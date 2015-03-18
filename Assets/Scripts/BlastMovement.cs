using UnityEngine;
using System.Collections;

public class BlastMovement : MonoBehaviour {

	public float speed = 6f;

	Vector3 movement;
	
	void Start() {
		rigidbody.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other) {
		RaycastHit hit;

		if (other.tag == "Enemy") {
			EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

			//This piece not working
			/*if (Physics.Raycast(transform.position, transform.forward, out hit)) {
				if (enemyHealth != null) {
					enemyHealth.TakeDamage(25, hit.point);
				}
			}*/

			//Revert to just damage
			enemyHealth.TakeDamage(25);
		}
		
		if (other.tag == "Player") {
			PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

			/*if (Physics.Raycast(transform.position, transform.forward, out hit)) {
				if (playerHealth != null) {
					playerHealth.TakeDamage(25, hit.point);
				}
			}*/

			playerHealth.TakeDamage(25);
		}

	}
}
