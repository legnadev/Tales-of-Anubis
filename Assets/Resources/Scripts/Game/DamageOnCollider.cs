using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollider : MonoBehaviour {
	public string targetTag = "Player";
	public bool destroyOnCollider;
	[SerializeField] private int dmg;

	public bool stopOnGround;
	private bool canDamage = true;

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Ground") {
			if (stopOnGround) {
				canDamage = false;
			}
		}

		if (target.gameObject.tag == targetTag && canDamage) {
			print ("Apply Dmg");
			GameManager.Instance.localPlayer.ApplyDamage (dmg);
			if (destroyOnCollider) {
				Destroy (gameObject);
			}
		}
	}
}
