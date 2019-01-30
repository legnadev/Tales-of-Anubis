using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLive : Pickup {

	public override void pickedItem ()
	{
		GameManager.Instance.localPlayer.AddLive (pickedAmount);
		EventManager.TriggerEvent ("Message", MessageManager.getMessageText("item_picked", pickedAmount.ToString(), "Vida"));
		base.pickedItem ();
	}
	
}
