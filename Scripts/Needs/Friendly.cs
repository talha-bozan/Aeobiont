using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Friendly : MonoBehaviour
{
    public int friendly;


    public void SetFriendly(int friendly_value)
    {
        friendly = friendly_value;
        isFriendlyZero(friendly);
    }
    
    public void isFriendlyZero(int friendly_value)
    {
        if(friendly_value < 10)
        {
            friendly_value = 10; 
        }
    }
}
