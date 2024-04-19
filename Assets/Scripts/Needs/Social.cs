using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Social : MonoBehaviour
{

    public Slider slider;

    public void SetMaxSocial(float social)
    {
        slider.maxValue = social;
        slider.value = social;
    }
    public void SetSocial(float social)
    {
        slider.value = social;
    }

}