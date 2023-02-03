using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 10.0f;
    public float velocidadRotacion = 200.0f;    
    public float velCorrer;
    //private Animator anim;
    public float x, y;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MoverPlayer();
        Correr();
    }

    private void MoverPlayer()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        //anim.SetFloat("VelX", x);
        //anim.SetFloat("VelY", y);

        
    }
    private void Correr()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            velocidadMovimiento = velCorrer;
            if (y > 0)
            {
                //anim.SetBool("correr", true);
                velCorrer = 20.0f;
            }
            else
            {
                //anim.SetBool("correr", false);
                velocidadMovimiento = 10.0f;
            }
        }
    }
}
