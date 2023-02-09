using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Animator ani;

    [SerializeField] float Speed,run;

    CharacterController Player;

    float x, z;
    bool Correr = false;
    
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    
    void Update()
    {

        x = Input.GetAxis("Vertical");
        z = Input.GetAxis("Horizontal");

        Player.SimpleMove(new Vector3(0,0,x).normalized * Speed);

        if((x !=0 || z !=0) && Correr==false)
            ani.SetBool("Caminar",true);
        else
            ani.SetBool("Caminar", false);

        if (Input.GetKey(KeyCode.Space))
        {
            Correr = true;
            Player.SimpleMove(new Vector3(0, 0, x).normalized * run);
            ani.SetBool("Correr", true);
        }
        else
        {
            Correr = false;
            ani.SetBool("Correr", false);
        }
            


    }
}
