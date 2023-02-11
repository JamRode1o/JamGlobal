using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public MoverPersonaje MP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && MP.isAttacking)
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}
