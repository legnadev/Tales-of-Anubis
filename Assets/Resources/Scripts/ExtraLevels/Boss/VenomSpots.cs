using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomSpots : MonoBehaviour {

	public Transform currentSpot;
	public List<GameObject> spots = new List<GameObject> ();

	public int pointSelection;

	// Use this for initialization
	void Start () {

		spots.AddRange (GameObject.FindGameObjectsWithTag ("VenomSpot"));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
