using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTorch : Pickup {

	public override void pickedItem ()
	{
		GameManager.Instance.playerTorch.GetComponent<PlayerTorch>()._addTime(pickedAmount);
		base.pickedItem ();
	}
}
