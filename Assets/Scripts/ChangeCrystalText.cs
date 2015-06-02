using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeCrystalText : MonoBehaviour {

	private EndState endState;
	private Text text;

	void Awake () {
		endState = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<EndState> ();
		text = GetComponent<Text> ();
	}

	void Update() {
		text.text = (5 - endState.numCrystals) + " of 5 Crystals\nCleansed";
	}
}
