using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public MoverPersonaje MP;
    public EnemyLife EnemyLifeReference;
    public GameObject HitParticle;
    public GameObject DeathParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && MP.isAttacking)
        {
            EnemyLifeReference.TakeDamage(2);
            other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticle,
                new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z),
                other.transform.rotation);

        }
        if (EnemyLifeReference.Health <= 0)
        {
            Instantiate(DeathParticle,
                new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z),
                other.transform.rotation);
        }
    }
}
