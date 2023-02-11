using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{

    public HealthEnemyBarBehavior Icon;
    public float Health = 10;

    public float maxHealth;


    private void Start()
    {
        Health = maxHealth;
        Icon.UnsetImage();
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
        float HealthPercentage = Health / maxHealth;
        if (HealthPercentage <= Icon.healthTreshold)
        {
            if (!Icon.isDamaged)
            {
                Icon.SetImage();
                Icon.isDamaged = true;
            }
        }
        else
        {
            if (Icon.isDamaged)
            {
                Icon.UnsetImage();
                Icon.isDamaged = false;
            }
        }

    }
    
}
