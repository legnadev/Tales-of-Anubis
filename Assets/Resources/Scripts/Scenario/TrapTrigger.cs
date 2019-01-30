using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour {

	public BoxCollider2D trapCollider;

	Animator myAnimator;

	private Rigidbody2D rb2d;
	public GameObject childTrap;

	void Awake(){
		trapCollider = this.GetComponent<BoxCollider2D> ();
		childTrap = this.gameObject.transform.GetChild (0).gameObject;
		myAnimator = childTrap.GetComponent<Animator> ();

	}
	// Use this for initialization
	void Start () {
		hideTrap ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D target){
		// Collider triggered if Player
		if (target.gameObject.tag == "Player") {
			showTrap ();
			Invoke ("hideTrap", 2);
		}
	}

	void showTrap(){
		childTrap.GetComponent<BoxCollider2D> ().enabled = true;
		myAnimator.SetTrigger ("Triggered");
	}

	void hideTrap(){
		myAnimator.SetTrigger ("Hidden");
		childTrap.GetComponent<BoxCollider2D> ().enabled = false;
	}

}
