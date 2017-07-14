using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputFieldController : MonoBehaviour {
	InputField inputField;

	void Awake() {
		inputField = GetComponent<InputField>();
	}

	// Use this for initialization
	void Start () {
		if(Player.Instance.Name != "Guest") {
			inputField.text = Player.Instance.Name;
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
