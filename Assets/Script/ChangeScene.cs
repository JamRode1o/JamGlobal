using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{  
    public void CargarEscena(string NombreEscena)
    {
        SceneManager.LoadScene(NombreEscena);    
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

}