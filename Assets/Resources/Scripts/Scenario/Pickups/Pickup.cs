using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	
	public int pickedAmount;
	[SerializeField] bool picked;
	public bool isReusable;
	public int cooldown = 1;

	// Use this for initialization
	public virtual void Start () {
		picked = false;
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (!picked) {
			if (other.transform.tag == "Player") {
				pickedItem ();
			}
		}
	}

	void spawn(){
		picked = false;
		this.gameObject.SetActive (true);
	}

	void despawn(){
		picked = true;
		this.gameObject.SetActive (false);
	}

	public virtual void pickedItem(){
		if (!isReusable) {
			despawn ();
		} else if (isReusable) {
			despawn ();
			Invoke ("spawn", cooldown);
		}
	}
}
