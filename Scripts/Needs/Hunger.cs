using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHunger(float hunger)
    {
        slider.maxValue = hunger;
        slider.value = hunger;
    }
    public void SetHunger(float hunger)
    {
        slider.value = hunger;
    }

}