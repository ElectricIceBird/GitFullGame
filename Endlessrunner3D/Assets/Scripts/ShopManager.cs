using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    public int currentShopIndex;
    public GameObject[] shopItems;
    public DonoutBlueprint[] donuts;
    public Button buyButton;
    public Button StartButton;


    // Start is called before the first frame update
    void Start()
    {
        foreach(DonoutBlueprint donut in donuts) 
        {
            if(donut.price == 0) 
            {
                donut.isBought = true;
            }
            else 
            {
                donut.isBought = PlayerPrefs.GetInt(donut.name, 0) == 0 ? false : true;
            }
        }
        currentShopIndex = PlayerPrefs.GetInt("Selecteditem", 0);
     foreach(GameObject n in shopItems)
        {
            n.SetActive(false);
            shopItems[currentShopIndex].SetActive(true);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
   public void changenext()
    {
        shopItems[currentShopIndex].SetActive(false);
        currentShopIndex++;
        if(currentShopIndex == shopItems.Length)
        {
            currentShopIndex = 0;
        }
        shopItems[currentShopIndex].SetActive(true);

        PlayerPrefs.SetInt("Selecteditem", currentShopIndex);
        DonoutBlueprint d = donuts[currentShopIndex];
        if (!d.isBought)
            return;
    }
    public void changeback()
    {
        shopItems[currentShopIndex].SetActive(false);
        currentShopIndex--;
        if (currentShopIndex <= -1)
        {
            currentShopIndex = shopItems.Length -1;
        }
        shopItems[currentShopIndex].SetActive(true);
        PlayerPrefs.SetInt("Selecteditem", currentShopIndex);
        DonoutBlueprint d = donuts[currentShopIndex];

        if (!d.isBought)
            return;

    }
   
    private void UpdateUI() 
    {
        DonoutBlueprint d = donuts[currentShopIndex];
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy-" + d.price;

        if (d.isBought) 
        {
            buyButton.gameObject.SetActive(false);

        }
        else 
        {
            buyButton.gameObject.SetActive(true);
            if(d.price > PlayerPrefs.GetInt("NumberOfCoins", 0)) 
            {
                buyButton.interactable = true;
                StartButton.interactable = false;

            }
            else
            {
                buyButton.interactable = false;
                buyButton.interactable = true;



            }
        }
    }
     public void unlockCar() 
    {
        DonoutBlueprint d = donuts[currentShopIndex];
        PlayerPrefs.SetInt(d.name, 1);
        d.isBought = true;
        PlayerPrefs.SetInt("Selecteditem", currentShopIndex);
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - d.price);
        if (!d.isBought)
            return;
    }
}
