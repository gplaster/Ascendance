using UnityEngine;
using System.Collections;

public class PlatformCollide : MonoBehaviour {

	GameObject player;
	PlayerMovement playerMovement;
	Bounds playerBounds;
	
	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		playerMovement = player.GetComponent<PlayerMovement>();
	}

	void Update () {
		playerBounds = player.collider.bounds;
	}

	void OnTriggerExit (Collider other) {

		if (other.tag == "Player") {

			if(playerBounds.min.y >= collider.bounds.max.y)
			{
			    collider.isTrigger = false;
			}
			else
			{
				collider.isTrigger = true;
			}
		}
	}
}
