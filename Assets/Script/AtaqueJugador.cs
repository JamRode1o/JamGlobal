using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{

    [SerializeField] float fuerza;
    public static bool BerriondoMode;
    float time;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Recolectable.Guaro -= Time.deltaTime;
            BerriondoMode = true;
        }
        else
        {
            BerriondoMode = false;
        }

        time = Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyLife.nowLife -= 20;

            
            if(BerriondoMode)
                EnemyLife.nowLife -= 35;

            Vector3 dir = (other.transform.position - transform.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(dir * fuerza, ForceMode.Impulse);
            
            //other.GetComponent<EnemyLogic>().enabled = false;
        }
    }

}
