using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selector : MonoBehaviour
{
    public int currentShopIndex;
    public GameObject[] itmes;

    // Start is called before the first frame update
    void Start()
    {
        currentShopIndex = PlayerPrefs.GetInt("Selecteditem", 0);
        foreach (GameObject n in itmes)
        {
            n.SetActive(false);
            itmes[currentShopIndex].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
