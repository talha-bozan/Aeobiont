using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Social_Button : MonoBehaviour
{
    public NeedManager player;

    public void TaskOnClick()
    {
        Debug.Log("social butonuna basildi");
        player.ResetNeed(NeedManager.NeedType.social);


    }
}