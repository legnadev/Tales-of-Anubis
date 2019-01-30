using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public int dmg;
	public float cooldown;

	public float timer;
	public bool canFire;


	// Use this for initialization
	void Start () {
		cooldown = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			canFire = true;
		}
			
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			ApplyDmg (dmg, other.gameObject.GetComponent<Enemy> ());
		}

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy" && canFire)
		{
			ApplyDmg (dmg, other.gameObject.GetComponent<Enemy> ());
			canFire = false;
			timer = cooldown;
		}

		if (other.gameObject.tag == "Scorpion")
		{
			ApplyDmgg (dmg, other.gameObject.GetComponent<Scorpion> ());
			canFire = false;
			timer = cooldown;
		}

	}

	void ApplyDmg(int dmg, Enemy enemyGO){
		// Spawn FX or Hit FX
		enemyGO.applyDmg (dmg);

	}

	void ApplyDmgg(int dmg, Scorpion enemyGO){
		enemyGO.applyDmg (dmg);
	}
}
