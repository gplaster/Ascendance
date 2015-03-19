using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrystalScript : MonoBehaviour {

	public ParticleSystem crystalParticles;
	public Image cleansedImage;
	//public ParticleSystem pulseParticles;
	//public SliderJoint2D cleanseSlider;
	public GameObject player;
	public float cleanse = 0f;
	public int dist = 10;
	private float smooth = 0.4f;
	private Color startingColor;
	private float startingSpeed;
	public float flashSpeed = 0.1f;
	private bool cleansed = false;
	public bool doneCleansing = false;

	// Use this for initialization
	void Awake () {
		//crystalParticles = GetComponentInChildren <ParticleSystem> ();
		//crystalParticles.startColor = new Color (121, 43, 202);
		//crystalParticles.playOnAwake = true;
		startingColor = crystalParticles.startColor;
		startingSpeed = crystalParticles.startSpeed;
		crystalParticles.Play ();
		renderer.material.color = crystalParticles.startColor;
	}

	void Update() {
		if (Vector3.Distance(player.transform.position, crystalParticles.transform.position) <= dist && !doneCleansing) {

			crystalParticles.startColor = Color.Lerp(crystalParticles.startColor, Color.white, smooth * Time.deltaTime);
			renderer.material.color = crystalParticles.startColor;
			if (crystalParticles.startSpeed != 10) {
				crystalParticles.startSpeed += 1;
			}
			cleanse += 5f * Time.deltaTime;

			if (cleanse >= 100 && cleanse <= 105) {
				cleansed = true;
			}
		}
		else if (!doneCleansing) {

			crystalParticles.startColor = Color.Lerp(crystalParticles.startColor, startingColor, smooth * Time.deltaTime);
			renderer.material.color = crystalParticles.startColor;
			if (crystalParticles.startSpeed != 3) {
				crystalParticles.startSpeed -= 1;
			}
		}

		if (cleansed) {
			doneCleansing = true;
			cleansedImage.color = Color.white;
			crystalParticles.Stop();
		}
		else {
			cleansedImage.color = Color.Lerp (cleansedImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		cleansed = false;

		//cleanseSlider.value = cleanse;
	}

}
