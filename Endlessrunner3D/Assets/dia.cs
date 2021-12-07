using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dia : MonoBehaviour
{
    int numberofCoins;
    public TextMeshProUGUI coins;
    void Start()
    {
        numberofCoins = PlayerPrefs.GetInt("NumberOfCoins",PlayerController.numbersofCoin);   
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "Coins:" + numberofCoins.ToString();
         }
}
