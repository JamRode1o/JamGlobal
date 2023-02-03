using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MueblesTotal : MonoBehaviour
{
    public GameObject[] totalMuebles;
    public TextMeshProUGUI disponibles;

    // Start is called before the first frame update
    void Start()
    {
        TotalMuebles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TotalMuebles()
    {
        for (int i = 0; i < totalMuebles.Length; i++) 
        {
            disponibles.text=totalMuebles.ToString();
            Debug.Log(disponibles);
        };
    }
}
