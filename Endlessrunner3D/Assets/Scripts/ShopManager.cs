using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int currentShopIndex;
    public GameObject[] shopItems;

    // Start is called before the first frame update
    void Start()
    {
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

    }
}
