using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMirror : MonoBehaviour {
	public bool cameraOk;
	public bool cameraMirrored;

	public float[] cameraGrades;

	// Use this for initialization
	void Start () {
		cameraOk = true;
		cameraMirrored = false;
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			cameraMirror();
			Destroy (this.gameObject);
		}

	}

	void cameraMirror(){
		//float cameraSize = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize;
		//GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize = -Mathf.Abs (cameraSize);
		//GameObject.FindGameObjectWithTag ("MainCamera").transform.eulerAngles = new Vector3 (0, 0, cameraGrades[Random.Range (0,3)]);
		float cameraSize = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize;
		if (cameraSize < 0f) {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize = Mathf.Abs (cameraSize);
		} else if (cameraSize > 0f) {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize = -Mathf.Abs (cameraSize);
		}

	}

}
