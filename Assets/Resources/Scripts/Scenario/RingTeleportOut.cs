using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingTeleportOut : RingTeleport {

	public override void Start ()
	{
		
		base.Start ();
	}
	
	public override void Update ()
	{
		base.Update ();
	}

	public override void endTeleport ()
	{
		base.endTeleport ();
		GameManager.Instance.restartGameManager ();
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);

	}

	public override void handlePlayer ()
	{
		myPlayer.SetActive (false);
	}
}
