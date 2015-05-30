using UnityEngine;
using System.Collections;


public class FlyingAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack.
	public GameObject blast;
	public Transform blastSpawn;
	public EndState endState;
	
	//Animator anim;                              // Reference to the animator component.
	GameObject player;                          // Reference to the player GameObject.
	EnemyHealth enemyHealth;                    // Reference to this enemy's health.
	float timer;                                // Timer for counting up to the next attack.
	FlyingMovement flyingMovement;
	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyHealth = GetComponent<EnemyHealth>();
		flyingMovement = GetComponent<FlyingMovement> ();
		blastSpawn.position -= new Vector3 (0f, 1f, 0f);
		//anim = GetComponent <Animator> ();
		endState = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<EndState> ();
	}
	
	void Update ()
	{
		if (!endState.finalPlayerIsDead) {
			// Add the time since Update was last called to the timer.
			timer += Time.deltaTime;
			
			// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
			if(timer >= timeBetweenAttacks && flyingMovement.playerInRange && enemyHealth.currentHealth > 0)
			{
				// ... attack.
				Attack ();
			}
			
			// If the player has zero or less health...
			/*if(playerHealth.currentHealth <= 0)
			{
				// ... tell the animator the player is dead.
				anim.SetTrigger ("PlayerDead");
			}*/
		}
	}
	
	
	void Attack ()
	{
		// Reset the timer.
		timer = 0f;
		
		Vector3 shootDirection = player.transform.position - transform.position;
		//shootDirection.z = 0f;
		shootDirection.Normalize();
		
		blastSpawn.transform.forward = shootDirection;
		blastSpawn.LookAt (shootDirection);
		Instantiate (blast, blastSpawn.position, blastSpawn.rotation);
	}
}