using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void Play() {
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
