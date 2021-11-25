using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    public static float stablelity;
    public static float currentstablelity;
    public HealthBar hp;
    public GameObject panel;


    // Start is called before the first frame update
    void Start()
    {
        stablelity = 100;
        currentstablelity = stablelity;
        hp.SetMan(stablelity);


    }

    // Update is called once per frame
    void Update()
    {
        if (currentstablelity == 0)
        {
            AudioManager.ad.Playsound("Exp");

            Die();
        }
        else
        {
            currentstablelity -=  Time.deltaTime * 2;
            hp.Set(currentstablelity);

        }
        if(currentstablelity >= 100)
        {
            currentstablelity = 100;
        }
    }

    private void Die()
    {
        panel.SetActive(true);
        
        Destroy(gameObject);
    }
}
