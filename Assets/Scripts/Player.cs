using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	static Player instance;
    public static Player Instance
    {
        get
        {
            // Get the singleton instance of the Game Clock
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

	public string Name;

	// Use this for initialization
	void Start () {
		Name = "Guest";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
