using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rueda : MonoBehaviour {

	float timer = 0.5f;
	InputController playerInput;

	void Awake(){
		playerInput = GameManager.Instance.InputController;
		
	}


	
	// Update is called once per frame
	void Update () {
		

		if (playerInput.wheelLeft) {

			this.gameObject.transform.Rotate (0, 0, +0.3f);
		}
		if (playerInput.wheelRight){
			this.gameObject.transform.Rotate (0, 0, -0.3f);
		}
	}
}
