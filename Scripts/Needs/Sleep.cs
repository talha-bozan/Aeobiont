using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{

    public Slider slider;

    public void SetMaxSleep(float sleep)
    {
        slider.maxValue = sleep;
        slider.value = sleep;
    }
    public void SetSleep(float sleep)
    {
        slider.value = sleep;
    }

}
