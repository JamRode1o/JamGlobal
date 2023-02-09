using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gobblin : MonoBehaviour
{
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        agent.SetDestination(target.position);
        transform.LookAt(target);
    }

}
