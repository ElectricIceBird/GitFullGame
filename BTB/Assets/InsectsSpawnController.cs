using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectsSpawnController : MonoBehaviour
{
    [Range(0f,25f)]
    public float timeToSpawnInsects = 3f;

    public GameObject[] insects;

    public Transform[] spawnPoints;

    public int numberOfInsects = 6;
    public int temp = 6;

    void Start()
    {
        StartCoroutine(spawnInsect(0f));        
    }

    public void ReduceSpawnTime(float amount)
    {
        timeToSpawnInsects -= amount;
        if(timeToSpawnInsects <= 0)
        {
            timeToSpawnInsects = 4;
        }

    }

    IEnumerator spawnInsect(float time)
    {
        if(numberOfInsects > 0)
        {
            yield return new WaitForSeconds(time);
            for (int i = 0; i < numberOfInsects; i++)
            {
                Instantiate(insects[Random.Range(0, insects.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(0f,0.5f));
                numberOfInsects--;
            }

        }
            StartCoroutine(spawnInsect(timeToSpawnInsects));

    }
}
