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
        if (other.tag == "Enemy" )//&& MP.isAttacking)
        {

            if (Recolectable.BerriondoMode == true)
            {
                other.GetComponent<EnemyLife>().TakeDamage(4);// EnemyLifeReference.TakeDamage(2);
                other.GetComponent<Animator>().SetTrigger("Hit");

                if (other.GetComponent<EnemyLife>().Health >= 1)
                {
                    GameObject tem = Instantiate(HitParticle,
                        new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z),
                        other.transform.rotation);
                    Destroy(tem, 1.3f);
                }
            }
            else
            {
                other.GetComponent<EnemyLife>().TakeDamage(2);// EnemyLifeReference.TakeDamage(2);
                other.GetComponent<Animator>().SetTrigger("Hit");

                if (other.GetComponent<EnemyLife>().Health >= 1)
                {
                    GameObject tem = Instantiate(HitParticle,
                        new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z),
                        other.transform.rotation);
                    Destroy(tem, 1.3f);
                }
            }


        }
        if (other.GetComponent<EnemyLife>().Health <= 0)
        {
           GameObject tem = Instantiate(DeathParticle,
                new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z),
                other.transform.rotation);
            Destroy(tem, 1.3f);
        }
    }

}
