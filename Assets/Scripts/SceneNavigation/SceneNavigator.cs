using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private int requestedScene;

    public void FadeToLevel(int levelIndex)
    {
        Time.timeScale = 1f;
        requestedScene = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (requestedScene == 7)
            Application.Quit();
        else
            SceneManager.LoadScene(requestedScene);
    }

    public void openPauseMenu()
    {
        // LevelChanger -> Canvas -> PauseMenu
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0.001f;
    }

    public void closePauseMenu()
    {
        // LevelChanger -> Canvas -> PauseMenu
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

}
