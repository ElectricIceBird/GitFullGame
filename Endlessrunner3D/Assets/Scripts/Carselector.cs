using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carselector : MonoBehaviour
{
    public int currentdonutIndex;
    public GameObject[] donuts;

    private void Start()
    {
        currentdonutIndex = PlayerPrefs.GetInt("SelectedDonut");
        foreach (GameObject donut in donuts)
        {
            donut.SetActive(false);

            donuts[currentdonutIndex].SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
