using UnityEngine;
using UnityEngine.UI;
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

	private Image grappleImage;
	private Image fireballImage;

	void Awake() {
		grappleImage = GameObject.FindGameObjectWithTag ("GrappleIcon").GetComponent<Image> ();
		fireballImage = GameObject.FindGameObjectWithTag ("FireballIcon").GetComponent<Image> ();
		grappleImage.enabled = false;
	}

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
				//InstanceGrapple.transform.forward = shootDirection;
				//InstanceGrapple.forward = InstanceGrapple.up;
				//InstanceGrapple.LookAt(mousePosition);
				//InstanceGrapple.Rotate(Quaternion.LookRotation(mousePosition));
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
				/*Vector3 difference = new Vector3(Mathf.Abs(transform.position.x - blastSpawn.position.x), blastSpawn.position.y, 0f);

				if (direction == -1 && mousePosition.x < transform.position.x) {
					blastSpawn.position = transform.position - difference;

				}
				else if (direction == 1 && mousePosition.x > transform.position.x) {
					blastSpawn.position = transform.position + difference;
				}
				else if (direction == -1 && mousePosition.x > transform.position.x) {
					blastSpawn = saveBlastSpawn;
				}
				else {
					blastSpawn.position = transform.position - difference;
				}*/

				Instantiate (blast, blastSpawn.position, blastSpawn.rotation);
			}
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			grappling = !grappling;

			if (canGrapple) {

				if(grappling) {
					fireballImage.enabled = false;
					grappleImage.enabled = true;
				}
				else {
					fireballImage.enabled = true;
					grappleImage.enabled = false;
				}
			}
		}

	}
}
