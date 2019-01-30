using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedRun : MonoBehaviour {

	public Text timeText;

	public bool firstTime = true;

	// Timer
	public float timeToComplete;
	public float timer;
	public bool timeIsRunning;

	// Freeze time
	public bool timeIsFrozen;
	public float frozenTimer;

	// Use this for initialization
	void Start () {
		timeIsRunning = true;
		timer = timeToComplete;
		timeText.text = timer.ToString ("0.0");
	}
	
	// Update is called once per frame
	void Update () {
		if (timeIsRunning && !firstTime) {
			timeText.color = new Color (0f, 0f, 0f);
			timer -= Time.deltaTime;
			timeText.text = timer.ToString ();
		}

		if (!timeIsRunning & timeIsFrozen) {
			timeText.color = new Color (0.7f, 0.6f, 0.15f);
			frozenTimer -= Time.deltaTime;
			if (frozenTimer <= 0) {
				unFreezeTime ();
			}
		}
	}


	public void freezeTime(string frozenTime){
		if (firstTime = true) {
			firstTime = false;
		}
		timeIsRunning = false;
		timeIsFrozen = true;
		frozenTimer = float.Parse (frozenTime);
	}

	public void unFreezeTime(){
		timeIsFrozen = false;
		timeIsRunning = true;
	}

	void OnEnable ()
	{
		//EventManager.StartListening ("test", someListener);
		EventManager.StartListening ("Freeze",  freezeTime);
	}

	void OnDisable ()
	{
		// EventManager.StopListening ("test", someListener);
		EventManager.StopListening ("Freeze",  freezeTime);
	}

}
