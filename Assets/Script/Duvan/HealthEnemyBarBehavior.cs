using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemyBarBehavior : MonoBehaviour
{
    public Image Image;

    public Vector3 Offset;

    public void setImage()
    {
        Image.enabled = true;
    }

    public void UnsetImage()
    {
        Image.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        Image.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
