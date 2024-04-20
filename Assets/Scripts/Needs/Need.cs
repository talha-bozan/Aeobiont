using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices.WindowsRuntime;  // Include the System namespace for events

public class Need : MonoBehaviour
{
    public Slider slider;
    private float currentValue;
    private float maxValue = 100f;

    private void Start()
    {
        currentValue = maxValue;
    }


    public void SetMaxValue(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }

    public float GetMaxValue() 
    {
        return maxValue;
    }

    public void SetValue(float value)
    {   
        currentValue = value;
        slider.value = currentValue;
    }

    public void ResetValue()
    {
        currentValue = maxValue;
        slider.value = currentValue;
    }

    public void IncreaseValue(float value)
    {
        currentValue = Mathf.Clamp(currentValue + value, 0, maxValue);
    }

    public void InterpolateValue(float interpolationFactor)
    {
        currentValue = Mathf.Lerp(currentValue, maxValue, interpolationFactor);

    }

    public float GetValue() { return currentValue;}
}
