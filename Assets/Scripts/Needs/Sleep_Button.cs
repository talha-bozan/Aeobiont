using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep_Button : MonoBehaviour
{
	public NeedManager player;

	public void TaskOnClick()
	{
		Debug.Log("sleep butonuna basildi");
        player.ResetNeed(NeedManager.NeedType.sleep);


    }
}