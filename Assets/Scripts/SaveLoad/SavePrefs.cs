using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Gem playerBalance;

    public int difficultyLevel;

    private float positionX;
    private float positionY;

    private int money;
    
    private void Awake()
    {
        positionX = 0f;
        positionY = 0f;
        money = 0;
        difficultyLevel = 2;
    }

    public void SaveDifficulty(int newDifficultyLevel)
    {
        print("Bef Diff: " + newDifficultyLevel);
        PlayerPrefs.SetInt("DifficultyLevel", newDifficultyLevel);
    }

    public void LoadDifficulty()
    {
        if (PlayerPrefs.HasKey("DifficultyLevel"))
        {
            difficultyLevel = PlayerPrefs.GetInt("DifficultyLevel");
            print("Diff: " + difficultyLevel);
        }
    }

    public void SaveGame()
    {
        playerBalance = GetComponent<Gem>();

        positionX = playerPos.position.x;
        positionY = playerPos.position.y;
        print("This->" + playerBalance);
        if (playerBalance != null)
        {
            money = playerBalance.getBalance();
            PlayerPrefs.SetInt("GemAmount", money);
        }
        PlayerPrefs.SetFloat("PositionX", positionX);
        PlayerPrefs.SetFloat("PositionY", positionY);
        PlayerPrefs.Save();
        Debug.Log("Game data saved! " + money);
    }

    public void LoadGame()
    {
        playerBalance = GetComponent<Gem>();
        Debug.Log("Game data loaded!" + money);
        if (PlayerPrefs.HasKey("GemAmount"))
        {
            if(playerBalance != null)
            {
                money = PlayerPrefs.GetInt("GemAmount");
                playerBalance.setBalance(money);
            }
            Debug.Log("Game data loaded! " + money);
        }
        if (PlayerPrefs.HasKey("PositionX") && PlayerPrefs.HasKey("PositionY"))
        {
            positionX = PlayerPrefs.GetFloat("PositionX");
            positionY = PlayerPrefs.GetFloat("PositionY");
            playerPos.position = new Vector3(positionX, positionY, playerPos.position.z);
        }
        else
            Debug.LogWarning("There is no save data! ");
        LoadDifficulty();
    }
}
