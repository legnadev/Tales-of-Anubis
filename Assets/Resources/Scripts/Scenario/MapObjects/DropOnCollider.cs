using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnCollider : MonoBehaviour {

	private Transform childrenPlatform;
	private Rigidbody2D myRb;
	public float timeToDrop;

	// Use this for initialization
	void Start () {
		myRb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.tag == "Player") {
			Invoke ("Drop", timeToDrop);
		}
	}

	void Drop(){
		myRb.constraints = RigidbodyConstraints2D.None;
		Destroy (this.gameObject, 2);
	}

}
