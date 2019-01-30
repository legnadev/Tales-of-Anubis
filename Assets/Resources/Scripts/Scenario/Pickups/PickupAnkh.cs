using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnkh : Pickup {
	
	public Sprite sAnkh;
	public Sprite gAnkh;

	public enum ankh
	{
		silver,
		gold
	}


	public ankh myAnkh = ankh.silver;

	public override void Start(){
		base.Start ();

		if (myAnkh == ankh.silver) {
			gameObject.GetComponentInChildren<SpriteRenderer> ().sprite = sAnkh;
		} else if (myAnkh == ankh.gold) {
			gameObject.GetComponentInChildren<SpriteRenderer> ().sprite = gAnkh;
		}
				}
	public override void pickedItem ()
	{
		if (myAnkh == ankh.silver) {
			GameManager.Instance.Stats.sAnkh += 1;
			EventManager.TriggerEvent ("Message", MessageManager.getMessageText("item_picked", "1", "Ankh de Plata"));
		} else if (myAnkh == ankh.gold) {
			GameManager.Instance.Stats.gAnkh += 1;
			EventManager.TriggerEvent ("Message", MessageManager.getMessageText("item_picked", "1", "Ankh de Oro"));
		}

		base.pickedItem ();
	}

}
