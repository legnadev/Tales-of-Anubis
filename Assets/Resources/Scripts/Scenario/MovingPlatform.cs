using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;

	public float moveSpeed;
	public bool moveOnTouch;
	public bool touched;

	public Transform currentPoint;
	public Transform[] points;

	public int pointSelection;

	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
		if (moveOnTouch && touched) {
			movePlatform ();
		} else if (!moveOnTouch) {
			movePlatform ();
		}

	}

	void movePlatform(){
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

		if (platform.transform.position == currentPoint.position) {
			pointSelection++;
			if (pointSelection == points.Length) {
				pointSelection = 0;
			}

			currentPoint = points [pointSelection];
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.tag == "Player") {
			touched = true;
		}
	}

}
