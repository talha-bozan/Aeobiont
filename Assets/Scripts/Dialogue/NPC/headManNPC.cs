using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headManNPC : MonoBehaviour
{
    public Player player; // for needs

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void button()
    {

        string pokemonName = ((Ink.Runtime.StringValue)DialogueManager
            .GetInstance()
            .GetVariableState("choice_name_HMan")).value;


        switch (pokemonName)
        {
            case "":
                break;
            case "empty":
                break;
            case "chosed":
                break;
            case "social10":
                deletion();
                player.currentSocial += 10;
                Debug.Log("social10 secildi");
                break;
            default:
                Debug.LogWarning("Pokemon name not handled by switch statement: " + pokemonName);
                break;
        }
    }
    public void deletion()
    {
        ((Ink.Runtime.StringValue)DialogueManager
            .GetInstance()
            .GetVariableState("choice_name_HMan")).value = "empty";
    }
}
