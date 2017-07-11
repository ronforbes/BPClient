using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRenderer : MonoBehaviour {
	Text timeText;
	// Use this for initialization
	void Awake () {
		timeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = ((int)Clock.Instance.TimeRemaining + 1.0f).ToString();
	}
}
