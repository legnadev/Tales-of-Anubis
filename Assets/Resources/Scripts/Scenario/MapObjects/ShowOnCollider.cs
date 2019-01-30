using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnCollider : MonoBehaviour {

	private Transform childrenPlatform;

	// Use this for initialization
	void Start () {
		childrenPlatform = gameObject.transform.Find ("Plataforma");
		childrenPlatform.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.tag == "Player") {
			childrenPlatform.gameObject.SetActive (true);
		}
	}

}
