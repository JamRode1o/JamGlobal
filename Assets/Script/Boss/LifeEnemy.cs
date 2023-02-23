using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeEnemy : MonoBehaviour
{
    [SerializeField]
    private int lifeEnemy = 30;
    private BoxCollider boxCollider;
    private Animator anim;
    private AiDiablo aiDiablo;
    public GameObject CanvasWin;
    public Image lifeDiablo;
    public GameObject CanvaslifeBoss;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        anim = gameObject.GetComponent<Animator>();
        aiDiablo = gameObject.GetComponent<AiDiablo>();
        CanvasWin.SetActive(false);
        CanvaslifeBoss.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ArmPlayer")
        {
            
            lifeEnemy--;
            boxCollider.enabled = false;
            CkeckLife();
            StartCoroutine(CountTimer(1f));

        }
            


    }

    IEnumerator CountTimer(float time)
    {

        yield return new WaitForSeconds(time);
        ActiveCollider();

    }

    IEnumerator CountDeath(float time)
    {

        yield return new WaitForSeconds(time);
        DestroyBoss();

    }

    void ActiveCollider()
    {
        boxCollider.enabled = true;
    }

    void CkeckLife()
    {
        lifeDiablo.fillAmount = lifeEnemy;
        if (lifeEnemy <= 0)
        {
            //Destroy(gameObject);
            
            anim.SetBool("Melee", false);
            anim.SetBool("Fireball", false);
            anim.SetBool("Stop", false);
            anim.SetBool("Walk", false);
            anim.SetBool("spawnGoblins", false);
            anim.SetBool("Death", true);
            aiDiablo.enabled = false;


        }
    }

    public void Death()
    {
        boxCollider.enabled = false;
        StartCoroutine(CountDeath(0.3f));
    }

    void DestroyBoss()
    {
        CanvasWin.SetActive(true);
        Destroy(gameObject);
    }


}
