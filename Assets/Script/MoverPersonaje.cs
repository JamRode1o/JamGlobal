using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 10.0f;
    public float velocidadRotacion = 200.0f;    
    public float velCorrer;
    [SerializeField] Camera camara;
    Vector3 Camz, Camx;
    //private Animator anim;
    public float x, y;
    Rigidbody rb;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
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
        //transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        // rb.velocity = new Vector3(0, 0, y * Time.deltaTime * velocidadMovimiento);

        Vector3 vely = Vector3.zero;

        if(x != 0 || y!=0)
        {
            Vector3 direcion = (transform.forward * y).normalized;
            vely = direcion * velocidadMovimiento;
        }
 

        vely.y = rb.velocity.y;
        rb.velocity = vely;
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
