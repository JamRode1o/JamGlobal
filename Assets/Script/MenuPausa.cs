using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //[SerializeField] private GameObject BotonPausa;
    [SerializeField] private GameObject Menupausa;
    private bool juegoPausado = false;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{}
            // if (juegoPausado)
            // {
            //     Continuar();
            // }
            // else
            // {
            //     Pausa();
            // }
            if (Input.GetKeyUp(KeyCode.P))
            {
                Pausa();
                Time.timeScale = 0f;
            }
            
        
    }

    public void Pausa()
    {
        //BotonPausa.SetActive(false);
        Menupausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        //BotonPausa.SetActive(false);
        //Menupausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continuar()
    {
        Time.timeScale = 1f;
        //BotonPausa.SetActive(true);
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
