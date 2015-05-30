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

	void Start() {

		waiting = true;
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


		StartCoroutine (wait(3f));
	}

	void Update() {

		if (!waiting) {
			title.color = Color.Lerp (title.color, saveColor, Time.time * 0.0025f);
			Outline outL = title.GetComponent<Outline> ();
			Shadow shaL = title.GetComponent<Shadow> ();
			outL.effectColor = Color.Lerp (outL.effectColor, saveOutline, Time.time * 0.0005f);
			shaL.effectColor = Color.Lerp (shaL.effectColor, saveShadow, Time.time * 0.0005f);

			startButton.image.color = Color.Lerp (startButton.image.color, saveStart, Time.time * 0.0025f);
			startText.color = Color.Lerp (startText.color, saveStartText, Time.time * 0.0025f);
			Outline sT = startText.GetComponent<Outline>();
			sT.effectColor = Color.Lerp (sT.effectColor, saveStartOutline, Time.time * 0.0005f);

			tutorialButton.image.color = Color.Lerp (tutorialButton.image.color, saveTutorial, Time.time * 0.0025f);
			tutorialText.color = Color.Lerp (tutorialText.color, saveTutorialText, Time.time * 0.0025f);
			Outline tT = tutorialText.GetComponent<Outline>();
			tT.effectColor = Color.Lerp (tT.effectColor, saveTutorialOutline, Time.time * 0.0005f);
		}
	}

	IEnumerator wait(float seconds){
		yield return new  WaitForSeconds(seconds);
		waiting = false;
	}

	public void startGame() {
		Application.LoadLevel ("Level_01");
	}

	public void startTutorial() {
		Application.LoadLevel ("Tutorial_Level");
	}
}
