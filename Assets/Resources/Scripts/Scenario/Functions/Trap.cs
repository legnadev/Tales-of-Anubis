using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
	
	public CapsuleCollider2D damageCollider;
	private Rigidbody2D rb2d;
	public bool dmgTrigger;

	public int dmg = 1;

	void Awake(){
		damageCollider = this.GetComponent<CapsuleCollider2D> ();
		rb2d = this.GetComponent<Rigidbody2D>();
	}
	// Use this for initialization
	void Start () {
		dmgTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D target){
		// Collider triggered if Player
		if (target.gameObject.tag == "Player" || target.gameObject.tag == "Ramp") {
			// Only Trigger if damageCollider is on.
			if (damageCollider.enabled == true && dmgTrigger) {
				target.gameObject.SendMessage ("ApplyDamage", dmg);
				//damageCollider.enabled = false;
				dmgTrigger = false;
				damageCollider.isTrigger = false;
			}
		}
	}

}
