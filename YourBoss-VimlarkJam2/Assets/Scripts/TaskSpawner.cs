using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    public GameObject task;
    public GameObject task2;
    public GameObject task3;
    public GameObject task4;



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
        if (GameObject.FindGameObjectWithTag("Task") == null)
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

        Instantiate(task, spawnpoint);

        Instantiate(task2, spawnpoint2);

        Instantiate(task3, spawnpoint3);

        Instantiate(task4, spawnpoint4);


    }
}
