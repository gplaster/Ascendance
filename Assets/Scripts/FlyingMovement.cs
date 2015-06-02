using UnityEngine;
using System.Collections;

public class FlyingMovement : MonoBehaviour {
	
	Transform player;               // Reference to the player's position.
	//PlayerHealth playerHealth;      // Reference to the player's health.
	EnemyHealth enemyHealth;        // Reference to this enemy's health.
	public float navDistance = 100f;
	public float destroyDistance = 100f;
	public float minDistance = 10f;
	private float angle = 0f;
	public bool playerInRange;
	private Quaternion saveLook;
	private bool attackingPlayer;

	public EndState endState;

	Transform savePosition;
	private float num;
	
	void Awake () {
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
		endState = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<EndState> ();
		saveLook = transform.rotation;
		playerInRange = false;
		savePosition = transform;
		num = Random.Range (-1.0f, 1.0f);
		attackingPlayer = false;
	}

	void Update () {

		if (num < 0) {
			angle -= 0.05f;
		}
		else {
			angle += 0.05f;
		}
	
		float distance = Vector3.Distance (player.transform.position, transform.position);
		if (distance > minDistance && !attackingPlayer) {
			transform.position += new Vector3(.05f*(Mathf.Sin (angle)), 0f, 0f);
		}
		//transform.position = new Vector3 (transform.position.x, savePosition.position.y, savePosition.position.z);
	}
	
	void FixedUpdate() {

		if (!endState.finalPlayerIsDead) {
			float distance = Vector3.Distance (player.transform.position, transform.position);
			
			if (distance <= minDistance) {
				playerInRange = true;
				attackingPlayer = true;
				Vector3 position = player.collider.bounds.min - transform.position - new Vector3(0f, 5f, 0f);
				Quaternion newRotation = Quaternion.LookRotation(position);

				//newRotation.z = Quaternion.identity.z;
				//newRotation.x = transform.rotation.x;
				transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 5f);
				//transform.eulerAngles = Vector3.Lerp(transform.position, position, Time.deltaTime * 5f);
				//transform.Rotate(transform.LookAt);
			}
			else {
				playerInRange = false;
				transform.rotation = Quaternion.Slerp(transform.rotation, saveLook, Time.deltaTime * 5f);
				//transform.Rotate(transform.LookAt);
			}
		}

		//transform.position = new Vector3 (transform.position.x, savePosition.position.y, savePosition.position.z);

		if (transform.position == savePosition.position) {
			attackingPlayer = false;
		}
	}
}
