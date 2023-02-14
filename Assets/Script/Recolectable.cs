using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Recolectable : MonoBehaviour
{
    [SerializeReference] Image[] arepa= new Image[10];// = new List<Image>();
    [SerializeField] GameObject[] guaro = new GameObject[4];
    [SerializeField] GameObject perder;
    public static float Guaro;
    float grito;

    public static bool BerriondoMode;

    public Slider stamina;

    public static int Arepas = 10;

    public AudioSource son;
    public AudioClip[] sonidos;
    public Animator ani;
    bool berr=false;

    

    void Update()
    {

       
        if(MoverPersonaje.run == false)
        {
            //  stamina.value += Time.deltaTime;                   
        }
        
        switch (Guaro)
        {
            case 0:
                guaro[1].SetActive(false);
                guaro[2].SetActive(false);
                guaro[3].SetActive(false);
                break;
            case 1:
                guaro[1].SetActive(true);
                guaro[2].SetActive(false);
                guaro[3].SetActive(false);
                break;
            case 2:
                guaro[2].SetActive(true);
                guaro[3].SetActive(false);
                guaro[1].SetActive(false);
                break;
            case 3:
                guaro[3].SetActive(true);
                guaro[2].SetActive(false);
                guaro[1].SetActive(false);
                grito = 1;
                break;
            default:
                break;
        }

        if (Input.GetKeyUp(KeyCode.Q))
            BerriondoMode = !BerriondoMode;
        

        //if (Guaro >= 3 && grito > 1)
        //{
        //    ani.SetTrigger("Grito");
        //    grito = 0;// hacer que solo pueda gritar una vez cada vez que tenga los 4 de guaro
        //}
        //for (int i = 0; i < Arepas; i++) // organizar para que la vida se apague de manera correcta cuando recibe el daño
        //{
        //    arepa[i].gameObject.SetActive(true);
        //    int var = i;
        //    // arepa[i + 1].gameObject.SetActive(false);
        //    //arepa.RemoveAt(var);
        //}

        //for (int i = 0; i < Arepas; i++)
        //{
        //    arepa[i].gameObject.SetActive(true);         
        //}



        if (Health.playerHealth <= 0)
            perder.SetActive(true);
    }
    int rando()
    {
        int tem = Random.Range(0, sonidos.Length);
        return tem;
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

        if(other.tag=="Arepa")
            other.gameObject.SetActive(false);

        if (other.tag == "Enemy")
        {
            son.PlayOneShot(sonidos[rando()]);
        }

        if (other.tag == "Guaro")
        {
            Guaro += 1;
            other.gameObject.SetActive(false);
        }
    }
}
