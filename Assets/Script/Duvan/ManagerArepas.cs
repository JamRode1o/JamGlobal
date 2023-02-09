using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManagerArepas : MonoBehaviour
{

    public GameObject arepa;
    public List<Image> arepas;

    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = Health.instance;
        playerHealth.DamageTaken += UpdateArepas;
        playerHealth.HealthUpgraded += AddArepas;
        for (int i = 0; i < playerHealth.maxHealth; i++)
        {
            GameObject a = Instantiate(arepa, this.transform);
            arepas.Add(a.GetComponent<Image>());
        }

    }

    // Update is called once per frame
    void UpdateArepas()
    {
        int arepaFill = playerHealth.Jealth;

        foreach (Image i in arepas)
        {
            i.fillAmount = arepaFill;
            arepaFill -= 1;
        }
    }

    void AddArepas()
    {
        foreach (Image i in arepas)
        {
            Destroy(i.gameObject);
        }
        arepas.Clear();
        for (int i = 0; i < playerHealth.maxHealth; i++)
        {
            GameObject a = Instantiate(arepa, this.transform);
            arepas.Add(a.GetComponent<Image>());
        }
        
    }
    
}
