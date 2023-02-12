using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] Animator ani;
    [SerializeField] Slider Stamina;
    [SerializeField] Transform cam;
    [SerializeField] float Speed,run,giro;

    CharacterController Player;
    Vector3 direccion;

    float x, z, tiempo,rotacion,angulo;
    bool Correr = false, cansado=false;
    
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    

    void Update()
    {
        Movimiento();

        tiempo += Time.deltaTime;

        if(Correr == false && tiempo >= 5 && cansado == false)
            Stamina.value += Time.deltaTime;
        //else if(cansado == true && ) // hacer que no se llene la barra de correr 

    }


    // permite al jugador moverse en el eje de x, activando la animacion de caminar o de correr dependiendo del input 
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
            Vector3 MovDir = Quaternion.Euler(0, rotacion, 0)* Vector3.forward;
            //Player.SimpleMove(direccion * Speed);
            Player.SimpleMove(MovDir.normalized * Speed);
        }
        if ((x != 0 || z != 0) && Correr == false)
            ani.SetBool("Caminar", true);
        else
            ani.SetBool("Caminar", false);

        if (Input.GetKey(KeyCode.Space) && Stamina.value > 0)
        {
            Correr = true;
            Player.SimpleMove(new Vector3(0, 0, x).normalized * run);
            ani.SetBool("Correr", true);
            Stamina.value -= Time.deltaTime;
        }
        else
        {
            Correr = false;
            ani.SetBool("Correr", false);
        }
    }
}