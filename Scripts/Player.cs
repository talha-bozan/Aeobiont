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
        TakeDamageBladder(1);
        TakeDamageSleep(1);
        TakeDamageHunger(1);
        TakeDamageHygiene(1);
        TakeDamageSocial(1);


        if (currentHunger <= 0)
        {
            GameOver();

        }

        if (currentBladder <= 0)
        {
            ZeroHygiene();
        }

    }

    public void TakeDamageBladder(int damage)
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
    public void TakeDamageSleep(int damage)
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

    public void TakeDamageHunger(int damage)
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

    public void TakeDamageHygiene(int damage)
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

    public void TakeDamageSocial(int damage)
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
    }

    void ZeroHygiene()
    {
        currentHygiene = 0;
        currentBladder = 100;
        hygiene.SetHygiene(currentHygiene);
        bladder.SetBladder(currentBladder);
    }

}