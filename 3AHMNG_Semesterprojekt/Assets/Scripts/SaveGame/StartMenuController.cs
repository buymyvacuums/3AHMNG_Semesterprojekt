using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        if (continueButton != null)
            continueButton.interactable = SaveManager.SaveExists();
    }

    public void OnContinue()
    {
        //SaveManager.LoadGame();
        SceneManager.LoadScene("Main"); // replace with your main game scene name
    }

    public void OnNewGame()
    {
        //SaveManager.DeleteSave();
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
}
