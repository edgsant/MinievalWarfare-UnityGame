using UnityEngine;

public class MainLevelStarter : MonoBehaviour
{
    public TutorialMenu tutorial;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject endGameMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorial.ShowTutorial();
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        endGameMenu.SetActive(false);
    }


}
