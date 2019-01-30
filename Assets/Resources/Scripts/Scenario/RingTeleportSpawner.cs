using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTeleportSpawner : MonoBehaviour {

	public GameObject ringTeleport;
	public bool spawned;
	public bool spawnOnStart;
	public bool spawnOnCollider;
	public bool spawnOnCall;

	public string targetSceneName;
	public Transform playerSpawnerPoint;

	// Use this for initialization
	void Start () {
		if (!spawned && spawnOnStart) {
			spawnRingTeleport();
		}
	}

	// Update is called once per frame
	void Update () {
		if (spawnOnCall) {
			spawnRingTeleportCall ();
		}
	}

	void spawnRingTeleport(){
		GameObject ringtp = (GameObject)Instantiate (ringTeleport, this.transform.position, Quaternion.identity);
		//ringtp.transform.SetParent (this.transform);
		ringtp.GetComponent<RingTeleport> ().sceneName = targetSceneName;
		ringtp.GetComponent<RingTeleport> ().playerSpawner = playerSpawnerPoint;
		spawned = true;
	}

	void spawnRingTeleportCall(){
		spawnOnCall = false;
		spawnRingTeleport ();

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && spawnOnCollider) {
			this.spawnOnCall = true;
		}
	}
		
}
