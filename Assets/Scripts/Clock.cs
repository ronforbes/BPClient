using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class GameRoom {
	public enum GameState {
		Game,
		Results,
		Leaderboard
	}
	public int state;
	public GameState State;
	public string nextStateTime;
	public DateTime NextStateTime;
}

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

	public enum ClockState {
		Game,
		Results,
		Leaderboard
	}

	public ClockState State;

	float gameDuration = 10.0f;
	float resultsDuration = 10.0f;
	float leaderboardDuration = 10.0f;

	public float TimeRemaining = 0.0f;

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
		// Sync to the server game room state
		SyncToGameRoomState();

		ControlSceneState = false;

		InvokeRepeating("SyncToGameRoomState", 30.0f, 30.0f);
	}

	void SyncToGameRoomState() {
		WWW gameRoomRequest = new WWW("http://localhost:5000/api/gameroom");
		StartCoroutine(OnGameRoomRequest(gameRoomRequest));
	}

	IEnumerator OnGameRoomRequest(WWW request) {
		// Wait until the request has received a response
		yield return request;
		
		if(!string.IsNullOrEmpty(request.error)) {
			Debug.Log("Error: " + request.error);
		}
		else {
			GameRoom room = JsonUtility.FromJson<GameRoom>(request.text);

			State = (ClockState)room.state;
			DateTime nextStateTime = DateTime.Parse(room.nextStateTime);

			// Not sure why local time is 4 hours ahead of server time but compensate for it anyway
			TimeRemaining = (float)(nextStateTime - (DateTime.UtcNow - TimeSpan.FromHours(4))).TotalSeconds;

			Debug.Log("Synced client clock to server");
		}
	}

	void Update()
    {
		TimeRemaining -= Time.deltaTime;

		if(TimeRemaining <= 0.0f) {
			switch(State) {
				case ClockState.Game:
					State = ClockState.Results;
					TimeRemaining = resultsDuration;
					if(ControlSceneState) {
						SceneManager.LoadScene("Results");
					}
					break;
				
				case ClockState.Results:
					State = ClockState.Leaderboard;
					TimeRemaining = leaderboardDuration;
					if(ControlSceneState) {
						SceneManager.LoadScene("Leaderboard");
					}
					break;

				case ClockState.Leaderboard:
					State = ClockState.Game;
					TimeRemaining = gameDuration;
					if(ControlSceneState) {
						SceneManager.LoadScene("Game");
					}
					break;
			}
		}	
	}
}
