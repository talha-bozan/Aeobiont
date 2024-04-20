using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleWoman : MonoBehaviour
{
    [SerializeField]
    private NeedManager player; // for needs

    public Friendly friendly;
    public Romance romance;
    // Start is called before the first frame update
    public int firstFriendly = 0;
    public int currentFriendly;

    public int firstRomance = 0;
    public int currentRomance;

    void Start()
    {
        currentFriendly = firstFriendly;
        friendly.SetFriendly(firstFriendly);

        currentRomance = firstRomance;
        romance.SetRomance(firstRomance);

    }

    // Update is called once per frame
    void Update()
    {





    }
    //.comparetag var 


    public void button()
    {
        string pokemonName = ((Ink.Runtime.StringValue)DialogueManager
            .GetInstance()
            .GetVariableState("choice_name_MWoman")).value;


        switch (pokemonName)
        {
            case "":
                break;
            case "empty":
                break;
            case "chosed":
                break;
            case "friendly10":
                if (currentFriendly < 90)
                {
                    deletion();
                    currentFriendly += 10;
                    friendly.SetFriendly(currentFriendly);
                    player.currentSocial += 10;
                    Debug.Log("current friendly of middleWoman = " + currentFriendly);


                }
                else
                {
                    deletion();
                    currentFriendly = 100;
                    friendly.SetFriendly(currentFriendly);
                    player.currentSocial += 10;
                }
                break;

            case "Romance10":
                if (currentRomance < 90)
                {
                    deletion();
                    currentRomance += 10;
                    romance.SetRomance(currentRomance);
                    player.currentSocial += 10;
                }
                else
                {
                    deletion();
                    currentRomance = 100;
                    romance.SetRomance(currentRomance);
                    player.currentSocial += 10;
                }

                break;

            case "20friendly":
                if (currentFriendly > 20)
                {
                    deletion();
                    currentFriendly -= 20;
                    friendly.SetFriendly(currentFriendly);

                }
                else
                {
                    deletion();
                    currentFriendly = 10;
                    friendly.SetFriendly(currentFriendly);

                }

                break;

            case "Risque":
                Debug.Log("Risque acildi");
                if (currentFriendly > 60 && currentFriendly < 90)
                {
                    deletion();
                    currentFriendly += 5;
                    friendly.SetFriendly(currentFriendly);
                    player.currentSocial += 10;
                    if (90 > currentRomance)
                    {

                        currentRomance += 5;
                        romance.SetRomance(currentRomance);
                        player.currentSocial += 10;

                    }
                }
                else
                {
                    if (currentFriendly > 10)
                    {
                        deletion();
                        currentFriendly -= 10;
                        friendly.SetFriendly(currentFriendly);

                    }
                }
                break;

            case "5friendly":
                if (currentFriendly >= 15)
                {
                    deletion();
                    currentFriendly -= 5;
                    friendly.SetFriendly(currentFriendly);
                }
                break;

            case "10romance":
                if (currentRomance > 20)
                {
                    deletion();
                    currentRomance -= 10;
                    romance.SetRomance(currentRomance);
                }
                else
                {
                    deletion();
                    currentRomance = 10;
                    romance.SetRomance(currentRomance);

                }
                break;

            case "10friendly":
                if (currentFriendly >= 20)
                {
                    deletion();
                    currentFriendly -= 10;
                    friendly.SetFriendly(currentFriendly);
                }
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
            .GetVariableState("choice_name_MWoman")).value = "empty";
    }
}
