using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void Back() {
		Clock.Instance.ControlSceneState = false;

		SceneManager.LoadScene("Lobby");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
