using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleWoman : MonoBehaviour
{
    [SerializeField]
    private NeedManager player; // for needs


    // Start is called before the first frame update
    public int firstFriendly = 0;
    public int currentFriendly;

    public int firstRomance = 0;
    public int currentRomance;

    void Start()
    {
        currentFriendly = firstFriendly;
        player.SetFriendly(firstFriendly);

        currentRomance = firstRomance;
        player.SetRomance(firstRomance);

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
                    player.SetFriendly(currentFriendly);
                    player.IncreaseNeed(NeedManager.NeedType.social, 10);
                    Debug.Log("current player of middleWoman = " + currentFriendly);


                }
                else
                {
                    deletion();
                    currentFriendly = 100;
                    player.SetFriendly(currentFriendly);
                    player.IncreaseNeed(NeedManager.NeedType.social, 10);
                }
                break;

            case "Romance10":
                if (currentRomance < 90)
                {
                    deletion();
                    currentRomance += 10;
                    player.SetRomance(currentRomance);
                    player.IncreaseNeed(NeedManager.NeedType.social, 10);
                }
                else
                {
                    deletion();
                    currentRomance = 100;
                    player.SetRomance(currentRomance);
                    player.IncreaseNeed(NeedManager.NeedType.social, 10);
                }

                break;

            case "20friendly":
                if (currentFriendly > 20)
                {
                    deletion();
                    currentFriendly -= 20;
                    player.SetFriendly(currentFriendly);

                }
                else
                {
                    deletion();
                    currentFriendly = 10;
                    player.SetFriendly(currentFriendly);

                }

                break;

            case "Risque":
                Debug.Log("Risque acildi");
                if (currentFriendly > 60 && currentFriendly < 90)
                {
                    deletion();
                    currentFriendly += 5;
                    player.SetFriendly(currentFriendly);
                    player.IncreaseNeed(NeedManager.NeedType.social, 10);
                    if (90 > currentRomance)
                    {

                        currentRomance += 5;
                        player.SetRomance(currentRomance);
                        player.IncreaseNeed(NeedManager.NeedType.social, 10);

                    }
                }
                else
                {
                    if (currentFriendly > 10)
                    {
                        deletion();
                        currentFriendly -= 10;
                        player.SetFriendly(currentFriendly);

                    }
                }
                break;

            case "5friendly":
                if (currentFriendly >= 15)
                {
                    deletion();
                    currentFriendly -= 5;
                    player.SetFriendly(currentFriendly);
                }
                break;

            case "10romance":
                if (currentRomance > 20)
                {
                    deletion();
                    currentRomance -= 10;
                    player.SetRomance(currentRomance);
                }
                else
                {
                    deletion();
                    currentRomance = 10;
                    player.SetRomance(currentRomance);

                }
                break;

            case "10friendly":
                if (currentFriendly >= 20)
                {
                    deletion();
                    currentFriendly -= 10;
                    player.SetFriendly(currentFriendly);
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
