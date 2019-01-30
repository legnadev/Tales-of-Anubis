using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatformBehaviour : MonoBehaviour {
	
	public Transform platform;
	Rigidbody2D rb2D;
	public Transform pointA;
	public Transform pointB;

	public float speed = 10f;

	void Awake(){
		rb2D = platform.GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			do yield return null; while (moveRigidbody (transform.position, pointA.transform.position));
			do yield return null; while (moveRigidbody (transform.position, pointB.transform.position));
		}
	}

	bool moveRigidbody (Vector2 pos, Vector2 towards){
		Vector2 direction = (towards - pos).normalized;
		rb2D.MovePosition (rb2D.position + direction * speed * Time.deltaTime);
		return pos != towards;
	}

	bool MoveTowards (Transform target){
		platform.position = Vector3.MoveTowards (
			platform.position,
			target.position,
			speed * Time.deltaTime);
		return platform.position != target.position;
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			//GameManager.Instance.localPlayer.
		}
	}
}
