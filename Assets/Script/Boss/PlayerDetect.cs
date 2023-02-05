using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField]
    private GameObject Demon;
    // Start is called before the first frame update
    void Start()
    {
        Demon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
            Demon.SetActive(true);
    }
}
