using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFall : MonoBehaviour {

	public BoxCollider2D fallCollider;

	private Rigidbody2D rb2d;
	public GameObject childTrap;

	void Awake(){
		fallCollider = this.GetComponent<BoxCollider2D> ();
		childTrap = this.gameObject.transform.GetChild (0).gameObject;
		rb2d = childTrap.GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D target){
		// Collider triggered if Player
		if (target.gameObject.tag == "Player") {
			// Trigger to enable trap falling and enabling damagecollider for later.
			if (fallCollider.enabled == true) {
				rb2d.constraints = RigidbodyConstraints2D.None;
				fallCollider.enabled = false;
			} 
		}
	}

}
