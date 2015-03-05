using UnityEngine;
using System.Collections;

public class EnemyMobMovement : MonoBehaviour {

	Transform player;               // Reference to the player's position.
	//PlayerHealth playerHealth;      // Reference to the player's health.
	EnemyHealth enemyHealth;        // Reference to this enemy's health.
	NavMeshAgent nav;               // Reference to the nav mesh agent.
	public float navDistance = 100f;
	public float jumpForce = 400f;
	
	
	void Awake () {
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();
	}
	
	
	void Update () {	
		// If the enemy and the player have health left...
		if(enemyHealth.currentHealth > 0 /*&& playerHealth.currentHealth > 0*/)
		{
			// ... set the destination of the nav mesh agent to the player.
			nav.SetDestination (player.position);
		}
		// Otherwise...
		else
		{
			// ... disable the nav mesh agent.
			nav.enabled = false;
		}
	}

	void FixedUpdate() {

		float distance = Vector3.Distance (player.transform.position, transform.position);

		/* If the enemy is close enough to the player */
		if (distance <= navDistance) {
			/* If the bottom of the player is above the center of the enemy */
			if (player.collider.bounds.min.y > collider.bounds.min.y) {

				rigidbody.AddForce(transform.up * jumpForce);
			}
		}
	}
}
