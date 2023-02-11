using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] int Tamaño;
    [SerializeField] GameObject[] Pool;
    [SerializeField] GameObject Objeto;
    [SerializeField] Transform pos;
    // Start is called before the first frame update
    GameObject tem;
    void Start()
    {
        Pool = new GameObject[Tamaño + 1];
        for (int i = 0; i < Tamaño; i++)
        {
            tem = Instantiate(Objeto);
            tem.SetActive(false);
            Pool[i] = tem;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
            Spawn();

    }
    public void Spawn()
    {
        Pool[0].transform.position = pos.position;
        Pool[0].transform.rotation = pos.rotation;
        Pool[0].SetActive(true);
        Pool[Tamaño] = Pool[0];

        for (int i = 0; i < Tamaño; i++)
        {
            Pool[i] = Pool[i + 1];

        }
    }
}
