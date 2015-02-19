using UnityEngine;
using System.Collections;

public class PlatformCollide : MonoBehaviour {

	GameObject player;
	Bounds playerBounds;
	
	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		collider.isTrigger = true;
	}

	void Update () {
		playerBounds = player.collider.bounds;
	}

	void OnTriggerExit (Collider other) {

		if (other.tag == "Player") {

			/* If player feet are above top of platform, set collider as trigger */
			if(playerBounds.min.y >= collider.bounds.max.y)
			{
			    collider.isTrigger = false;
			}
			else /* If player feet is below top of platform, ignore collisions with platform */
			{
				collider.isTrigger = true;
			}
		}
	}
}
