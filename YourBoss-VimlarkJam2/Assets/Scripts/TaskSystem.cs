using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    
    public static float taskHealth;
    public static float currenttaksHealth;
    public HealthBar hb;
    public GameObject panel;

    private void Start()
    {
        
        taskHealth = 100f;
        currenttaksHealth = taskHealth;
        hb.SetMan(taskHealth);
    }
    private void Update()
    {
        if(currenttaksHealth <= 0)
        {
            
            panel.SetActive(true);
            Time.timeScale = 0;
        


        }
        else
        {
            currenttaksHealth -= 0.02f;
            hb.Set(currenttaksHealth);


        }
        if (currenttaksHealth >= 100)
        {
            currenttaksHealth = 100;
        }




    }

}
