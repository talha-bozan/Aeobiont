using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger_Button : MonoBehaviour
{
	public Player player;

	public void TaskOnClick()
	{
		Debug.Log("hunger butonuna basildi");
		player.currentHunger = 100;

	}
}