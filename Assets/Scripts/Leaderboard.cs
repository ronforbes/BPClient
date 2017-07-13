using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {
	static Leaderboard instance;
    public static Leaderboard Instance
    {
        get
        {
            // Get the singleton instance of the Game Clock
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Leaderboard>();

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    List<GameResults> leaderboard;

	bool hasPreparedLeaderboard;

	// Use this for initialization
	void Start () {
		hasPreparedLeaderboard = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Clock.Instance.State == Clock.ClockState.Results) {
            hasPreparedLeaderboard = false;
        }

        if(Clock.Instance.State == Clock.ClockState.Leaderboard && !hasPreparedLeaderboard) {
			hasPreparedLeaderboard = true;

            WWW leaderboardRequest = new WWW("http://blockprty.azurewebsites.net/api/leaderboard");
            StartCoroutine(OnLeaderboardRequest(leaderboardRequest));
		}	
	}

    IEnumerator OnLeaderboardRequest(WWW request) {
        yield return request;

        if(!string.IsNullOrEmpty(request.error)) {
			Debug.Log("Error: " + request.error);
		}
		else {
            Debug.Log(request.text);
            string newJson = "{\"Items\":" + request.text + "}";
            leaderboard = JsonHelper.FromJson<GameResults>(newJson);

            Text nameText = GameObject.Find("Name Text").GetComponent<Text>();
            Text scoreText = GameObject.Find("Score Text").GetComponent<Text>();

            nameText.text = "";
            scoreText.text = "";

            foreach(GameResults results in leaderboard) {
                nameText.text += results.name + "\n";
                scoreText.text += results.score + "\n";
            }
        }
    }
}

public static class JsonHelper {
    public static List<T> FromJson<T>(string json) {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    [Serializable]
    private class Wrapper<T> {
        public List<T> Items;
    }
}