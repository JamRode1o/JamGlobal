using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class GoblinDistance : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject bullet;
    public float speed = 1200f;
    public GameObject pointSpawn;
 



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        pointSpawn.transform.LookAt(target);
        transform.LookAt(target);
        float distancePlayer = Vector3.Distance(transform.position, target.position);

        

        if (distancePlayer <= 5f)
        {
            StopPosition();
        }
        else
        {

            GoToPlayer();
        }
    }

    void StopPosition()
    {
        anim.SetBool("Shoot", true);
        agent.isStopped = true;
    }

    void GoToPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    void ShootPlayer()
    {
        agent.isStopped = true;
        GameObject rock = Instantiate(bullet, pointSpawn.transform.position, pointSpawn.transform.rotation);
        Rigidbody rb = rock.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        anim.SetBool("Shoot", false);
        GoToPlayer();
    }

}
