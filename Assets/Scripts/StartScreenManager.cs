using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScreenManager : MonoBehaviour {

	public Image title;
	public Button startButton;
	public Text startText;
	public Button tutorialButton;
	public Text tutorialText;

	private Color saveColor;
	private Color saveOutline;
	private Color saveShadow;
	private Color saveStart;
	private Color saveStartText;
	private Color saveStartOutline;
	private Color saveTutorial;
	private Color saveTutorialText;
	private Color saveTutorialOutline;
	private bool waiting;
	private bool starting;
	private bool startupGame;
	private bool startupTutorial;
	private float timeOffset = 0f;
	private float textOffset = 0f;
	private float textSpeed = 15f;

	private RectTransform scrollText;

	void Start() {

		waiting = true;
		starting = false;
		startupGame = false;
		startupTutorial = false;
		timeOffset = Time.time;

		saveColor = title.color;
		saveOutline = title.GetComponent<Outline> ().effectColor;
		saveShadow = title.GetComponent<Shadow> ().effectColor;

		saveStart = startButton.image.color;
		saveStartText = startText.color;
		saveStartOutline = startText.GetComponent<Outline> ().effectColor;

		saveTutorial = tutorialButton.image.color;
		saveTutorialText = tutorialText.color;
		saveTutorialOutline = tutorialText.GetComponent<Outline> ().effectColor;

		title.color = new Color (saveColor.r, saveColor.g, saveColor.b, 0f);
		title.GetComponent<Outline> ().effectColor = new Color (saveOutline.r, saveOutline.g, saveOutline.b, 0f);
		title.GetComponent<Shadow> ().effectColor = new Color (saveShadow.r, saveShadow.g, saveShadow.b, 0f);
		startButton.image.color = new Color (saveStart.r, saveStart.g, saveStart.b, 0f);
		startText.color = new Color (saveStartText.r, saveStartText.g, saveStartText.b, 0f);
		startText.GetComponent<Outline> ().effectColor = new Color (saveStartOutline.r, saveStartOutline.g, saveStartOutline.b, 0f);
		tutorialButton.image.color = new Color (saveTutorial.r, saveTutorial.g, saveTutorial.b, 0f);
		tutorialText.color = new Color (saveTutorialText.r, saveTutorialText.g, saveTutorialText.b, 0f);
		tutorialText.GetComponent<Outline> ().effectColor = new Color (saveTutorialOutline.r, saveTutorialOutline.g, saveTutorialOutline.b, 0f);

		scrollText = GameObject.FindGameObjectWithTag ("IntroText").GetComponent<RectTransform>();
		StartCoroutine (wait(3f));
	}

	void Update() {

		timeOffset += Time.deltaTime;
		textOffset += Time.deltaTime * textSpeed;

		if (!waiting && !starting) {
			title.color = Color.Lerp (title.color, saveColor, timeOffset * 0.0025f);
			Outline outL = title.GetComponent<Outline> ();
			Shadow shaL = title.GetComponent<Shadow> ();
			outL.effectColor = Color.Lerp (outL.effectColor, saveOutline, timeOffset * 0.0005f);
			shaL.effectColor = Color.Lerp (shaL.effectColor, saveShadow, timeOffset * 0.0005f);

			startButton.image.color = Color.Lerp (startButton.image.color, saveStart, timeOffset * 0.0025f);
			startText.color = Color.Lerp (startText.color, saveStartText, timeOffset * 0.0025f);
			Outline sT = startText.GetComponent<Outline>();
			sT.effectColor = Color.Lerp (sT.effectColor, saveStartOutline, timeOffset * 0.0005f);

			tutorialButton.image.color = Color.Lerp (tutorialButton.image.color, saveTutorial, timeOffset * 0.0025f);
			tutorialText.color = Color.Lerp (tutorialText.color, saveTutorialText, timeOffset * 0.0025f);
			Outline tT = tutorialText.GetComponent<Outline>();
			tT.effectColor = Color.Lerp (tT.effectColor, saveTutorialOutline, timeOffset * 0.0005f);
		}

		if (starting) {
			title.color = Color.Lerp (title.color, new Color (saveColor.r, saveColor.g, saveColor.b, 0f), timeOffset * 0.0025f);
			Outline outL = title.GetComponent<Outline> ();
			Shadow shaL = title.GetComponent<Shadow> ();
			outL.effectColor = Color.Lerp (outL.effectColor, new Color (saveOutline.r, saveOutline.g, saveOutline.b, 0f), timeOffset * 0.0005f);
			shaL.effectColor = Color.Lerp (shaL.effectColor, new Color (saveShadow.r, saveShadow.g, saveShadow.b, 0f), timeOffset * 0.0005f);
			
			startButton.image.color = Color.Lerp (startButton.image.color, new Color (saveStart.r, saveStart.g, saveStart.b, 0f), timeOffset * 0.0025f);
			startText.color = Color.Lerp (startText.color, new Color (saveStartText.r, saveStartText.g, saveStartText.b, 0f), timeOffset * 0.0025f);
			Outline sT = startText.GetComponent<Outline>();
			sT.effectColor = Color.Lerp (sT.effectColor, new Color (saveStartOutline.r, saveStartOutline.g, saveStartOutline.b, 0f), timeOffset * 0.0005f);
			
			tutorialButton.image.color = Color.Lerp (tutorialButton.image.color, new Color (saveTutorial.r, saveTutorial.g, saveTutorial.b, 0f), timeOffset * 0.0025f);
			tutorialText.color = Color.Lerp (tutorialText.color, new Color (saveTutorialText.r, saveTutorialText.g, saveTutorialText.b, 0f), timeOffset * 0.0025f);
			Outline tT = tutorialText.GetComponent<Outline>();
			tT.effectColor = Color.Lerp (tT.effectColor, new Color (saveTutorialOutline.r, saveTutorialOutline.g, saveTutorialOutline.b, 0f), timeOffset);

			if (title.color.a < 0.01 && timeOffset > 1.0f) {
				if (startupGame) {
					Application.LoadLevel("Level_01");
				}

				if (startupTutorial) {
					if (textOffset == timeOffset) {
						textOffset = 0;
					}
					scrollText.position = Vector3.MoveTowards(scrollText.position, new Vector3(scrollText.position.x, 1200f, scrollText.position.z), textOffset * 0.0005f);

					if (scrollText.position.y > 1200f) {
						Application.LoadLevel("Level_01");
					}
				}
			}
		}
	}

	IEnumerator wait(float seconds){
		yield return new  WaitForSeconds(seconds);
		waiting = false;
	}

	public void startGame() {
		timeOffset = 0f;
		starting = true;
		startupGame = true;
	}

	public void startTutorial() {
		timeOffset = 0f;
		starting = true;
		startupTutorial = true;
	}
}
