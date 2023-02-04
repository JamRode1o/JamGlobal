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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            nowLife -= 20;
        }
    }
}
