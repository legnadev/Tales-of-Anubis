using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class Scorpion : MonoBehaviour {

	public GameObject VenomBubble;
	public Animator scorpionAnimator;
	public SkeletonAnimator skelAnimator;

	// Skills
	public VenomSpit myVenomSpit;
	public VenomBubble myVenomBubble;

	// Attack stages
	public enum ScorpionState {Free, VenomSpit, Guard, GuardOut, TailAttack};
	public ScorpionState myState;

	// Broken parts stages
	public enum ScorpionLifeState {Full, TailOff, Off, Dead};
	public ScorpionLifeState myLifeState;

	public Transform myTail;
	public GameObject myGuardCollider;

	public Transform currentSpot;
	public List<GameObject> spots = new List<GameObject> ();
	public int pointSelection;

	[SerializeField] int m_scorpionHp = 5;
	public int scorpionHp{
		get {
			if (m_scorpionHp <= 0) {
				Death (gameObject);
			} else if (m_scorpionHp == 20){
				killTail ();
			} else if (m_scorpionHp == 10){
				killPinzas ();
			} else if (m_scorpionHp <= 0){
				killScorpion ();
			}
			return m_scorpionHp;
		}
		set{
			if (m_scorpionHp <= 0) {
				Death(gameObject);
			}
			m_scorpionHp = value;
		}
	}

	[SerializeField] int m_tailhp = 5;
	public int tailHp{
		get {
			if (m_tailhp <= 0) {
				Death (gameObject);
			}
			return m_tailhp;
		}
		set{
			if (m_tailhp <= 0) {
				Death(gameObject);
			}
			m_tailhp = value;
		}
	}

	[SerializeField] int m_pinzahp = 5;
	public int pinzaHp{
		get {
			if (m_pinzahp <= 0) {
				Death (gameObject);
			}
			return m_pinzahp;
		}
		set{
			if (m_pinzahp <= 0) {
				Death(gameObject);
			}
			m_pinzahp = value;
		}
	}

	void Awake(){
		scorpionAnimator = GetComponent<Animator> ();
		skelAnimator = GetComponent<SkeletonAnimator> ();

	}
	// Use this for initialization
	void Start () {
		spots.AddRange (GameObject.FindGameObjectsWithTag ("VenomSpot"));
		myGuardCollider.SetActive (false);

		myState = ScorpionState.Free;

		scorpionAnimator.SetTrigger ("TailAttack");

		InvokeRepeating ("randomAttack", 4, 1);
	}
	
	// Update is called once per frame
	void Update () {

		if (myLifeState == ScorpionLifeState.TailOff){
			skelAnimator.skeleton.SetSkin ("ColaRota");
			skelAnimator.skeleton.SetSlotsToSetupPose();
		} else if (myLifeState == ScorpionLifeState.Off){
			skelAnimator.skeleton.SetSkin ("PinzasRotas");
			skelAnimator.skeleton.SetSlotsToSetupPose();
		}  else if (myLifeState == ScorpionLifeState.Dead){
			skelAnimator.skeleton.SetSkin ("PinzasRotas");
			skelAnimator.skeleton.SetSlotsToSetupPose();
		} else if (myLifeState == ScorpionLifeState.Full){
			skelAnimator.skeleton.SetSkin ("Full");
			skelAnimator.skeleton.SetSlotsToSetupPose();
		}

		/*
		if (myState == ScorpionState.TailAttack){
			scorpionAnimator.SetTrigger ("TailAttack");
		} else if (myState == ScorpionState.VenomSpit){
			scorpionAnimator.SetTrigger ("VenomSpit");
		} else if (myState == ScorpionState.Guard){
			scorpionAnimator.SetTrigger ("Guard");
		} else if (myState == ScorpionState.GuardOut){
			scorpionAnimator.SetTrigger ("GuardOut");
		} else if (myState == ScorpionState.Free){
			scorpionAnimator.SetTrigger ("Free");
		}*/

		
	}

	void OnEnable ()
	{
		//EventManager.StartListening ("BulletSpawned", counterAttack);
	}

	void OnDisable ()
	{
		//EventManager.StopListening ("BulletSpawned", counterAttack);

	}

	void counterAttack(string abc = ""){
		print ("A por la bala");
		GameObject bullet = GameObject.FindGameObjectWithTag ("Bullet");
		//Destroy (bullet);
		GameObject bulletGO = Instantiate (VenomBubble, transform.position, transform.rotation) as GameObject;
		bulletGO.gameObject.GetComponent<VenomBubble> ().target = bullet.transform;
		bulletGO.gameObject.GetComponent<VenomBubble> ().isSpawned = true;

	}

	void randomAttack(){

		var randomChoice = Random.Range (0, 5);
		if (myState == ScorpionState.Free) {

			if (randomChoice == 1) {
				attackTail ();
			} else if (randomChoice == 2 || randomChoice == 4) {
				attackVenom ();
			} else if (randomChoice == 3) {
				attackGuard ();
			}

		}

	}

	void attackTail(){
		myState = ScorpionState.TailAttack;
		scorpionAnimator.SetTrigger ("TailAttack");
		print ("Colaso");
	}

	void attackVenom(){
		if (myLifeState == ScorpionLifeState.Full) {
			myState = ScorpionState.VenomSpit;
			scorpionAnimator.SetTrigger ("VenomSpit");
		}
	}

	void attackGuard(){
		
		myState = ScorpionState.Guard;
		scorpionAnimator.SetTrigger ("Guard");
		myGuardCollider.SetActive (true);
		Invoke ("guardOut", 5f);
		EventManager.TriggerEvent ("Message", MessageManager.getMessageText("guard_stance"));
	}

	void setFreeState(){
		scorpionAnimator.SetTrigger ("Free");
		myState = ScorpionState.Free;
	}

	void guardOut(){
		scorpionAnimator.SetTrigger ("GuardOut");
		myState = ScorpionState.GuardOut;
		myGuardCollider.SetActive (false);
	}

	void spitVenom(){
		// Shoot the venom spitsm
		GameObject bulletGO = Instantiate (VenomBubble, myTail.position, myTail.rotation) as GameObject;

		bulletGO.gameObject.GetComponent<VenomBubble> ().target = spots [Random.Range(0, spots.Count)].GetComponent<Transform> ();
		bulletGO.gameObject.GetComponent<VenomBubble> ().isSpawned = true;
	}

	void killTail(){
		myLifeState = ScorpionLifeState.TailOff;
		EventManager.TriggerEvent ("Message", MessageManager.getMessageText("killed_tail"));
	}

	void killPinzas(){
		myLifeState = ScorpionLifeState.Off;
		EventManager.TriggerEvent ("Message", MessageManager.getMessageText("killed_pinzas"));
	}

	void killScorpion(){
		myLifeState = ScorpionLifeState.Dead;
		EventManager.TriggerEvent ("Message", MessageManager.getMessageText("killed_boss"));
	}



	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
		}
	}

	public void applyDmg(int quantity){
		scorpionHp -= quantity;
	}

	void Death(GameObject go){
		EventManager.TriggerEvent ("Win", "aa");
		Destroy(go);
	}
}
