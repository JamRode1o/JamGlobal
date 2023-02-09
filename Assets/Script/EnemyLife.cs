using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{

    public Slider enemyLife;

    static public float nowLife  ;

    public float maxLife;


    private void Start()
    {
        nowLife = maxLife;
    }
    void Update()
    {
        enemyLife.value = nowLife; // maxLife;

        if(nowLife <= 0)
        {
           // this.gameObject.SetActive(false);
        }
    }

 

}
