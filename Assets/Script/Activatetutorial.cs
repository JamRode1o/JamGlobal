using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatetutorial : MonoBehaviour
{
    public GameObject Panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Menu"))
        {
            Panel.SetActive(true);
            Pausa();
            Debug.Log("Desplegado");
        }
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
    }
}
