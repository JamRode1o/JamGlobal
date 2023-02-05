using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiDiablo : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;
    private Animator anim;

    public BossState currentState;

    [SerializeField]
    private AudioClip moveBossSound;
    [SerializeField]
    private AudioClip fireSound;

    // Distancia 
    [SerializeField]
    private GameObject fire;
    [SerializeField]
    private GameObject Goblins;

    // Puntos de Spawn
    [SerializeField]
    private GameObject[] points;
    [SerializeField]
    private GameObject pointFire;

    // confirmar si esta o no en ataque
    private bool endAttack = true;

    private float distance;



    public enum BossState { GoToPlayer, DistancePlayer, SpawnGoblins, SpawnAirBullets, SpawnFire, SkipBoss }



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(WaitAndEjecute(2f, randomAtack));
    }

    // Update is called once per frame
    private void Update()
    {
       


        distance = Vector2.Distance(target.position, transform.position);




        switch (currentState)
        {


            case BossState.GoToPlayer:
                GoToPlayer();
                break;

            case BossState.DistancePlayer:
                DistancePlayer();
                break;

            case BossState.SpawnFire:
                SpawnFire();
                break;

            case BossState.SpawnGoblins:
                SpawnGoblins();
                break;


            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }

    IEnumerator CountAction(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();

    }

    void RandomDistanceAttack()
    {
        int random = UnityEngine.Random.Range(0, 3);
        if(random <= 1)
        {
            SpawnFire();
        }
        else
        {
            SpawnGoblins();
        }
    }

    void SpawnFire()
    {
        print("proceso de fuego");
        agent.isStopped = true;
        anim.SetBool("FireBullet", true);

    }

    void SpawnFireAnim()
    {
        print("voy a tirar fuego");
        agent.isStopped = true;
        AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position, 0.1f);
        Instantiate(fire, pointFire.transform.position, Quaternion.identity);
        anim.SetBool("FireBullet", false);
        currentState = BossState.GoToPlayer;
    }

    void ChangeAttack()
    {
        StartCoroutine(CountAction(1f, EndingAttack));
    }

    void SpawnGoblins()
    {
        print("spawn Duendes");
        for (int i = 0; i > points.Length; i++)
        {
            endAttack = false;
            Instantiate(Goblins, points[i].transform.position, Quaternion.identity);
            ChangeAttack();
        }
    }

    void EndingAttack()
    {
        endAttack = true;
    }

    void GoToPlayer()
    {
        print("voy donde el player");
        agent.isStopped = false;
        anim.SetBool("FireBullet", false);
       // AudioSource.PlayClipAtPoint(moveBossSound, Camera.main.transform.position, 0.2f);
        //anim.SetBool("Stop", false);
        agent.SetDestination(target.position);
    }

    void DistancePlayer()
    {
        agent.isStopped = true;
      //  anim.SetBool("Stop", true);
        currentState = BossState.SpawnFire;

    }

    IEnumerator WaitAndEjecute(float time, Action action)
    {
        Debug.Log("estoy dentro de waitAndEjecute");
        yield return new WaitForSecondsRealtime(time);
        action();
    }

    void randomAtack()
    {
        Debug.Log("Estoy en el random Attack");
        
            int random = UnityEngine.Random.Range(0, 3);

            if (random == 0)
            {
                currentState = BossState.SpawnAirBullets;
            }
            else if (random == 1)
            {
                currentState = BossState.SpawnFire;
            }
            else if (random == 2)
            {
                currentState = BossState.SpawnGoblins;
            }
            else if (random == 3)
            {
                currentState = BossState.GoToPlayer;
            }

            callTimer(4f);
        
       
        
    }

    void callTimer(float time)
    {
        StartCoroutine(WaitAndEjecute(time, randomAtack));
    }
}