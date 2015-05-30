using UnityEngine;
using System.Collections;

public class LevelEnemyManager : MonoBehaviour {

	public PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject player;				// Instance of player
	public GameObject enemy;                // The enemy prefabs to be spawned.
	public GameObject flyingEnemy;
	public float spawnTime = 3f;            // How long between each spawn.
	public float resetSpawnTime = 3f;
	public float quickSpawnTime = 3f;
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public Transform[] flySpawnPoints;
	public float inRange = 15f;				// Range between the player and spawn points
	public float y_Range = 5f;
	//public int enemiesToSpawn = 0;
	//public int enemyCount = 0;
	

	void Awake() {
		int i = 0;
		for (; i < flySpawnPoints.Length; i++) {

			Instantiate (flyingEnemy, flySpawnPoints[i].position, flyingEnemy.transform.rotation);
		}
	}

	IEnumerator Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		yield return StartCoroutine(SpawnStuff ());
		//InvokeRepeating ("Spawn", 0.1f, spawnTime);
	}

	IEnumerator SpawnStuff() {
		Spawn ();
		yield return new WaitForSeconds (spawnTime);
		yield return StartCoroutine(SpawnStuff ());
	}
	
	void Spawn ()
	{
		int i = 0;
		float distance;
		float y_distance;

		// If the player has no health left...
		if(playerHealth.currentHealth <= 0f)
		{
			// ... exit the function.
			return;
		}

		for (i = 0; i < spawnPoints.Length; i++) {

			distance = Vector3.Distance (spawnPoints [i].transform.position, player.transform.position);
			y_distance = Mathf.Abs(spawnPoints[i].transform.position.y - player.transform.position.y);

			if (distance <= inRange && y_distance <= y_Range) {

				// Create an instance of the enemy prefab at the selected spawn point's position and rotation.
				Instantiate (enemy, spawnPoints[i].position, spawnPoints[i].rotation);
			}
		}
	}
}