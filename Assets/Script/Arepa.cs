using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arepa : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(speed, 0, 0);
    }
}
