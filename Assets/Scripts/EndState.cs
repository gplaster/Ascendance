using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndState : MonoBehaviour {

	public int numCrystals = 5;
	public Text text;
	public PlayerHealth playerHealth;
	public GameObject player;

	public GameObject[] crystalScript;
	public GameObject[] platformCollide;

	public bool finalPlayerIsDead;
	
	void Awake() {
		text.text = "";
		finalPlayerIsDead = false;
	}

	void Update () {

		if (Time.timeSinceLevelLoad > 1 && Time.timeSinceLevelLoad < 6) {
			text.text = "Cleanse all the Vitrelux crystals!";
		}
		// Need to do a range of times again so this doesn't interfere with the coroutines below.
		else if (Time.timeSinceLevelLoad > 6 && Time.timeSinceLevelLoad < 9) {
			text.text = "";
		}

		if (numCrystals <= 0) {
			StartCoroutine(checkEndState());
		}

		if (playerHealth.isDead) {
			finalPlayerIsDead = true;
			StartCoroutine(checkDeathState());
		}
	}

	IEnumerator checkEndState() {

		text.text = "Congratulations! You've cleansed all the crystals and saved Zorah!";
		yield return new WaitForSeconds(3);
		text.text = "";
		Application.LoadLevel("Start_Screen");
	}

	IEnumerator checkDeathState() {

		Destroy (player.gameObject);
		text.text = "You have been defeated!";
		yield return new WaitForSeconds(3);
		text.text = "";
		Application.LoadLevel("Start_Screen");
	}
	
	IEnumerator PauseWaitResume (float pauseDelay) {
		Time.timeScale = 0.0000001f;
		yield return new WaitForSeconds(pauseDelay * Time.timeScale);
		Time.timeScale = 1.0f;
	}
}
