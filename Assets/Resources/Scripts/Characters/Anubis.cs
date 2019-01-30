using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Anubis : MonoBehaviour {
	private PlatformerCharacter2D m_Character;

	public GameObject meleeWeapon;
	public GameObject distanceWeapon;
	public Gun myGun;

	public GameObject meleeFXAttack;

	public Animator anubisAnimator;
	InputController playerInput;

	void Awake(){
		playerInput = GameManager.Instance.InputController;
		anubisAnimator = GetComponent<Animator> ();

		meleeWeapon = GameObject.FindGameObjectWithTag ("MeleeWeapon");
		distanceWeapon = GameObject.FindGameObjectWithTag ("DistanceWeapon");

		myGun = distanceWeapon.GetComponent<Gun> ();
		meleeFXAttack = GameObject.Find ("meleeFX");

		meleeWeapon.SetActive (false);
		meleeFXAttack.SetActive (false);

		m_Character = GameObject.Find("Player").GetComponent<PlatformerCharacter2D>();

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateAnimator ();

		
	}

	void meleeAttackOn(int lel){
		print (lel);
		meleeWeapon.SetActive (true);
		meleeFXAttack.SetActive (true);
	}

	void meleeAttackOff(){
		meleeWeapon.SetActive (false);
		meleeFXAttack.SetActive (false);
	}

	void distanceAttackOn(){
		myGun.shoot (myGun.bullet, myGun.gunCheck, myGun.dmg);
	}

	void updateAnimator(){

		if (playerInput.Fire1) {
			anubisAnimator.SetBool ("Fire1", true);
			//Shoot
		} else {
			anubisAnimator.SetBool ("Fire1", false);
		}

		if (playerInput.Fire2) {
			anubisAnimator.SetBool ("Fire2", true);
		} else {
			anubisAnimator.SetBool ("Fire2", false);
		}

	}

	void ledgeOut(){
		m_Character.Ledge (false, null);
	}
}
