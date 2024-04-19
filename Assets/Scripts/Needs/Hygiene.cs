using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hygiene : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHygiene(float hygiene)
    {
        slider.maxValue = hygiene;
        slider.value = hygiene;
    }
    public void SetHygiene(float hygiene)
    {
        slider.value = hygiene;
    }

}