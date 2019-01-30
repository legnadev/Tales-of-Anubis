using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {

	public Transform target;

	public float speed;

	public bool isSpawned;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		isSpawned = true;
	}

	// Update is called once per frame
	void Update () {
		if (!isSpawned) {
			transform.LookAt (target);

		}
		if (isSpawned) {
			//print ("Moviendome?");
			Transform targetNewPosition = target;
			float step = speed * Time.deltaTime;

			transform.position = Vector3.MoveTowards (transform.position, targetNewPosition.position, step);
		}

	}

	void OnTriggerEnter2D(Collider2D bulletTarget){
		if (bulletTarget.gameObject.tag == "Bullet") {
			Destroy (bulletTarget.gameObject);
			Destroy (this.gameObject);
		}
	}
}
