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
	//private float startingSpeed;
	public float flashSpeed = 0.1f;
	private bool cleansed = false;
	public bool doneCleansing = false;

	private EndState endState;

	public GameObject bg;
	public GameObject fg;
	public Light lightPulse;
	private Light mainLight;
	private float angle = 0f;
	private Color startingMain;

	// Use this for initialization
	void Awake () {
		//crystalParticles = GetComponentInChildren <ParticleSystem> ();
		//crystalParticles.startColor = new Color (121, 43, 202);
		//crystalParticles.playOnAwake = true;
		startingColor = crystalParticles.startColor;
		//startingSpeed = crystalParticles.startSpeed;
		crystalParticles.Play ();
		renderer.material.color = crystalParticles.startColor;
		bg.renderer.enabled = false;
		//fg.transform.localScale = new Vector3(0f, fg.transform.localScale.y, fg.transform.localScale.z);
		fg.renderer.enabled = false;
		endState = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<EndState> ();
		mainLight = GameObject.FindGameObjectWithTag ("MainLight").GetComponent<Light> ();
		startingMain = mainLight.color;
	}

	void Update() {
		if (Vector3.Distance(player.transform.position, crystalParticles.transform.position) <= dist && !doneCleansing) {

			angle += 0.05f;
			lightPulse.range = Mathf.Abs((Mathf.Sin (angle) * 10f));
			lightPulse.color = Color.white * (lightPulse.range / 10f);
			mainLight.color = Color.white * (lightPulse.range / 10f);

			if (!bg.renderer.enabled) {
				bg.renderer.enabled = true;
				fg.renderer.enabled = true;
			}

			crystalParticles.startColor = Color.Lerp(crystalParticles.startColor, Color.white, Time.deltaTime* (cleanse/100));

			/*if (lightPulse.color.r > 0.95f) {
				lightPulse.color = Color.Lerp (lightPulse.color, startingColor, Time.deltaTime);
				mainLight.color = Color.Lerp (mainLight.color, Color.black, Time.deltaTime);
			}
			else {
				lightPulse.color = Color.Lerp (lightPulse.color, Color.white, Time.deltaTime);
				mainLight.color = Color.Lerp (mainLight.color, Color.black, Time.deltaTime);
			}*/

			renderer.material.color = crystalParticles.startColor;
			if (crystalParticles.startSpeed != 10) {
				crystalParticles.startSpeed += 1;
			}

			cleanse += 5f * Time.deltaTime;

			if (cleanse >= 100 && cleanse <= 105) {
				cleansed = true;
			}

			fg.transform.localScale = new Vector3(bg.transform.localScale.x * cleanse / 100, fg.transform.localScale.y, fg.transform.localScale.z);
		}
		else if (!doneCleansing) {

			lightPulse.range = 0f;
			crystalParticles.startColor = Color.Lerp(crystalParticles.startColor, startingColor, smooth * Time.deltaTime);
			renderer.material.color = crystalParticles.startColor;
			if (crystalParticles.startSpeed != 3) {
				crystalParticles.startSpeed -= 1;
			}

			//mainLight.color = Color.white;

		}

		if (cleansed) {
			doneCleansing = true;
			endState.numCrystals--;
			cleansedImage.color = Color.white;
			crystalParticles.Stop();
			bg.renderer.enabled = false;
			fg.renderer.enabled = false;
			lightPulse.range = 10f;
			lightPulse.color = Color.white;
			mainLight.color = startingMain;
			player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().startingHealth;
			player.GetComponent<PlayerHealth>().TakeDamage(0);
		}
		else {
			cleansedImage.color = Color.Lerp (cleansedImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		cleansed = false;

		//cleanseSlider.value = cleanse;
	}

}
