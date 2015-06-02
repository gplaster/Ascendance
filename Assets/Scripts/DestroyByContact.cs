using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		//Instantiate(explosion, transform.position, transform.rotation);
		if (tag == "ShadowBall" && other.tag == "Player")
		{
			//Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
		}

		if (tag == "EnergyBlast" && other.tag != "Player") {
			Destroy(gameObject);
		}
		//Destroy(other.gameObject);
		//Destroy(gameObject);
	}
}
