using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{


    public AudioSource sonidoGame;
    float time;
    bool parar = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parar==false)
        {
         time += Time.deltaTime;
           // parar = true;
        }

        if (time > 7)
        {
            parar = true;
            sonidoGame.Play();
            time = 0;
        }
    }
}
