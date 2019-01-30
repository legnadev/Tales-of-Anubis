using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTeleport : MonoBehaviour {
	public bool isCompleted;
	public bool isPlaying;
	public bool isPlayerSpawned;

	public GameObject colliders;

	public Transform playerSpawner;

	public GameObject myPlayer;
	private float originalSpeed;

	public string sceneName;

	void Awake(){
		
	}

	// Use this for initialization
	public virtual void Start () {
		myPlayer = GameObject.Find ("Player");
		originalSpeed = myPlayer.gameObject.GetComponent<Player> ().maxSpeed;
		playAnimation ();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (isPlaying && !isCompleted && !this.GetComponent<Animation> ().IsPlaying ("RingTeleport")) {
			isPlaying = false;
			isCompleted = true;
			endTeleport ();
		}

	}

	void playAnimation(){
		isPlaying = true;
		this.GetComponent<Animation>().Play("RingTeleport");
	}

	void removeColliders(){
		colliders.SetActive (false);
	}

	public virtual void endTeleport (){
	}

	public virtual void handlePlayer(){

	}

	public virtual void lockControl(){
		myPlayer.gameObject.GetComponent<Player> ().maxSpeed = 0;
	}
	public virtual void unlockControl(){
		myPlayer.gameObject.GetComponent<Player> ().maxSpeed = originalSpeed;
	}
}
