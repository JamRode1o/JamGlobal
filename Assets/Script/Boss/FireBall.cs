using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    public float speed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {

        print("Colisione");
        if(other.tag == "Player")
            Destroy(gameObject);
    }
}
