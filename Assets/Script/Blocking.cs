    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{
    //codigo para activar los objetos que bloquean en camino al momento de pelear
    public float tiempo;
    [SerializeField] GameObject Tronco;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("Time");
            //  Tronco.SetActive(true);
        }
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(tiempo);
        Tronco.SetActive(true);
    }
}
