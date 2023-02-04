using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{
    //codigo para activar los objetos que bloquean en camino al momento de pelear

    public int tiempo;
    [SerializeField] GameObject Tronco;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Tronco.SetActive(true);
        }
    }

    
}
