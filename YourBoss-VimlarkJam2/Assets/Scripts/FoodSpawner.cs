using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject food;
    public GameObject food2;


    public Transform spawnpoint;
    public Transform spawnpoint2;
    public Transform spawnpoint3;
    public Transform spawnpoint4;
    


    // Start is called before the first frame update
    void Start()
    {


        }
    // Update is called once per frame
    void Update()
    {
     if(GameObject.FindGameObjectWithTag("Donut") == null && GameObject.FindGameObjectWithTag("Coffee") == null)
        {
            spawn();
        }
        else
        {
            return;
        }
     
    }
    void spawn()
    {
        
        Instantiate(food, spawnpoint);
        
        Instantiate(food2, spawnpoint2);
        
        Instantiate(food, spawnpoint3);
        
        Instantiate(food2, spawnpoint4);


    }
}
