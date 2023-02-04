using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{

    [SerializeField] float fuerza;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyLife.nowLife -= 20;
            Debug.Log("ME Dio");
            Vector3 dir = (other.transform.position - transform.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(dir * fuerza, ForceMode.Impulse);
            other.GetComponent<EnemyLogic>().enabled = false;
        }
    }
}
