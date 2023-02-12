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
    public float velCorrer;

    [SerializeField] GameObject BloqueoI, arma;
    [SerializeField] Slider BloqueoS;

    [SerializeField] float TAtaque, Spam;

    Rigidbody rb;

    bool Movent;
    float time = 6;

    Vector3 vely;

    /// <summary>
    /// //////////////////////
    /// 
    /// </summary>

    [SerializeField] Animator ani;
    [SerializeField] Slider Stamina;
    [SerializeField] Transform cam;
    [SerializeField] float Speed, Run, giro;

    CharacterController Player;
    Vector3 direccion;

    float x, z, tiempo, rotacion, angulo;
    bool Correr = false, cansado = false;
    private void Start()
    {
        Player = GetComponent<CharacterController>();
        // rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {


        time += Time.deltaTime;

        Movimiento();

        Bloqueo();

        Ataque();

        BloqueoS.value += Time.deltaTime * 0.2f;

    }

    void Movimiento()
    {
        x = Input.GetAxis("Vertical");
        z = Input.GetAxis("Horizontal");
        direccion = new Vector3(z, 0, x).normalized;
        // rotacion = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg ;
        rotacion = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        if (direccion.magnitude > 0)
        {

            angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotacion, ref giro, 0);
            transform.rotation = Quaternion.Euler(0, angulo, 0);

            Vector3 MovDir = Quaternion.Euler(0, rotacion, 0) * Vector3.forward;
            //Player.SimpleMove(direccion * Speed);
            Player.SimpleMove(MovDir.normalized * Speed);

        }
        if ((x != 0 || z != 0) && Correr == false)
            ani.SetBool("caminar", true);
        else
            ani.SetBool("caminar", false);

        if (Input.GetKey(KeyCode.Space) && Stamina.value > 0)
        {
            Correr = true;
            Player.SimpleMove(new Vector3(0, 0, x).normalized * Run);
            ani.SetBool("Run", true);
            Stamina.value -= Time.deltaTime;
        }
        else
        {
            Correr = false;
            ani.SetBool("Run", false);
        }
    }

    //private void MoverPlayer()
    //{
    //    x = Input.GetAxis("Horizontal");
    //    y = Input.GetAxis("Vertical");

    //    transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
    //    //transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento); 

    //    // vely = Vector3.zero;

    //    if(x != 0 || y!=0)
    //    {
    //        // rb.velocity = new Vector3(0, 0, y * Time.deltaTime * velocidadMovimiento);
    //        direccion = (transform.forward * y).normalized;
    //        vely = direccion * velocidadMovimiento;
    //        if(Input.GetKey(KeyCode.Space))
    //            anim.SetBool("Caminar", false);
    //        else
    //            anim.SetBool("Caminar", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("Caminar", false);
    //    }
 

    //   // vely.y = rb.velocity.y;
    //    rb.velocity = vely;
    //    anim.SetFloat("VelX", x);
    //    anim.SetFloat("VelY", y);

        
    //}

    int rando()
    {
        int tem = Random.Range(0, sonidoAtk.Length);
        return tem;
    }
 

    void Bloqueo()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Movent = false;
            //BloqueoI.gameObject.SetActive(true);
        }
        else
        {
            Movent = true;
           // BloqueoI.gameObject.SetActive(false);
          //  BloqueoS.value += Time.deltaTime;
        }
    }

    void Ataque()
    {
        TAtaque += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
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

}
