using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hygiene_Button : MonoBehaviour
{
	public NeedManager player;

	public void TaskOnClick()
	{
		Debug.Log("Hygiene butonuna basildi");
		player.ResetNeed(NeedManager.NeedType.hygiene);

	}
}