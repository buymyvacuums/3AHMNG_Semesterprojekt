using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    [SerializeField] private TextMeshProUGUI tutorialUI;
    [SerializeField] private string[] tutText;
    [SerializeField] private GameObject tutorialCanvas;
    public int tutorialIndex;
    public bool tutorialActive = true;
    private void Awake()
    {

    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        tutorialIndex = 0;
        tutorialActive = true;
        tutorialCanvas = GameObject.FindGameObjectWithTag("Tutorial");
        tutorialUI = tutorialCanvas?.GetComponentInChildren<TextMeshProUGUI>();
        tutorialCanvas?.SetActive(true);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Update()
    {
        if (tutorialActive)
        {
            if (tutorialIndex <= 7)
            {
                tutorialUI.text = tutText[tutorialIndex];
            }
            if (tutorialIndex == 0 || tutorialIndex == 1 || tutorialIndex == 2 || tutorialIndex == 5 || tutorialIndex == 7)
            {
                tutorialUI.text = tutText[tutorialIndex] + "\n[Space]";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tutorialIndex++;

                }
            }
            if (tutorialIndex >= 8)
            {
                tutorialActive = false;
                tutorialCanvas.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                tutorialActive = false;
                tutorialCanvas.SetActive(false);
            }
        }
        
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Main")
        {
            tutorialCanvas = GameObject.FindGameObjectWithTag("Tutorial");
            tutorialUI = tutorialCanvas.GetComponentInChildren<TextMeshProUGUI>();
            if (tutorialActive == false) { tutorialCanvas.SetActive(false); }

        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void ResetTutorial()
    {
        tutorialIndex = 0;
        tutorialCanvas?.SetActive(true);
        tutorialActive = true;
    }
}
