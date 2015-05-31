using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject blast;
	public Transform blastSpawn;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
	public bool canGrapple = false;

	// Grappling Hook prefab stuff
	public Transform prefabGrapple;
	public int shootForceX = 0;
	public int shootForceY = 0;
	public int shootForceZ = 0;
	public bool grappling = false;
	public float direction = 1f;

	void Update () {
		if (Input.GetButton("Fire1")) {

			if (grappling && Time.time > nextFire && canGrapple) {
				nextFire = Time.time + fireRate;

				Vector3 mousePosition = Input.mousePosition;
				mousePosition.z = 19.42f;
				mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

				Vector3 shootDirection = mousePosition - transform.position;
				shootDirection.z = 0f;
				shootDirection.Normalize();
				Transform InstanceGrapple = Instantiate (prefabGrapple, blastSpawn.position, Quaternion.identity) as Transform;
				//InstanceGrapple.LookAt(shootDirection);
				//InstanceGrapple.rigidbody.AddForce ((transform.TransformDirection(Vector3.back).normalized).x * shootForceX, shootForceY, 0f);
				//InstanceGrapple.position = Vector3.Lerp(blastSpawn.position, touchPosition, 5f * Time.deltaTime);
				//InstanceGrapple.rigidbody.AddForce(InstanceGrapple.forward * shootForceX);
				InstanceGrapple.rigidbody.AddForce(shootDirection * shootForceX);
				//InstanceGrapple.rigidbody2D.velocity = shootDirection * 25f;
			}
			else if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;

				Vector3 mousePosition = Input.mousePosition;
				mousePosition.z = 19.42f;
				mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

				Vector3 shootDirection = mousePosition - transform.position;
				shootDirection.z = 0f;
				shootDirection.Normalize();
				blastSpawn.transform.forward = shootDirection;
				Instantiate (blast, blastSpawn.position, blastSpawn.rotation);
			}
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			grappling = !grappling;
		}

	}
}
