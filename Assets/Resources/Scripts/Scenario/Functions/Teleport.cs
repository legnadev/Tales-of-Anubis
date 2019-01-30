using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	public GameObject myPlayer;
	public GameObject teleportTarget;
	public bool teleportOnCollide;
	public bool teleportOnKey;

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D target){
		
		if (target.transform.tag == "Player") {
			myPlayer = target.gameObject;

			if (teleportOnCollide && !teleportOnKey) {
				TeleportPlayer (teleportTarget.transform);
			}

			// If we don't tp with collider, then the requisit
			if (teleportOnKey && !teleportOnCollide) {
				//Push a button
				if (GameManager.Instance.InputController.useItem){
					TeleportPlayer (teleportTarget.transform);
				}
			}

		}

	}

	public void TeleportPlayer(Transform teleportPoint){
		myPlayer.transform.position = teleportPoint.transform.position;
	}
}
