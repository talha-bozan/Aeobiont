using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep_Button : MonoBehaviour
{
	public Player player;

	public void TaskOnClick()
	{
		Debug.Log("sleep butonuna basildi");
		player.currentSleep = 100;

	}
}