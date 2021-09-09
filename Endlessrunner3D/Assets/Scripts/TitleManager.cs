using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject[] tileprefabs;
    public float zSpawn = 0;
    public float tilelength = 30;
    public int numberOfTiles = 5;
    public Transform playertrans;
    private List<GameObject> activetiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else {
                SpawnTile(Random.Range(0, tileprefabs.Length));
            } 
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (playertrans.position.z -35 > zSpawn - (numberOfTiles*tilelength))
        {
            SpawnTile(Random.Range(0, tileprefabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {

        GameObject Go = Instantiate(tileprefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activetiles.Add(Go);
        zSpawn += tilelength;
    }
    public void DeleteTile()
    {
        Destroy(activetiles[0]);
        activetiles.RemoveAt(0);
    }
}
