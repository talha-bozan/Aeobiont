using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WC_Button : MonoBehaviour
{
    public Player player;

    public void TaskOnClick()
    {
        Debug.Log("wc butonuna basildi");
        player.currentBladder = 100;

    }
}