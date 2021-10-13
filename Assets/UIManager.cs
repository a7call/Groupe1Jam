using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : Singleton<UIManager>
{
    public GameObject MainMenuPanel;
    public GameObject PlayerPanel;
    public GameObject DeathMenu;
    public void Play()
    {
        MainMenuPanel.SetActive(false);
        PlayerPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        DeathMenu.SetActive(false);
        PlayerPanel.SetActive(true);
        PlayerHealthHandler.GetInstance().SetMaxHealth();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        DeathMenu.SetActive(false);
        MainMenuPanel.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
