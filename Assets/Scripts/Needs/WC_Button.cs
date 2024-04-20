using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WC_Button : MonoBehaviour
{
    public NeedManager player;

    public void TaskOnClickForWC()
    {
        Debug.Log("wc butonuna basildi");
        player.currentBladder = 100;

    }
}