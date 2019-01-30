using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour {
	public float duration = 1f;
	public float originalDuration;
	public Light myLight;
	public float originalRange;
	public float finalRange;

	public float sumador;

	public bool isEyeOfRa;

	// Use this for initialization
	void Start () {
		myLight = this.gameObject.GetComponent<Light> ();
		originalRange = myLight.range;
		var originalDuration = duration;
	}
	
	// Update is called once per frame
	void Update () {
		if (isEyeOfRa) {


		} else {
			duration -= Time.deltaTime;
			if ( duration < 0 )
			{
				duration = originalDuration;
				moveTorchLight();
			}
		}


	}

	void moveTorchLight(){
		myLight.range = Random.Range (originalRange, finalRange);
	}
}
