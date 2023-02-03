using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject BotonPausa;
    [SerializeField] private GameObject Menupausa;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        BotonPausa.SetActive(false);
        Menupausa.SetActive(true);
    }    

    public void Continuar()
    {
        Time.timeScale = 1f;
        BotonPausa.SetActive(true);
        Menupausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrado");
        Application.Quit();
    }
}
