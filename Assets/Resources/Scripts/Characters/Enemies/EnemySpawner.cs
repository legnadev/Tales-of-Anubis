using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	// Enemy Asset
	public GameObject enemyGO;
	public GameObject spawnerGO;

	public int quantity;
    public int omg;

	public bool spawnByCollider;
    public bool collided;
	// Spawn by Time
	public bool spawnByTime;
	public float spawnerTime;

	void Awake(){
		spawnerGO = this.gameObject.transform.GetChild (0).gameObject;
	}

	// Use this for initialization
	void Start () {
        if (spawnByTime)
        {
            InvokeRepeating("spawnEnemy", 5, spawnerTime);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnByCollider & collided)
        {
            spawnMultipleEnemies(quantity);
            collided = false;
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
            collided = true;
		}

	}

	void spawnEnemy(){
		Instantiate(enemyGO, spawnerGO.transform.position, Quaternion.identity);
	}

	void spawnMultipleEnemies(int quantity){
		while (omg < quantity) {
			Instantiate(enemyGO, spawnerGO.transform.position, Quaternion.identity);
			omg += 1;
		}
	}
}
