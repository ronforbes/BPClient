using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour {
	InputField nameInputField;

	void Awake() {
		nameInputField = GameObject.Find("Name Input Field").GetComponent<InputField>();
	}	

	// Use this for initialization
	void Start () {
		
	}
	
	public void Play() {
		if(nameInputField.text != "") {
			Player.Instance.Name = nameInputField.text;
		}

		Clock.Instance.ControlSceneState = true;

		switch(Clock.Instance.State) {
			case Clock.ClockState.Game:
				SceneManager.LoadScene("Game");
				break;

			case Clock.ClockState.Results:
				SceneManager.LoadScene("Results");
				break;

			case Clock.ClockState.Leaderboard:
				SceneManager.LoadScene("Leaderboard");
				break;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
