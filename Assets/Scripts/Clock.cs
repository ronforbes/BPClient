using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

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

    public float TimeRemaining;

	public enum ClockState {
		GameStart,
		GamePlay,
		GameEnd
	}

	public ClockState State;

	float gameStartDuration = 3.0f;
	float gamePlayDuration = 10.0f;
	float gameEndDuration = 3.0f;

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
					
				}
				break;
		}
		
	}
}
