using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public static bool gamePaused = false;
    private InputAction playerMenuAction;


    void Start()
    {
        pauseMenu.SetActive(false);
        playerMenuAction = InputSystem.actions.FindAction("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMenuAction.WasPressedThisFrame())
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        AudioManager.Instance.PauseMusic(gamePaused);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
        gamePaused = false;
        AudioManager.Instance.PauseMusic(gamePaused);
    }

    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void closePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void showSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void closeSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
