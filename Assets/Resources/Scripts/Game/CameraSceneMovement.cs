using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSceneMovement : MonoBehaviour {

	public float timeToFade;
	public Transform newPosition;

	public bool hasReachedEnd;
	public float timer;

	// Use this for initialization
	void Start () {
		timer = timeToFade / 100;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp (transform.position, newPosition.position, Time.deltaTime * timer);

	}


}
