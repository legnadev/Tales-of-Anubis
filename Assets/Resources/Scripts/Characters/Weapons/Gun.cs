using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public int ammo;
	public int dmg;
	public float cooldown;
	public float timer;
	public bool canFire;

	public Rigidbody2D bullet;
	public float bulletSpeed;

	public float direction;
	public Transform gunCheck;

	// Use this for initialization
	void Start () {
		timer = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		switchDirection ();

		timer -= Time.deltaTime;

		if (timer <= 0) {
			canFire = true;
		}

		if (GameManager.Instance.InputController.Fire1 && canFire) {
			shoot (bullet, gunCheck, dmg);
		}
	}

	void switchDirection(){
		if (GameManager.Instance.InputController.horizontalAxis < 0) {
			bulletSpeed = -Mathf.Abs (bulletSpeed);
		}
		if (GameManager.Instance.InputController.horizontalAxis > 0) {
			bulletSpeed = Mathf.Abs (bulletSpeed);
		}
	}

	public void shoot(Rigidbody2D bullet, Transform gunCheck, int dmg){
		Rigidbody2D bulletGO = Instantiate (bullet, gunCheck.transform.position, gunCheck.rotation) as Rigidbody2D;
		bulletGO.gameObject.GetComponent<Bullet> ().dmg = dmg;
		bulletGO.velocity = new Vector2 (bulletSpeed, 0);
		canFire = false;
		timer = cooldown;
		EventManager.TriggerEvent ("BulletSpawned", "aa");
	}
		
}
