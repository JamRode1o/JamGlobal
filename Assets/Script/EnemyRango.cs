using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRango : MonoBehaviour
{
    public float dectectionRatio;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    [SerializeField] GameObject Piedra;
    [SerializeField] Transform Salida;
    GameObject tem;

    float time;
    public Transform jugador;
    public float correr, fuerza;
    void Start()
    {
        
    }

    
    void Update()
    {
       Detector();
        time += Time.deltaTime;
    }

    void Detector()
    {
        estarAlerta = Physics.CheckSphere(transform.position, dectectionRatio, capaDelJugador);
        if (estarAlerta == true)
        {
            //Anim.SetBool("correr", true);
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            if (time > 1.5f)
            {

                tem= Instantiate(Piedra, Salida.position, Quaternion.identity);
                tem.GetComponent<Rigidbody>().AddForce(transform.forward* fuerza);

                time = 0;
            }
           // transform.position = vector3.movetowards(transform.position, posjugador, correr * time.deltatime);
        }
    }

}
