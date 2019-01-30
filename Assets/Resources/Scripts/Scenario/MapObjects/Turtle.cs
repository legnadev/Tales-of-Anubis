using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {

	public enum TurtleStatus {Waiting, Hit, Stunned};
	public TurtleStatus myTurtleStatus;

	public Animator myTurtleAnimator;

	// Use this for initialization
	void Start () {
		myTurtleStatus = TurtleStatus.Waiting;
		myTurtleAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			Hit();
		}
	}

	public void Hit(){
		myTurtleAnimator.SetTrigger("Hit");
		Stun ();
	}

	public void EndHit(){
		// Animation hit
		Stun ();
	}
		

	public void Stun(){
		// Animator to stun
		myTurtleAnimator.SetTrigger("Stunned");
		Invoke("RestartToWait", 1.0f);
	}

	public void RestartToWait(){
		// Animator to Waiting
		myTurtleAnimator.SetTrigger("Waiting");
		myTurtleStatus = TurtleStatus.Waiting;
	}
		
}
