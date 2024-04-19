using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Bladder bladder;
    public Sleep sleep;
    public Hunger hunger;
    public Hygiene hygiene;
    public Social social;

    public float maxBladder = 100;
    public float currentBladder;

    public float maxSleep = 100;
    public float currentSleep;

    public float maxHunger = 100;
    public float currentHunger;

    public float maxHygiene = 100;
    public float currentHygiene;

    public float maxSocial = 100;
    public float currentSocial;

    public int difficultyLevel;

    [SerializeField]
    private SceneNavigator sNav;

    // Start is called before the first frame update
    void Start()
    {
        currentBladder = maxBladder;
        bladder.SetMaxBladder(maxBladder);

        currentSleep = maxSleep;
        sleep.SetMaxSleep(maxSleep);

        currentHunger = maxHunger;
        hunger.SetMaxHunger(maxHunger);

        currentHygiene = maxHygiene;
        hygiene.SetMaxHygiene(maxHygiene);

        currentSocial = maxSocial;
        social.SetMaxSocial(maxSocial);
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamageBladder(difficultyLevel * 0.5f);
        TakeDamageSleep(difficultyLevel * 0.5f);
        TakeDamageHunger(difficultyLevel * 0.5f);
        TakeDamageHygiene(difficultyLevel * 0.5f);
        TakeDamageSocial(difficultyLevel * 0.5f);


        if (currentHunger <= 0)
        {
            GameOver();

        }

        if (currentBladder <= 0)
        {
            ZeroHygiene();
        }

    }

    public void TakeDamageBladder(float damage)
    {
        currentBladder -= (damage * Time.deltaTime) * Random.Range(0.7f, 1.1f);
        if (currentBladder < 0)
        {
            currentBladder = 0;
        } else if (currentBladder > maxBladder)
        {
            currentBladder = maxBladder;
        }
        
        bladder.SetBladder((currentBladder));
    }
    public void TakeDamageSleep(float damage)
    {
        currentSleep -= (damage * Time.deltaTime) * Random.Range(0.2f, 0.5f);
        if (currentSleep < 0)
        {
            currentSleep = 0;
        }
        else if (currentSleep > maxSleep)
        {
            currentSleep = maxSleep;
        }
        
        sleep.SetSleep((currentSleep));
    }

    public void TakeDamageHunger(float damage)
    {
        currentHunger -= (damage * Time.deltaTime) * Random.Range(0.5f, 1.1f);
        if (currentHunger < 0)
        {
            currentHunger = 0;
        }
        else if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
        
        hunger.SetHunger((currentHunger));
    }

    public void TakeDamageHygiene(float damage)
    {
        currentHygiene -= (damage * Time.deltaTime) * Random.Range(0.3f, 0.5f);
        if (currentHygiene < 0)
        {
            currentHygiene = 0;
        }
        else if (currentHygiene > maxHygiene)
        {
            currentHygiene = maxHygiene;
        }
        
        hygiene.SetHygiene((currentHygiene));
    }

    public void TakeDamageSocial(float damage)
    {
        currentSocial -= (damage * Time.deltaTime) * Random.Range(0.4f, 0.7f);

        if (currentSocial < 0)
        {
            currentSocial = 0;
        }
        else if (currentSocial > maxSocial)
        {
            currentSocial = maxSocial;
        }

        social.SetSocial((currentSocial));
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        if(PlayerPrefs.HasKey("PositionX") && PlayerPrefs.HasKey("PositionY"))
        {
            PlayerPrefs.SetFloat("PositionX", 0f);
            PlayerPrefs.SetFloat("PositionY", 0f);
        }
        if (PlayerPrefs.HasKey("GemAmount"))
        {
            PlayerPrefs.SetInt("GemAmount", 0);
        }
        if (PlayerPrefs.HasKey("DifficultyLevel"))
        {
            PlayerPrefs.SetInt("DifficultyLevel", 2);
        }
        sNav.FadeToLevel(3);
    }

    void ZeroHygiene()
    {
        currentHygiene = 0;
        currentBladder = 100;
        hygiene.SetHygiene(currentHygiene);
        bladder.SetBladder(currentBladder);
    }

}