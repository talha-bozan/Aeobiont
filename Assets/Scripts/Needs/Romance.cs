using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Romance : MonoBehaviour
{
    public int romance;


    public void SetRomance(int romance_value)
    {
        romance = romance_value;
        isRomanceZero(romance);
    }

    public void isRomanceZero(int romance_value)
    {
        if (romance_value < 10)
        {
            romance_value = 10;
        }
    }
}
