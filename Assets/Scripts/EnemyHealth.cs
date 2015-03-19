using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public int startingHealth = 100;
	public int currentHealth;
	
	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	bool isDead;
	
	
	void Awake ()
	{
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		
		currentHealth = startingHealth;
		isDead = false;
	}
	
	public void TakeDamage (int amount)
	{
		if (isDead) {
			return;
		}

		print (currentHealth);
		currentHealth -= amount;
		//print (currentHealth);
		
		//hitParticles.transform.position;
		
		hitParticles.Play ();
		
		if(currentHealth <= 0)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{
		// The enemy is dead.
		isDead = true;
		
		// Turn the collider into a trigger so shots can pass through it.
		capsuleCollider.isTrigger = true;
		
		Destroy (gameObject);
	}
}
