using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour {
	
	public float cooldown;
	public bool isUsable;

	public float slowTime = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.InputController.timeControl) {
			skillTimeSlow ();
			Invoke ("RestartTimeSpeed2", slowTime);
		} 
	}

	void OnEnable ()
	{
		EventManager.StartListening ("SlowTimeSpeed",  SlowTimeSpeed);
		EventManager.StartListening ("RestartTimeSpeed", RestartTimeSpeed);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("SlowTimeSpeed",  SlowTimeSpeed);
		EventManager.StopListening ("RestartTimeSpeed", RestartTimeSpeed);
	}

	public void SlowTimeSpeed(string message) {
		Time.timeScale = 0.3f;
	}

	void RestartTimeSpeed(string message){
		Time.timeScale = 1f;
	}

	public void skillTimeSlow(){
		isUsable = false;
		Time.timeScale = 0.3f;
	}

	public void RestartTimeSpeed2(){
		Time.timeScale = slowTime;
		EventManager.TriggerEvent ("SetCooldown", "timeControl");
	}

	void restartCooldown(){
		isUsable = true;
	}
}
