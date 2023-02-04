using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public Transform location;
    public float spawnTime;
    public float randomSpawnTime;
    private float spawnerTimer;
    //public Transform target;

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
       // ResetSpawnerTime();
    }

    // Update is called once per frame
    void Update()
    {
        //spawnerTimer -= Time.deltaTime;
        //if (spawnerTimer <= 0.0f)
        {
            //Instantiate(enemy, location.position, Quaternion.identity);
           // ResetSpawnerTime();
        }

    }

    void ResetSpawnerTime()
    {
        spawnerTimer = (float)(spawnTime + Random.Range(0, randomSpawnTime * 100) / 100.0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(enemy, location.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
            throw new NotImplementedException();
    }
}
