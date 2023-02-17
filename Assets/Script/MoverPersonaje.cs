using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour
{
    public static bool run = false;

    public AudioSource son;
    public AudioClip[] sonidoAtk;


    [SerializeField] GameObject BloqueoI, arma;

    [SerializeField] float TAtaque, Spam;


    bool Movent;
    float time = 6;

    Vector3 vely;
    public bool isAttacking = false;
    [SerializeField] GameObject atk;

    /// <summary>
    /// //////////////////////
    /// 
    /// </summary>

    [SerializeField] Animator ani;
    [SerializeField] Slider Stamina;
    [SerializeField] Transform cam;
    [SerializeField] float Speed, Run, giro;

    CharacterController Player;
    Vector3 direccion,MovDir;

    float x, z, tiempo, rotacion, angulo;
    bool Correr , cansado = false;
    private void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    private void Update()
    {


        time += Time.deltaTime;
        Movimiento();
       // tiempo += Time.deltaTime;

       
        if (Stamina.value <= 0)
        {
            cansado = true;
            tiempo += Time.deltaTime;

            if (tiempo >= 3)
            {
                cansado = false;
                tiempo = 0;
            }
        }
         if (Correr == false && cansado == false)
            Stamina.value += Time.deltaTime;
        Bloqueo();

        Ataque();
    }

    void Movimiento()
    {
        x = Input.GetAxis("Vertical");
        z = Input.GetAxis("Horizontal");
        direccion = new Vector3(z, 0, x).normalized;

        rotacion = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        if (direccion.magnitude > 0)
        {

            angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotacion, ref giro, 0);
            transform.rotation = Quaternion.Euler(0, angulo, 0);

            MovDir = Quaternion.Euler(0, rotacion, 0) * Vector3.forward;

            Player.SimpleMove(MovDir.normalized * Speed);

            if (Input.GetKey(KeyCode.Space) && cansado == false)
            {
                Correr = true;
                Stamina.value -= Time.deltaTime;
                Player.SimpleMove(MovDir.normalized * Speed);
                ani.SetBool("Correr", true);

            }
            else
            {
                Correr = false;
                ani.SetBool("Correr", false);
            }
        }
        if ((x != 0 || z != 0) && Correr == false)
            ani.SetBool("Caminar", true);
        else
            ani.SetBool("Caminar", false);

        
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
            //atk.SetActive(true);
            isAttacking = true;
            StartCoroutine(ResetAttackingBool());
            if (TAtaque >= Spam)
            {
                TAtaque = 0;
            }
            ani.SetBool("Ataque", true);
            if(time > 5)
            {
                son.PlayOneShot(sonidoAtk[rando()]);
                time = 0;
            }
        }
        else
        {
            ani.SetBool("Ataque", false);
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
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
        arma.SetActive(false);
    }

}
