using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{

    static public float Health = 10;

    public float maxHealth;


    private void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {

    }

 

}
