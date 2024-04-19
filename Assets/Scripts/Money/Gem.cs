using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gem : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI gemAmountText;

    public int gemAmount;
    private float dirtyGem;

    void Awake()
    {
        gemAmount = 0;
        gemAmountText.text = "0";
    }

    public int getBalance()
    {
        return gemAmount;
    }

    public void setBalance(int newAmount)
    {
        gemAmount = newAmount;
        updateBalanceText();
    }

    public void changeBalance(int increaseAmount)
    {
        gemAmount += increaseAmount;
        
        if(gemAmount < 0)
        {
            gemAmount = 0;
        }

        updateBalanceText();
    }

    public void changeBalance(float increaseAmount)
    {
        dirtyGem += increaseAmount;

        gemAmount = (int) dirtyGem;

        if (gemAmount < 0)
        {
            gemAmount = 0;
        }

        updateBalanceText();
    }

    private void updateBalanceText()
    {
        gemAmountText.text = gemAmount.ToString();
    }
}
