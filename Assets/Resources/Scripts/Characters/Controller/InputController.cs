using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public float verticalAxis;
	public float horizontalAxis;

	public bool useItem;

	public bool Fire1;
	public bool Fire2;
	public bool isJumping;
	public bool isWalking;

	public bool wheelLeft;
	public bool wheelRight;

	public bool timeControl;

	public bool menu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		verticalAxis = Input.GetAxis ("Vertical");
		horizontalAxis = Input.GetAxis ("Horizontal");

		useItem = wheelRight = Input.GetKeyDown (KeyCode.E);
		timeControl = Input.GetKeyDown (KeyCode.T);

		Fire1 = Input.GetButton ("Fire1");
		Fire2 = Input.GetButton ("Fire2");
		isJumping = Input.GetButtonDown("Jump");
		isJumping = Input.GetKeyDown (KeyCode.Space);
		isWalking = Input.GetKey (KeyCode.LeftControl);

		wheelLeft = Input.GetKey (KeyCode.K);
		wheelRight = Input.GetKey (KeyCode.L);

		menu = Input.GetButtonDown("Menu");
	}
}
