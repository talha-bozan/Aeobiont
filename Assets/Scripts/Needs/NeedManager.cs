using System.Globalization;
using UnityEngine;

public class NeedManager : MonoBehaviour
{
    public Need bladder;
    public Need sleep;
    public Need hunger;
    public Need hygiene;
    public Need social;
    public Need friendly;
    public Need romance;

    [SerializeField] private Gem gem;
    public enum NeedType
    {
        bladder,
        sleep,
        hunger,
        social,
        hygiene,
        romance,
        friendly
    }

    public int difficultyLevel;
    [SerializeField] private SceneNavigator sNav;

    private void Awake()
    {
        Application.targetFrameRate = 1000;
    }
    void Start()
    {
        difficultyLevel = PlayerPrefs.GetInt("DifficultyLevel", 2);


        bladder.SetMaxValue(bladder.GetMaxValue());
        sleep.SetMaxValue(bladder.GetMaxValue());
        hunger.SetMaxValue(bladder.GetMaxValue());
        hygiene.SetMaxValue(bladder.GetMaxValue());
        social.SetMaxValue(bladder.GetMaxValue());
        
    }

    void Update()
    {
        UpdateNeed(bladder, difficultyLevel * 0.5f);
        UpdateNeed(sleep, difficultyLevel * 0.5f);
        UpdateNeed(hunger, difficultyLevel * 0.5f);
        UpdateNeed(hygiene, difficultyLevel * 0.5f);
        UpdateNeed(social, difficultyLevel * 0.5f);
        Debug.Log(difficultyLevel);
        
        CheckGameOver();
    }

    public void UpdateNeed(Need need, float decayRate)
    {
        float damage = decayRate * Time.deltaTime * Random.Range(0.7f, 1.1f);
        need.SetValue(need.GetValue() - damage);  
    }

    void CheckGameOver()
    {
        if (hunger.GetValue() <= 0 || bladder.GetValue() <= 0)
        {
            Debug.Log(hunger.GetValue());
            GameOver();
        }
    }

    void GameOver()
    {
        //Debug.Log("Game Over!");
        sNav.FadeToLevel(3);
    }

    public void IncreaseNeed(NeedType type, float amount)
    {
        switch (type)
        {
            case NeedType.bladder:
                bladder.IncreaseValue(amount);
                break;
            case NeedType.sleep:
                sleep.IncreaseValue(amount);
                break;
            case NeedType.hunger:
                hunger.IncreaseValue(amount);
                break;
            case NeedType.social:
                social.IncreaseValue(amount);
                break;
            case NeedType.hygiene:
                hygiene.IncreaseValue(amount);
                break;
            default:
                Debug.LogWarning("Unhandled need type: " + type);
                break;
        }
    }

    public void ResetNeed(NeedType type)
    {
        switch (type)
        {
            case NeedType.bladder:
                bladder.ResetValue();
                break;
            case NeedType.sleep:
                sleep.ResetValue();
                break;
            case NeedType.hunger:
                hunger.ResetValue();
                break;
            case NeedType.social:
                social.ResetValue();
                break;
            case NeedType.hygiene:
                hygiene.ResetValue();
                break;
            default:
                Debug.LogWarning("Unhandled need type: " + type);
                break;
        }
    }

    public void InterpolateNeed(NeedType type, float interpolationFactor)
    {
        switch (type)
        {
            case NeedType.bladder:
                bladder.InterpolateValue(interpolationFactor);
                break;
            case NeedType.sleep:
                sleep.InterpolateValue(interpolationFactor);
                break;
            case NeedType.hunger:
                hunger.InterpolateValue(interpolationFactor);
                break;
            case NeedType.social:
                social.InterpolateValue(interpolationFactor);
                break;
            case NeedType.hygiene:
                hygiene.InterpolateValue(interpolationFactor);
                break;
            default:
                Debug.LogWarning("Unhandled need type: " + type);
                break;
        }
    }

    public void SetFriendly(float value)
    {
        friendly.SetValue(value);
    }
    public void SetRomance(float value)
    {
        romance.SetValue(value);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fridge"))
        {
            if (gem.getBalance() >= 20)
            {
                SoundManager.playSound("fridge_open");
                gem.changeBalance(-20);
                InterpolateNeed(NeedManager.NeedType.hunger, 0.7f);
            }
            else
            {
                Debug.Log("You don't have enough money to eat; you should go to the farm.");
            }
        }
        else if (other.CompareTag("Toilet"))
        {
            SoundManager.playSound("toilet_flush");
            ResetNeed(NeedManager.NeedType.bladder);
        }
        else if (other.CompareTag("Shower"))
        {
            SoundManager.playSound("sink_wash");
            InterpolateNeed(NeedManager.NeedType.hygiene, 0.7f);
        }
        else if (other.CompareTag("Bed"))
        {
            ResetNeed(NeedManager.NeedType.sleep);

        }
    }
}
