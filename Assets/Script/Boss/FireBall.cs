using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    public float speed, f;
    float time;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    float Rando()
    {
        float tem = Random.Range(3f, 5f);
        return tem;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        time += Time.deltaTime;
        if (time >= Rando())
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        //print("Colisione");
        if(other.tag == "Player")
            Destroy(gameObject);
    }
}
