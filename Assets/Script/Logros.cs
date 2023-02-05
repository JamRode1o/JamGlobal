using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logros : MonoBehaviour
{
    public static int attackCounter = 0;
    public static float timePlaying = 0;

    void Start()
    {
        timePlaying = Time.deltaTime;
    }

    
    void Update()
    {
        //if (Input.GetKey("Fire01"))
        //    attackCounter += 1;

        if (Input.GetKey(KeyCode.O)){
            SceneManager.LoadScene(2);
        }
    }
}
