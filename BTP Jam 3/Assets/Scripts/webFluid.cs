using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class webFluid : MonoBehaviour
{
    public GameObject webFluidLoader;
    public GameObject webGetBiggerEffect;
    [Range(0.01f, 0.5f)]
    public float fluidLoaderIncreaseRate = 0.45f;

    public Transform web;

    public Slider webFluidMeter;

    public float webFluidAmount = 0f;
    public float increaseFluidBy = 1f;
    public float decreaseFluidBy = 1f;
    public InsectsSpawnController insectsSpawnController;
    void Update()
    {
        if (webFluidAmount > 100f)
            webFluidAmount = 100f;
        if (webFluidAmount < 0f)
            webFluidAmount = 0f;

        webFluidMeter.value = Mathf.Lerp(webFluidMeter.value, webFluidAmount, Time.deltaTime * 12f); ;
        if (!Input.GetButton("Fire2"))
        {
            webFluidLoader.SetActive(false);
            webFluidAmount += Time.deltaTime * increaseFluidBy;
        }
        else
        {
            webFluidLoader.SetActive(true);
            webFluidAmount -= Time.deltaTime * decreaseFluidBy;
            Image webFluidLoaderImage = webFluidLoader.GetComponent<Image>();
            if (webFluidAmount > 0f)
            {
                webFluidLoaderImage.fillAmount += fluidLoaderIncreaseRate * Time.deltaTime;
                if (webFluidLoaderImage.fillAmount == 1f)
                {
                    web.localScale += new Vector3(.5f, .5f, 0f);
                    AudioManager.instance.Play("GrowWeb");
                    insectsSpawnController.startTimeToSpawnInsects = 2f;
                    insectsSpawnController.limitedNoOfInsect = 25f;
                    webFluidLoaderImage.fillAmount = 0f;
                    fluidLoaderIncreaseRate -= 0.1f;
                    if (fluidLoaderIncreaseRate < 0.05f)
                        fluidLoaderIncreaseRate = 0.05f;
                    Instantiate(webGetBiggerEffect, web.position, Quaternion.identity);
                    return;
                }
            }
        }
    }

    public void increaseWeb(Vector3 increasedWebSize)
    {
        web.localScale = increasedWebSize;
        Instantiate(webGetBiggerEffect, web.position, Quaternion.identity);
    }

    public void DecreaseWebFluid(float Amount)
    {
        webFluidAmount -= Amount;
    }

}
