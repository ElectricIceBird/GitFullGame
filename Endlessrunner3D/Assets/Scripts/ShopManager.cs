using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    public int currentdonutIndex = 0;
    public GameObject[] donutModel;
    public DonoutBlueprint[] donoutsBlup;
    public Button buyBuyyon;
    public Button StartBuyyon;

    [SerializeField] int coin;
    public TextMeshProUGUI coins;

    private void Start()
    {
        coin = PlayerPrefs.GetInt("NumberOfCoins", PlayerController.numbersofCoin);

        foreach (DonoutBlueprint donut in donoutsBlup) 
        {
            if(donut.price == 0) { donut.isBought = true; } 
            else 
            {
                donut.isBought = PlayerPrefs.GetInt(donut.name, 0)==0? false:true;
            }
        }
        currentdonutIndex = PlayerPrefs.GetInt("SelectedDonut");
        foreach (GameObject donut in donutModel) 
        {
            donut.SetActive(false);
            donutModel[currentdonutIndex].SetActive(true);
        }   
    }
    private void Update()
    {
        coins.text = "Coins:" + coin.ToString();

        UpdateUI();
    }

    public void ChangeNext() 
    {
        donutModel[currentdonutIndex].SetActive(false);
        currentdonutIndex++;
        if(currentdonutIndex == donutModel.Length)
        {
            currentdonutIndex = 0;
        }
        donutModel[currentdonutIndex].SetActive(true);
        DonoutBlueprint d = donoutsBlup[currentdonutIndex];
        if (!d.isBought)
            return;
        PlayerPrefs.SetInt("SelectedDonut", currentdonutIndex);
    }
    public void ChangeBack()
    {
        donutModel[currentdonutIndex].SetActive(false);
        currentdonutIndex--;
        if (currentdonutIndex == -1)
        {
            currentdonutIndex = donutModel.Length -1;
        }
        donutModel[currentdonutIndex].SetActive(true);
        DonoutBlueprint d = donoutsBlup[currentdonutIndex];
        if (!d.isBought)
            return;
        PlayerPrefs.SetInt("SelectedDonut", currentdonutIndex);
    }
    public void UnlockDonut()
    {
        DonoutBlueprint d = donoutsBlup[currentdonutIndex];
        PlayerPrefs.GetInt(d.name, 1);
        PlayerPrefs.SetInt("SelectedDonut", currentdonutIndex);
        d.isBought = true;
        coin -= d.price;
        PlayerPrefs.SetInt("NumberOfCoins", coin);
    }
    public void UpdateUI()
    {
        DonoutBlueprint d = donoutsBlup[currentdonutIndex];
        if (d.isBought) 
        {
            buyBuyyon.gameObject.SetActive(false);
            StartBuyyon.interactable = true;

        }
        else 
        {
            buyBuyyon.gameObject.SetActive(true);
            buyBuyyon.GetComponentInChildren<TextMeshProUGUI>().text = "Buy-" + d.price;

            if (d.price > coin) 
            {
                StartBuyyon.interactable = false;

                buyBuyyon.interactable = false;
            }
            else 
            {
               StartBuyyon.interactable = false;


                buyBuyyon.interactable = true;

            }
        }

    }
}
