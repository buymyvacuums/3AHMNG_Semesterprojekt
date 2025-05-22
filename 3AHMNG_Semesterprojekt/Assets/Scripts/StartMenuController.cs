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
        TutorialManager.tutorialIndex = 0;
        SceneManager.LoadScene("Main"); // replace with your main game scene name
    }

    public void OnNewGame()
    {
        //SaveManager.DeleteSave();
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
