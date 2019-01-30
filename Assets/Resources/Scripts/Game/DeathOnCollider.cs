using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnCollider : MonoBehaviour {

	public string targetTag = "Player";

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			Debug.Log("Debug here");
			GameManager.Instance.localPlayer.DeathRespawn();
		}
	}
}
