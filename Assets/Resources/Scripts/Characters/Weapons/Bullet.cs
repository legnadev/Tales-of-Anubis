using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int dmg;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "GuardCollider")
		{
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Enemy")
		{
			ApplyDmg (dmg, other.gameObject.GetComponent<Enemy> ());
			Destroy (gameObject);
		}

		if (other.gameObject.tag == "Scorpion")
		{
			ApplyDmgg (dmg, other.gameObject.GetComponent<Scorpion> ());
			Destroy (gameObject);
		}

			
	}

	void ApplyDmg(int dmg, Enemy enemyGO){
		enemyGO.applyDmg (dmg);
	}

	void ApplyDmgg(int dmg, Scorpion enemyGO){
		enemyGO.applyDmg (dmg);
	}
}
