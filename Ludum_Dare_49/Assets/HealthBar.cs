using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void SetMan(float sanity)
    {
        slider.maxValue = sanity;
        slider.value = sanity;
    }

    public void Set(float sanity)
    {

        slider.value = sanity;
    }
   
}
