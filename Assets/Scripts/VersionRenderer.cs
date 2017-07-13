using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionRenderer : MonoBehaviour {
	Text versionLabel;

	void Awake() {
		versionLabel = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		versionLabel.text = "Version " + VersionManager.Instance.Major + "." + VersionManager.Instance.Minor + "." + VersionManager.Instance.Patch;
	}
}
