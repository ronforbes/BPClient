using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionManager : MonoBehaviour {
	static VersionManager instance;
    public static VersionManager Instance
    {
        get
        {
            // Get the singleton instance of the Game Clock
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<VersionManager>();

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }
	
	public int Major;
	public int Minor;
	public int Patch;

	Text versionLabel;

	void Awake() {
		versionLabel = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		versionLabel.text = "Version " + Major + "." + Minor + "." + Patch;
	}
}
