    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Blocking : MonoBehaviour
    {
        //codigo para activar los objetos que bloquean en camino al momento de pelear
        public GameObject Tronco;
        public Transform location;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                InvokeRepeating("SpawnBlock", 0.5f, 0);
                Debug.Log("here");
                Destroy(gameObject, 5);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            
        }
        void SpawnBlock()
        {
            Instantiate(Tronco, location.position, location.rotation);
        }
    }
