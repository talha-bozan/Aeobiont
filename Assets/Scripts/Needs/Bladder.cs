using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bladder : MonoBehaviour
{

    public Slider slider;

    public void SetMaxBladder(float bladder)
    {
        slider.maxValue = bladder;
        slider.value = bladder;
    }
    public void SetBladder(float bladder)
    {
        slider.value = bladder;
    }

}