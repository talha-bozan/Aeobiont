using UnityEngine;

public class NeedManager : MonoBehaviour
{
    public Need bladder;
    public Need sleep;
    public Need hunger;
    public Need hygiene;
    public Need social;

    public float maxBladder = 100, currentBladder = 100;
    public float maxSleep = 100, currentSleep = 100;
    public float maxHunger = 100, currentHunger = 100;
    public float maxHygiene = 100, currentHygiene = 100;
    public float maxSocial = 100, currentSocial = 100;

    public int difficultyLevel;
    [SerializeField] private SceneNavigator sNav;

    void Start()
    {
        bladder.SetMaxValue(maxBladder);
        sleep.SetMaxValue(maxSleep);
        hunger.SetMaxValue(maxHunger);
        hygiene.SetMaxValue(maxHygiene);
        social.SetMaxValue(maxSocial);
        Debug.Log(currentHunger);
        Debug.Log(currentBladder);
    }

    void Update()
    {
        UpdateNeed(bladder, difficultyLevel * 0.5f);
        UpdateNeed(sleep, difficultyLevel * 0.5f);
        UpdateNeed(hunger, difficultyLevel * 0.5f);
        UpdateNeed(hygiene, difficultyLevel * 0.5f);
        UpdateNeed(social, difficultyLevel * 0.5f);
        
        CheckGameOver();
    }

    void UpdateNeed(Need need, float decayRate)
    {
        float damage = decayRate * Time.deltaTime * Random.Range(0.7f, 1.1f);
        need.SetValue(need.slider.value - damage);

    }

    void CheckGameOver()
    {
        if (currentHunger <= 0 || currentBladder <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        //Debug.Log("Game Over!");
        sNav.FadeToLevel(3);
    }
}
