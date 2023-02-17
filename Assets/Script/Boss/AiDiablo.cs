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

    private float speedSave;

    private int cantGobblins;

    public enum BossState { GoToPlayer, DistancePlayer, SpawnGoblins,  SpawnFire}


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cantGobblins = 0;

        //agent = GetComponent<NavMeshAgent>();
        StartCoroutine(WaitAndEjecute(2f, randomAtack));
        speedSave = agent.speed;
    }

    // Update is called once per frame
    private void Update()
    {

        transform.LookAt(target);

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
        anim.SetBool("Walk", false);
        agent.isStopped = true;
        anim.SetBool("FireBullet", true);

    }

    void SpawnFireAnim()
    {
        print("voy a tirar fuego");
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
        print("Estoy spawneando goblins");
        anim.SetBool("Walk", false);
        if (cantGobblins >= 6)
        {
            print("No generaré más enanos");
            randomAtack();
        }
        else
        {
            anim.SetBool("Stop", true);
            
            agent.isStopped = true;
            anim.SetBool("spawnGoblins", true);
        }
        
    }

    void MeleeAttack()
    {
        agent.isStopped = true;
        anim.SetBool("Melee", true);
    }

    void MeleeAttackAnim()
    {
        
        anim.SetBool("Stop", false);
        agent.isStopped = true;
        
    }

    void MeleeAttackEnd()
    {
        anim.SetBool("Melee", false);
        callTimer(1f);
    }



    public void SpawnGoblinsAnim()
    {
        
        print("spawn Duendes");
        
            for (int i = 0; i < points.Length; i++)
            {
                endAttack = false;
                Instantiate(Goblins, points[i].transform.position, Quaternion.identity);
                ChangeAttack();
                cantGobblins++;
            }
        
        anim.SetBool("spawnGoblins", false);
    }

    void EndingAttack()
    {
        endAttack = true;
    }

    void GoToPlayer()
    {
        anim.SetBool("Stop", false);
        print("voy donde el player");
        agent.isStopped = false;
        anim.SetBool("Walk", true);
        anim.SetBool("FireBullet", false);
       // AudioSource.PlayClipAtPoint(moveBossSound, Camera.main.transform.position, 0.2f);
        
        agent.SetDestination(target.position);
    }

    void DistancePlayer()
    {
        agent.isStopped = true;
        anim.SetBool("Stop", true);
        currentState = BossState.SpawnFire;

    }

    IEnumerator WaitAndEjecute(float time, Action action)
    {
        Debug.Log("estoy dentro de waitAndEjecute");
        agent.isStopped = true;
        anim.SetBool("Stop", true);
        yield return new WaitForSecondsRealtime(time);
        action();
    }

    void randomAtack()
    {
        Debug.Log("Estoy en el random Attack");
        
            int random = UnityEngine.Random.Range(0, 4);

            if (random == 0)
            {
                currentState = BossState.SpawnFire;
            }
            else if (random == 1)
            {
                currentState = BossState.SpawnFire;
            }
            else if (random == 2)
            {
                currentState = BossState.SpawnGoblins;
            }
            else if (random >= 3)
            {
                currentState = BossState.GoToPlayer;
            }

            callTimer(1.5f);
        
       
        
    }

    void callTimer(float time)
    {
        if (distance <= 1.5f)
        {
            MeleeAttack();
        }
        else
        {
            StartCoroutine(WaitAndEjecute(time, randomAtack));
        }
    }
}