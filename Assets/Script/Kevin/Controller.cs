using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] Animator ani;
    [SerializeField] Slider Stamina;

    [SerializeField] float Speed,run;

    CharacterController Player;

    float x, z, tiempo;
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

        Player.SimpleMove(new Vector3(0, 0, x).normalized * Speed);

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
