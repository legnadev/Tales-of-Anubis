using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager{

	public event System.Action<Player> OnLocalPlayerJoined;

	private GameObject gameObject;


	private static GameManager m_Instance;
	public static GameManager Instance{
		get {
			if (m_Instance == null || GameObject.Find("_gameManager") == null) {
				m_Instance = new GameManager ();
				m_Instance.gameObject = new GameObject ("_gameManager");
				m_Instance.gameObject.AddComponent<InputController> ();
				m_Instance.playerTorch = GameObject.Find ("Torch_Player");
				m_Instance.ringTeleport = GameObject.Find ("TeleportSpawner");
			}

			return m_Instance;
		}
	}

	private InputController m_InputController;
	public InputController InputController{
		get {
			if (m_InputController == null) {
				m_InputController = gameObject.GetComponent<InputController> ();
			}
			return m_InputController;
		}
	}

	private Stats m_Stats;
	public Stats Stats{
		get {
			if (m_Stats == null) {
				m_Stats = GameObject.Find ("Stats").GetComponent<Stats>();
			}
			return m_Stats;
		}
	}



	[SerializeField]
	private Player m_LocalPlayer;
	public Player localPlayer{
		get {
			return m_LocalPlayer;
		}
		set {
			m_LocalPlayer = value;
			if (OnLocalPlayerJoined != null) {
				OnLocalPlayerJoined (m_LocalPlayer);
			}
		}
	}

	[SerializeField]
	private GameObject m_PlayerTorch;
	public GameObject playerTorch{
		get {
			if (m_PlayerTorch == null) {
				m_PlayerTorch = GameObject.Find ("Torch_Player");
			}
			return m_PlayerTorch;
		}
		set {
			m_PlayerTorch = value;
		}
	}

	[SerializeField]
	private GameObject m_RingTeleport;
	public GameObject ringTeleport{
		get {
			if (m_RingTeleport == null) {
				m_RingTeleport = GameObject.Find ("TeleportSpawner");
			}
			return m_RingTeleport;
		}
		set {
			m_RingTeleport = value;
		}
	}

		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restartGameManager(){
		m_Instance = null;
	}
}
