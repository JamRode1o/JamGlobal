using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health instance;

    public int maxHealth;
    public int playerHealth;

    public event Action DamageTaken;
    public event Action HealthUpgraded;


    public int Jealth
    {
        get
        {
            return playerHealth;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    private void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (playerHealth <= 0)
        {
            return;
        }
        playerHealth -= 1;
        if (DamageTaken != null)
        {
            DamageTaken();
        }
    }

    public void Heal()
    {
        if (playerHealth >= maxHealth)
        {
            return;
        }
        playerHealth += 1;
        if (DamageTaken != null)
        {
            DamageTaken();
        }
        
    }

    public void UpgradeHealth()
    {
        maxHealth++;
        playerHealth = maxHealth;
        if (HealthUpgraded != null)
        {
            HealthUpgraded();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            TakeDamage();
        }
        if (other.tag == "Arepa")
        {
            Heal();
        }
        if (other.tag == "ArepaUp")
        {
            UpgradeHealth();
        }

    }

}

