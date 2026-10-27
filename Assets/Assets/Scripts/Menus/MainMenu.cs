using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OptionsClose()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void CloseGame()
    {
         Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }


}
