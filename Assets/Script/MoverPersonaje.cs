using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 10.0f;
    public float velocidadRotacion = 200.0f;    
    public float velCorrer;
    [SerializeField] Slider BloqueoS;
    [SerializeField] float TAtaque,Spam;
    //private Animator anim;
    public float x, y;
    Rigidbody rb;
    bool Movent;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // hacer le modo berriondo 
        if(Movent)
            MoverPlayer();

        Bloqueo();

        Ataque();
        
        Correr();
        BloqueoS.value += Time.deltaTime;
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

        // organizar la velocidad y las cantidad del uso del correr
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

    void Bloqueo()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Movent = false;
            BloqueoS.gameObject.SetActive(true);

            // realizar el bloqueo de manera visual y limitados a 4, que se regeneren con el tiempo
        }
        else
        {
            Movent = true;
            BloqueoS.gameObject.SetActive(false);
          //  BloqueoS.value += Time.deltaTime;
        }
    }

    void Ataque()
    {
        TAtaque += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if(TAtaque >= Spam)
            {
            Debug.Log("Ataco");// poder realiar el daño cuando golpe al enemigo
                TAtaque = 0;
            }

        }
    }

}
