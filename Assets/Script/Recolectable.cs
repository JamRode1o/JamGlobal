using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Recolectable : MonoBehaviour
{
    [SerializeReference] Image arepa;
    [SerializeReference] Slider guaro, stamina;
    [SerializeField] int Arepas;
    [SerializeField] float Guaro, Stamina;
    [SerializeField] TextMeshProUGUI GuaroT, StaminaT;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        guaro.value += Guaro;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arepa")       
            Arepas++;

        if (collision.gameObject.tag == "Guaro")
        {
            Guaro += 20;
            collision.gameObject.SetActive(false);
        }
     

        if (collision.gameObject.tag == "Stamina")
            Stamina += 10;// rellenar con el tiempo

    }
}
