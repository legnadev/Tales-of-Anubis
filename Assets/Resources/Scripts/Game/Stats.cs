using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

	[SerializeField] int playerHP;

	public GameObject myPlayer;
	public GameObject stats;
	public GameObject stat_HP;
	GameObject lifebar;
	public GameObject heart;
	private List<GameObject> hearts = new List<GameObject>();

	public Text Text_gAnkh;
	public Text Text_sAnkh;

	// Pickups
	[SerializeField] int m_gAnkh = 0;
	public int gAnkh{
		get {
			return m_gAnkh;
		}
		set {
			m_gAnkh = value;
			updateAnkh (1, m_gAnkh);
		}
	}

	[SerializeField] int m_sAnkh = 0;
	public int sAnkh{
		get {
			return m_sAnkh;
		}
		set {
			m_sAnkh = value;
			updateAnkh (2, m_sAnkh);
		}
	}

	void Awake(){
		stats = GameObject.Find ("Stats");
	}

	// Use this for initialization
	void Start () {
		//heart = Resources.Load ("Prefabs/HeartContainer") as GameObject;
		Text_gAnkh = GameObject.Find ("Text_gAnkh").GetComponent<Text>();
		Text_sAnkh = GameObject.Find ("Text_sAnkh").GetComponent<Text>();
		updateAnkh (1, 0);
		updateAnkh (2, 0);
		lifebar = GameObject.Find ("Lifebar");
		if (lifebar) {
			updateHp (GameManager.Instance.localPlayer.totalLives, GameManager.Instance.localPlayer.hp);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (hearts.Count == GameManager.Instance.localPlayer.maxLives) {
			FreezeHartsMaxHP (true, hearts);
		}
	}

	public void updateHp(int totalLives, int currentHp){
		
		foreach (GameObject heart in hearts){
			Destroy(heart);
		}
		hearts.Clear();
		for (int i = 0; i < totalLives; i++){
			GameObject hearto = Instantiate (heart, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			hearto.transform.SetParent (lifebar.transform, false);
			hearts.Add (hearto);
		}
	}

	public void FreezeHartsMaxHP(bool status, List<GameObject> corazones){
		if (status) { // Stone hearts as max HP has been  reached
			foreach (GameObject heart in corazones) {
				heart.GetComponent<Image> ().color = new Color (0.5F, 0.5F, 0.5F);
			}
		}
		else if (!status) { // Back to normal hearts
			foreach (GameObject heart in corazones) {
				heart.GetComponent<Image> ().color = new Color (0.5F, 0.5F, 0.5F);
			}
		}

	}

	public void updateAnkh(int ankhType, int ankhAmount){
		// ankh 1 = gold, ankh 2 = silver;
		if (ankhType == 1) {
			Text_gAnkh.text = ankhAmount.ToString();
		} else if (ankhType == 2) {
			Text_sAnkh.text = ankhAmount.ToString();
		}

	}
}
