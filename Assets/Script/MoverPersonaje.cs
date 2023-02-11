using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour
{
    public static bool run = false;

    public Slider stamina;
    public Animator anim;
    public AudioSource son;
    public AudioClip[] sonidoAtk;

    public float velocidadMovimiento = 7;
    public float velocidadRotacion = 200.0f;
    public float velCorrer, tiempo;

    [SerializeField] GameObject BloqueoI, arma;
    [SerializeField] Slider BloqueoS;

    [SerializeField] float TAtaque, Spam;

    Rigidbody rb; 

    float x, y;
    bool Movent;
    float time = 6;

    Vector3 vely, direccion;

    public bool isAttacking = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // hacer le modo berriondo 
        // que corre pero no se consume stamina y que pega mas duro
        if (Movent)
        {
            MoverPlayer();
            //if(run==true)
            //    if(stamina.value > 0)
                    Correr();

        }
        time += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if(stamina.value > 0)
            {
             run = true;
            }
            //else
            //{
            //    run = false; hacer que el boleano solo sea uno de los 2 
            //}
        }
            
        Bloqueo();

        Ataque();
        
             BloqueoS.value += Time.deltaTime * 0.2f;
        
    }

    private void MoverPlayer()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        //transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento); 

        // vely = Vector3.zero;

        if(x != 0 || y!=0)
        {
            // rb.velocity = new Vector3(0, 0, y * Time.deltaTime * velocidadMovimiento);
            direccion = (transform.forward * y).normalized;
            vely = direccion * velocidadMovimiento;
            if(Input.GetKey(KeyCode.Space))
                anim.SetBool("Caminar", false);
            else
                anim.SetBool("Caminar", true);
        }
        else
        {
            anim.SetBool("Caminar", false);
        }
 

       // vely.y = rb.velocity.y;
        rb.velocity = vely;
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        
    }

    int rando()
    {
        int tem = Random.Range(0, sonidoAtk.Length);
        return tem;
    }
    private void Correr()
    {

        // organizar la velocidad y las cantidad del uso del correr
        if (Input.GetKey(KeyCode.Space))
        {
            
            //anim.SetBool("Run", true);
            stamina.value -= Time.deltaTime;
            //if(x != 0 || y != 0)
            //{
            //    //    Debug.Log("correr abajo");
            //    //    vely = direccion * velCorrer;

            //    //    vely.y = rb.velocity.y;
            //    //    rb.velocity = vely;
            //    //anim.SetTrigger("Correr");
            //}

            velocidadMovimiento = velCorrer;
                if (y > 0)
                {
                    
                    anim.SetBool("Run", true);
                    velCorrer = 10;
                }
                else
                {
                    anim.SetBool("Run", false);
                    
                    velocidadMovimiento=7;
                }
            
            //else
            //{
                //anim.SetBool("Run", false);
            //}

            
        }
        else
        {
            vely = direccion * velocidadMovimiento;
            vely.y = rb.velocity.y;
            rb.velocity = vely;
            run = false;
        }
    }

    void Bloqueo()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Movent = false;
            BloqueoI.gameObject.SetActive(true);
        }
        else
        {
            Movent = true;
            BloqueoI.gameObject.SetActive(false);
          //  BloqueoS.value += Time.deltaTime;
        }
    }

    void Ataque()
    {
        TAtaque += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            arma.SetActive(true);
            StartCoroutine("Timer");
            if(TAtaque >= Spam)
            {
                TAtaque = 0;
            }
            anim.SetBool("Atk", true);
            if(time > 5)
            {
                son.PlayOneShot(sonidoAtk[rando()]);
                time = 0;
            }
        }
        else
        {
            anim.SetBool("Atk", false);
        }
    }

    IEnumerator Timer()
    {
        StartCoroutine(ResetAttackingBool());
        yield return new WaitForSeconds(tiempo);
        arma.SetActive(false);
    }

    IEnumerator ResetAttackingBool()
    {
        yield return new WaitForSeconds(2.0f);
        isAttacking = false;
    }

}
