using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject blast;
	public Transform blastSpawn;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;

	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (blast, blastSpawn.position, blastSpawn.rotation);
		}
	}
}
