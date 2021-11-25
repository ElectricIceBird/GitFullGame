using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carselector : MonoBehaviour
{
    public int currentShopIndex;
    public GameObject[] donuts;

    // Start is called before the first frame update
    void Start()
    {
        currentShopIndex = PlayerPrefs.GetInt("Selecteditem", 0);
        foreach (GameObject n in donuts)
        {
            n.SetActive(false);
            donuts[currentShopIndex].SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
