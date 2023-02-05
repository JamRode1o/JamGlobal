using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{

    public Image enemyLife;

    static public float nowLife;

    public float maxLife;

    void Update()
    {
        enemyLife.fillAmount = nowLife / maxLife;

        if(nowLife <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

 

}
