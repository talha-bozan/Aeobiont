using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger_Button : MonoBehaviour
{
	public NeedManager player;

	public void TaskOnClick()
	{
		Debug.Log("hunger butonuna basildi");
        player.ResetNeed(NeedManager.NeedType.hunger);


    }
}