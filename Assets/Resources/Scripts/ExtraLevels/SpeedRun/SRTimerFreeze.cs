using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRTimerFreeze : MonoBehaviour {

	public float freezeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			EventManager.TriggerEvent ("Freeze", freezeTime.ToString());
		}
	}

}
