using UnityEngine;
using UnityEngine.UI;

public class Need : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxValue(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }
    public float GetValue() { return slider.value;}
}
