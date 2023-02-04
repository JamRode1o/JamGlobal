using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{

    public Image enemyLife;

    public float nowLife;

    public float maxLife;

    void Update()
    {
        enemyLife.fillAmount = nowLife / maxLife;

        if(nowLife <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            nowLife -= 20;
        }
    }

}
