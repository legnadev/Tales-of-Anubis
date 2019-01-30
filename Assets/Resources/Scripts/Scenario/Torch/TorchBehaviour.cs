using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehaviour : MonoBehaviour {
	[SerializeField] private GameObject myPointLight;
	public Light lt;

	[SerializeField] float m_Timer;
	public float timer{
		get {
			return m_Timer;
		}
		set{
			m_Timer = value;
			timeLeft = value;
		}
	}
	[SerializeField] float m_TimeLeft;
	public float timeLeft{
		get {
			return m_TimeLeft;
		}
		set{
			m_TimeLeft = value;
		}
	}

	public bool infiniteTime;
	public float intensity;

	 float timerhalf;
	 float timer3q;
	 float timer1q;

	// Use this for initialization
	void Start () {
		lt = myPointLight.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (infiniteTime) {

		} else if (!infiniteTime) {
			timeLeft -= Time.deltaTime;
	
			changeIntensity (timeLeft);
			if (timeLeft <= 0) {
				turnOff();
			} else {
				turnOn ();
			}
		}



	}

	public void _addTime(float addedTime){
		timer = addedTime;
		timerhalf = timer * 0.5f;
		timer3q = timer * 0.75f;
		timer1q = timer * 0.25f;
	}

	public static void addTime(float addedTime){
		new TorchBehaviour ()._addTime (addedTime);
	}

	public void turnOff(){
		myPointLight.SetActive (false);
		//myPointLight.GetComponent<Light> ().intensity = 0f;
	}

	public void turnOn(){
		myPointLight.SetActive (true);
		//myPointLight.GetComponent<Light> ().intensity = intensity;
	}

	public void changeIntensity(float currentTimeLeft){


		if (currentTimeLeft > timerhalf && currentTimeLeft < timer3q) {
			myPointLight.GetComponent<Light> ().intensity = 70;
		}
		else if (currentTimeLeft < timerhalf && currentTimeLeft > timer1q) {
			myPointLight.GetComponent<Light> ().intensity = 35;
		}
		else if (currentTimeLeft < timer * 0.10 && currentTimeLeft > 0) {
			myPointLight.GetComponent<Light> ().intensity = 10;
		}
	}
		
}
