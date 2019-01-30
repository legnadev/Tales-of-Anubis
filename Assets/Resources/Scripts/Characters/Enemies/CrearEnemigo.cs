using UnityEngine;
using System.Collections;

public class CrearEnemigo : MonoBehaviour {

    public GameObject prefab;
   
    public float timeCreateEnemy = 2f;

    public float limitX = 6;
    public float posInicialY = 2f;
    public float posInicialZ = 0f;

    void Start()
    {
        InvokeRepeating("CreateEnemy", timeCreateEnemy, timeCreateEnemy);
    }

    // Instantiate the prefab somewhere between -10.0 and 10.0 on the z plane 
    void CreateEnemy()
    {
        Vector3 position = new Vector3(Random.Range(-limitX, limitX), posInicialY, posInicialZ);
        Instantiate(prefab, position, Quaternion.identity);
    }
}
