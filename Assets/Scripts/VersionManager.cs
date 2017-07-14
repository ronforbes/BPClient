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

	public int Major = 0;
	public int Minor = 0;
	public int Patch = 2;

	void Awake() {

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
