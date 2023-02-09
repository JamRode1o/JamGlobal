using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] GameObject[] Pool; 

    GameObject Rando()
    {
        int tempo = Random.Range(0, Pool.Length);
        return Pool[tempo];

       
    }


    public void Spawnear()
    {
        Instantiate(Rando(), transform.position, Quaternion.identity);
    }
}
