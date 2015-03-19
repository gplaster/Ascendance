using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour {

	public EnemyManager enemyManager;
	public GameObject player;
	public PlayerMovement playerMovement;
	public Animator anim;
	public float spawnDistance = 20f;
	public float spawnWait = 5f;
	public float freezeTime = 0f;
	public float unFreezeTime = 15f;
	public Canvas canvas;
	public float shootTextTime = 0f;
	public float moveTextTime = 0f;
	public float jumpTextTime = 0f;
	public float alertTextTime = 0f;
	public float textTimer = 5f;
	public float delayTimer = 2f;

	private Text text;

	void Awake() {

		enemyManager.spawnTime = spawnWait;
		enemyManager.enemiesToSpawn = 0;
		text = canvas.GetComponentInChildren<Text>();
	}

	void Update() {

		/*if (moveTextTime == 0) {
			moveTextTime = Time.time;
			text.text = "Use the A and D keys to move!";
		}
		else if ((Time.time - moveTextTime == textTimer) && shootTextTime == 0) {
			text.text = "";
		}
		else if ((Time.time - moveTextTime > (textTimer + delayTimer)) && shootTextTime == 0) {
			shootTextTime = Time.time;
			text.text = "Click to shoot a fireball!";
		}
		else if ((Time.time - shootTextTime >= textTimer) && jumpTextTime == 0) {
			text.text = "";
		}
		else if ((Time.time - shootTextTime > (textTimer + delayTimer)) && jumpTextTime == 0) {
			jumpTextTime = Time.time;
			text.text = "Use the Spacebar to jump!";
		}
		else if (Time.time - jumpTextTime >= textTimer) {
			text.text = "";
		}*/

		if (Time.time < delayTimer) {
			text.text = "";
		}
		else if ((Time.time < (delayTimer + textTimer)) && freezeTime == 0) {
			text.text = "Use the A and D keys to move!";
		}
		else if ((Time.time < (delayTimer + (2 * textTimer))) && freezeTime == 0) {
			text.text = "Click to shoot a fireball!";
		}
		else if ((Time.time < (delayTimer + (3 * textTimer))) && freezeTime == 0) {
			text.text = "Use the Spacebar to jump!";
		}
		else if ((Time.time < (delayTimer + (4 * textTimer))) && freezeTime == 0){
			text.text = "";
		}

		if (Vector3.Distance(player.transform.position, enemyManager.spawnPoints[0].position) <= spawnDistance) {

			/* Initialize timer to the time at this point and freeze player movement */
			if (freezeTime == 0) {
				freezeTime = Time.time;
				playerMovement.enabled = false;
				anim.SetBool("isWalking", false);
				text.text = "Uh oh! It looks like an enemy is approaching!\nUse what you've learned to defend yourself!\n" +
					"Stand near the Vitrelux crystal shards to cleanse them!";
			}

			/* Wait until timer runs out to return movement control to player */
			if (Time.time - freezeTime >= unFreezeTime) {
				playerMovement.enabled = true;
				/* Spawn single enemy */
				enemyManager.enemiesToSpawn = 1;
				text.text = "";
			}
		}
	}
}
