using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Recolectable : MonoBehaviour
{
    [SerializeReference] Image[] arepa= new Image[10];// = new List<Image>();
    [SerializeReference] Slider guaro;
    [SerializeField] GameObject perder;
    [SerializeField] float  StaminaValue;
    public static float Guaro;

    public Slider stamina;

    public static int Arepas = 10;


    void Update()
    {

        guaro.value = Guaro;
        if(MoverPersonaje.run == false)
        {
              stamina.value += Time.deltaTime;                   
        }


        for (int i = 0; i < Arepas; i++) // organizar para que la vida se apague de manera correcta cuando recibe el da�o
        {
            arepa[i].gameObject.SetActive(true);
            int var = i;
            // arepa[i + 1].gameObject.SetActive(false);
            //arepa.RemoveAt(var);
        }

        //for (int i = 0; i < Arepas; i++)
        //{
        //    arepa[i].gameObject.SetActive(true);         
        //}



        //if (Arepas <= 0)
        //    perder.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "Arepa")
        //{
        //    if(Arepas < 20)
        //    {
        //        Arepas++;
        //        other.gameObject.SetActive(false);
        //    }
        //}

        if (other.tag == "Guaro")
        {
            Guaro = +20;
            other.gameObject.SetActive(false);
        }
    }
}
