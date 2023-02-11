using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemyBarBehavior : MonoBehaviour
{
    public Image Image;
    public float healthTreshold = 0.2f;
    public bool isDamaged = false;

    public void SetImage()
    {
        Image.enabled = true;
    }

    public void UnsetImage()
    {
        Image.enabled = false;
    }
}
