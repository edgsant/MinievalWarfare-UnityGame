using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject tutorialMenu;
    public static bool gamePaused = false;


    void Start()
    {
        //ShowTutorial();
    }

    private void OnApplicationPause(bool pause)
    {

    }

    public void ShowTutorial()
    {
        tutorialMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        AudioManager.Instance.PauseMusic(gamePaused);
    }

    public void CloseTutorial()
    {
        tutorialMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        AudioManager.Instance.PauseMusic(gamePaused);
    }
}
