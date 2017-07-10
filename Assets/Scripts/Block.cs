using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
	public int X, Y, Type;
	public const int TypeCount = 6;

	public enum BlockState
    {
        Empty,
        Idle,
        Sliding,
        WaitingToFall,
        Falling,
        Matched,
        WaitingToClear,
        Clearing,
        WaitingToEmpty,
    }

	public BlockState State;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
