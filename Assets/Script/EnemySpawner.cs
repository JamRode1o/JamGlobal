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
    private float repeatRate = 5.0f;
    //public Transform target;

    void Start()
    {
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("EnemiSpawner", 0.5f, repeatRate);
            Destroy(gameObject, 5);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        } 
    }

    void EnemiSpawner()
    {
        Instantiate(enemy, location.position, location.rotation);
    }
}
