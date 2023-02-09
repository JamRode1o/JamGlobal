using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

    // Logica de si entra en el rango lo vea, persiga y toque
    public float dectectionRatio;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    public Transform jugador;
    public float caminar;
    public float correr;
    //public Animator Anim;
    public Transform[] PuntosPatrulla;
    //

    // Se usa con los metodos MoveToTarget y GetNextTarget
    public float patrolSpeed = 0f;
    public float changeTargetDistance = 0.1f;
    int currentTarget = 0;
    //

    // Start is called before the first frame update
    void Start()
    {
        //Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        alerta(); 

        if (MoveToTarget())
        {            
            currentTarget = GetNextTarget();           
        }       
    }

    // Logica de si entra en el rango lo vea, persiga y toque  
    public void alerta()
    {
        estarAlerta = Physics.CheckSphere(transform.position, dectectionRatio, capaDelJugador);

        if (estarAlerta == true)
        {
            //Anim.SetBool("correr", true);
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, correr * Time.deltaTime);
        }
        else
        {
            //Anim.SetBool("correr", false);
            
        }
    }
    //

    private void OnDrawGizmos()
      {
          Gizmos.color = Color.magenta;
          Gizmos.DrawWireSphere(transform.position, dectectionRatio);
      }
    
    private bool MoveToTarget()
    {
        Vector3 distanceVector = PuntosPatrulla[currentTarget].position - transform.position;
        if (distanceVector.magnitude < changeTargetDistance)
        {
            transform.LookAt(PuntosPatrulla[currentTarget]);            
            //Anim.SetBool("caminar", true);            
            return true;
        }

        Vector3 velocityVector = distanceVector.normalized;
        transform.position += velocityVector * patrolSpeed * Time.deltaTime;        
        //Anim.SetBool("caminar", false);
        return false;
    }

    private int GetNextTarget()
    {
        currentTarget++;
        new WaitForSeconds(3f);
        if (currentTarget >= PuntosPatrulla.Length)
        {
            currentTarget = 0;
        }
        return currentTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Recolectable.Arepas--;
            
        }
    }
}
