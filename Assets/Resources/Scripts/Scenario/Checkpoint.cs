using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	private GameObject myCheckpoint;

	void Awake(){
		myCheckpoint = this.gameObject;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			GameManager.Instance.localPlayer.currentCheckpoint = myCheckpoint;
		}
	}
}
