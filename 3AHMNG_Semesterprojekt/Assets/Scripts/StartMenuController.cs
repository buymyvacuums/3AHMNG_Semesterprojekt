using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void OnContinue()
    {
        //SaveManager.LoadGame();
        SceneManager.LoadScene("Main"); // replace with your main game scene name
    }

    public void OnNewGame()
    {
        //SaveManager.DeleteSave();
        GameManager.instance?.ResetAll();
        PlayerPrefs.DeleteAll(); 
        SceneManager.LoadScene("Main");
    }

    public void OnCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
    public void OnStart()
    {
        SceneManager.LoadScene("Start");
    }
}
