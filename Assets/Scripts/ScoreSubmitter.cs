using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class GameResults {
    public string name;
    public string Name;
    public int score;
    public int Score;

    public GameResults(string name, int score) {
        Name = name;
        Score = score;
    }
}

public class ScoreSubmitter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameResults results = new GameResults("Ron", ScoreManager.Instance.Score);
            string serializedResults = JsonUtility.ToJson(results);

            byte[] body = Encoding.UTF8.GetBytes(serializedResults);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("Content-Length", body.Length.ToString());
            WWW request = new WWW("http://www.blokprty.com/api/gameresults", body, headers);
            
            StartCoroutine(OnGameResultsRequest(request));
	}

	    IEnumerator OnGameResultsRequest(WWW request) {
        yield return request;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
