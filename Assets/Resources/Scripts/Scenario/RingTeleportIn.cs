using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTeleportIn : RingTeleport {

	public override void Start ()
	{
		base.Start ();
		myPlayer.transform.position = playerSpawner.position;
		myPlayer.SetActive (false);
	}
	
	public override void Update ()
	{
		base.Update ();
	}

	public override void endTeleport ()
	{
		
		Destroy (this.gameObject);
		base.endTeleport ();
	}

	public override void handlePlayer ()
	{
		myPlayer.SetActive (true);
	}
		
}
