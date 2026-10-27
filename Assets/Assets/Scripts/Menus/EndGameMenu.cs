using UnityEngine;

public class EndGameMenu : MonoBehaviour
{

    public GameObject endGameMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showEndGameMenu()
    {
        endGameMenu.SetActive(true);
    }

    public void closeEndGameMenu()
    {
        endGameMenu.SetActive(false);
    }
}
