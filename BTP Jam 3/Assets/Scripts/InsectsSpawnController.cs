using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectsSpawnController : MonoBehaviour
{
    [Range(0f,25f)]
    public float startTimeToSpawnInsects = 10f;
    private float timeToSpawnInsects = 0f;

    public GameObject[] insects;
    GameObject[] insectsInScene;

    public Transform[] spawnPoints;
    public float limitedNoOfInsect = 12f;

    void Start()
    {
        timeToSpawnInsects = 0f;       
        howManyInsectInScene();
    }

    void howManyInsectInScene()
    {
        insectsInScene = GameObject.FindGameObjectsWithTag("Insect");
    }

    private void Update() 
    { 
        if(timeToSpawnInsects <= 0f && insectsInScene.Length < limitedNoOfInsect)
        {
            Instantiate(insects[Random.Range(0, insects.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            timeToSpawnInsects = startTimeToSpawnInsects;
        }
        else
        {
            timeToSpawnInsects -= Time.deltaTime;
        }
    }
    void LateUpdate()
    {
        howManyInsectInScene();
    }
}
