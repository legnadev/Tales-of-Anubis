using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	public enum gateState
	{
		unlocked,
		locked
	}

	public int gatePrice;
	public PickupAnkh.ankh ankhCurrency = PickupAnkh.ankh.gold;
	public gateState myGateState = gateState.locked;
	public bool inCollider;

	public bool hasBlockCollider;
	public GameObject myBlockCollider;

	public Animator myGateAnimator;
	private Teleport myTeleport;

	// Gate children to indicate the price and so
	public GameObject childrenGate;
	public Sprite sAnkh;
	public Sprite gAnkh;

	void Awake(){
		myTeleport = gameObject.GetComponent<Teleport> ();
		childrenGate = this.gameObject.transform.GetChild (0).gameObject;
		myGateAnimator = this.GetComponent<Animator> ();
		if (hasBlockCollider) {
			myBlockCollider = this.transform.Find ("BlockCollider").gameObject;
		}
	}
	// Use this for initialization
	void Start () {
		updateGateState(myGateState);

		if (ankhCurrency == PickupAnkh.ankh.silver) {
			childrenGate.GetComponent<SpriteRenderer>().sprite = sAnkh;
		} else if (ankhCurrency == PickupAnkh.ankh.gold) {
			childrenGate.GetComponent<SpriteRenderer>().sprite = gAnkh;
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateGateState(myGateState);

		if (inCollider && myGateState == gateState.unlocked && GameManager.Instance.InputController.useItem && myTeleport.enabled && !hasBlockCollider) {
			myTeleport.TeleportPlayer (myTeleport.teleportTarget.transform);
		}

		// If gate is locked, we're in the collider and we press useItem, then proceed to unlock the gate.
		if (inCollider && myGateState == gateState.locked && GameManager.Instance.InputController.useItem) {
			EventManager.TriggerEvent ("Message", MessageManager.getMessageText("key_used"));
			unlockGate (ankhCurrency,gatePrice);

		}


	}

	void unlockGate(PickupAnkh.ankh ankhCurrency, int ankhPrice){
		int myAnkhAmount = getAnkhAmount (ankhCurrency);
		print ("Ay los dineros" + myAnkhAmount);
		if (myAnkhAmount >= ankhPrice) {
			// We unlock door and waste ankh
			if (ankhCurrency == PickupAnkh.ankh.silver) {
				GameManager.Instance.Stats.sAnkh -= ankhPrice;
			} else if (ankhCurrency == PickupAnkh.ankh.gold) {
				GameManager.Instance.Stats.gAnkh -= ankhPrice;
			} 
			myGateState = gateState.unlocked;
			updateGateState(myGateState);
			EventManager.TriggerEvent ("Message", MessageManager.getMessageText("gate_unlocked"));
			myGateAnimator.SetTrigger ("Open");
			myBlockCollider.SetActive (false);
		} else if (myAnkhAmount < ankhPrice) {
			// We dont unlock
			// Maybe notice it
			EventManager.TriggerEvent ("Message", MessageManager.getMessageText("ankh_notEnough"));
		}
	}

	public int getAnkhAmount(PickupAnkh.ankh myAnkhCurrency){
		int returnito = 0;
		if (myAnkhCurrency == PickupAnkh.ankh.silver) {
			returnito = GameManager.Instance.Stats.sAnkh;
		} else if (myAnkhCurrency == PickupAnkh.ankh.gold) {
			returnito = GameManager.Instance.Stats.gAnkh;
		} 
		return returnito;
	}

	void updateGateState(gateState myState){
		if (myState == gateState.locked) {
			myTeleport.enabled = false;
		} else if (myState == gateState.unlocked) {
			myTeleport.enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.transform.tag == "Player") {
			inCollider = true;
		}

	}

	void OnTriggerExit2D(Collider2D target){
		if (target.transform.tag == "Player") {
			inCollider = false;
		}
	}

}
