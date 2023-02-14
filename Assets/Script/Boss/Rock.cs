using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    
    
    void Start()
    {
        Invoke("DestroyThis",3f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyThis();
        }
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

}
