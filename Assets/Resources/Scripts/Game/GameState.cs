using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public GameObject pauseScreen;

    public enum gameStates
    {
        Menu,
        Playing,
        Pause,
        Dead
    };

    
    public static gameStates currentState;

	// Use this for initialization
	void Start () {
        currentState = gameStates.Playing;
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}
}
