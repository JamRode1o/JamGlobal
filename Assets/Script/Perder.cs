using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Perder : MonoBehaviour
{
    //public GameObject perder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //perder.SetActive(true);
            //Pausa();
            Recolectable.Arepas--;
            Debug.Log("colisiono");
        }
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
    }
}
