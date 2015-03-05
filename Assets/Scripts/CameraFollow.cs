using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;
	
	Vector3 offset;
	
	void Start ()
	{
		/* Calculate the initial offset */
		offset = transform.position - target.position;
	}
	
	void FixedUpdate ()
	{
		/* Create a postion for the camera to aim based on the offset from the target */
		Vector3 targetCamPos = target.position + offset;
		
		/* Smooth interpolation between the camera position and target position */
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
