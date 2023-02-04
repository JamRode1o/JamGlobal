using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Recolectable : MonoBehaviour
{
    [SerializeReference] Image[] arepa;
    [SerializeReference] Slider guaro, stamina;
    public static int Arepas = 10;
    [SerializeField] float Guaro, Stamina;
    [SerializeField] TextMeshProUGUI GuaroT, StaminaT;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        guaro.value = Guaro;
        if(MoverPersonaje.run == false)
            stamina.value += Time.deltaTime;

        for (int i = 0; i < Arepas; i++)
        {
            arepa[i].gameObject.SetActive(true);         
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arepa")
        {
            if(Arepas < 20)
            {
                Arepas++;
                other.gameObject.SetActive(false);
            }
        }

        if (other.tag == "Guaro")
        {
            Guaro += 20;
            other.gameObject.SetActive(false);
        }
    }
}
