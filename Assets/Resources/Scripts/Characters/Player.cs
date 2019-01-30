using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets._2D;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public GameObject anubisPlayer;
	public Animator anubisAnimator;

	public PlatformerCharacter2D unity2DController;
	float originalSpeed;

	private bool damaged;
	private float timeImmune = 2.0f;
	private float timeToBeDamaged;

	public float maxSpeed = 200f;
	public int maxLives;

	[SerializeField] bool m_IsPlatform;
	public bool isPlatform{
		get {
			return m_IsPlatform;
		}
		set{
			if (m_IsPlatform) {
				// Setspeed to LOWER
			} else if (!m_IsPlatform) {
				// Setspeed to HIGHER
			}
			m_IsPlatform = value;
		}
	}

	[SerializeField] int m_totalLives = 5;
	public int totalLives{
		get {
			if (m_totalLives <= 0) {
				FinalDeath ();
			}
			return m_totalLives;
		}
		set{
			m_totalLives = value;
			if (m_totalLives <= 0) {
				FinalDeath ();
			}
			GameManager.Instance.Stats.updateHp (totalLives, hp);
		}
	}

	[SerializeField] int m_hp = 1;
	public int hp{
		get {
			return m_hp;
		}
		set{
			m_hp = value;
			if (m_hp <= 0) {
				totalLives -= 1;
				m_hp = 1;
			}
		}
	}

	[SerializeField] int m_ultCharge = 20;
	public int ultCharge{
		get {
			return m_ultCharge;
		}
	}

	[SerializeField] private GameObject previousCheckpoint;
	[SerializeField] private GameObject m_currentCheckpoint;
	public GameObject currentCheckpoint{
		get {
			if (m_currentCheckpoint == null) {
			}
			return m_currentCheckpoint;
		}
		set{
			m_currentCheckpoint = value;
		}
	}

	//[SerializeField] AudioController XXXX;
	private Animator m_anim;
	public Animator anim{
		get {
			if (m_anim == null){
				m_anim = GetComponent<Animator> ();
			}
			return m_anim;
		}
	}

	private Rigidbody2D m_rb2d;
	public Rigidbody2D rb2d{
		get {
			if (m_rb2d == null){
				m_rb2d = GetComponent<Rigidbody2D> ();
			}
			return m_rb2d;
		}
	}
		
	InputController playerInput;

	void Awake(){
		GameManager.Instance.localPlayer = this;
		playerInput = GameManager.Instance.InputController;
		anubisPlayer = this.transform.Find ("Anubis").gameObject;
		anubisAnimator = anubisPlayer.GetComponent<Animator> ();
		unity2DController = this.GetComponent<PlatformerCharacter2D> ();
		originalSpeed = unity2DController.m_MaxSpeed;
	}

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate(){
		if(rb2d.velocity.magnitude > maxSpeed){
			rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
		}
	}

	// Update is called once per frame
	void Update () {
		timeToBeDamaged -= Time.deltaTime;
		if (timeToBeDamaged <= 0) {
			damaged = false;
		}
	}

	public void ApplyDamage(int dmg){
		if (damaged) {
			return;
		}
		print ("dmg applied");
		totalLives -= dmg;
		damaged = true;
		Respawn ();
		timeToBeDamaged = timeImmune;
	}

	public void AddLive(int amount){
		if (totalLives < maxLives) {
			totalLives += amount;
		}
	}

	public void DeathRespawn(){
		ApplyDamage (1);
		Respawn ();
	}

	public void FinalDeath(){
		EventManager.TriggerEvent ("FinalDeath", "aa");
		Destroy (gameObject);
	}
		
	public void Respawn(){
		transform.parent = null;
		rb2d.velocity = Vector3.zero;
		previousCheckpoint = currentCheckpoint;
		transform.position = currentCheckpoint.transform.position;

	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Ground") {
			rb2d.velocity = Vector3.zero;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
			isPlatform = true;
			unity2DController.m_MaxSpeed = originalSpeed * 3;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
			isPlatform = false;
			unity2DController.m_MaxSpeed = originalSpeed;
		}
	}
		
}
