using UnityEngine;

public class MainMenuStarter : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false); 
    }

    
}
