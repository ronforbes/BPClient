using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour {
	static Clock instance;
    public static Clock Instance
    {
        get
        {
            // Get the singleton instance of the Game Clock
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Clock>();

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

	public bool ControlSceneState;

    public float TimeRemaining;

	public enum ClockState {
		GameStart,
		GamePlay,
		GameEnd,
		Results,
		Leaderboard
	}

	public ClockState State;

	float gameStartDuration = 3.0f;
	float gamePlayDuration = 10.0f;
	float gameEndDuration = 3.0f;
	float resultsDuration = 10.0f;
	float leaderboardDuration = 10.0f;

	void Awake()
    {
        // If this is the first instance, make it the singleton. If a singleton already exists and another reference is found, destroy it
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != instance)
                Destroy(this.gameObject);
        }
    }

	void Start() {
		State = ClockState.GameStart;

		ControlSceneState = false;
		
		TimeRemaining = gameStartDuration;
	}

	void Update()
    {
        TimeRemaining -= Time.deltaTime;

		switch(State) {
			case ClockState.GameStart:
				if(TimeRemaining <= 0.0f) {
					State = ClockState.GamePlay;

					TimeRemaining = gamePlayDuration;
				}
				break;

			case ClockState.GamePlay:
				if(TimeRemaining <= 0.0f) {
					State = ClockState.GameEnd;

					TimeRemaining = gameEndDuration;
				}
				break;

			case ClockState.GameEnd:
				if(TimeRemaining <= 0.0f) {
					if(ControlSceneState) {
						SceneManager.LoadScene("Results");
					}

					State = ClockState.Results;

					TimeRemaining = resultsDuration;
				}
				break;

			case ClockState.Results:
				if(TimeRemaining <= 0.0f) {
					if(ControlSceneState) {
						SceneManager.LoadScene("Leaderboard");
					}

					State = ClockState.Leaderboard;

					TimeRemaining = leaderboardDuration;
				}
				break;

			case ClockState.Leaderboard:
				if(TimeRemaining <= 0.0f) {
					if(ControlSceneState) {
						SceneManager.LoadScene("Game");
					}

					State = ClockState.GameStart;

					TimeRemaining = gameStartDuration;

					ScoreManager.Instance.Reset();
				}
				break;
		}
		
	}
}
