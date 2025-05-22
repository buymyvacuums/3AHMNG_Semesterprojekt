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
    public int i = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }
    private void Start()
    {
        tutorialCanvas = GameObject.FindGameObjectWithTag("Tutorial");
        tutorialUI = tutorialCanvas.GetComponentInChildren<TextMeshProUGUI>();
        tutorialCanvas.SetActive(true);
        tutorialUI.text = tutText[i];

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Update()
    {
        tutorialUI.text = tutText[i];
        if (i == 0 || i == 1 || i == 2 || i == 5 || i == 7)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                i++;
                if (i == 8)
                {
                    Destroy(tutorialCanvas);
                    Destroy(gameObject);
                }
            }
        }
        



        //    for (int i = 0; i < popUps.Length; i++)
        //    {
        //        if(i == popUpIndex)
        //        {
        //            popUps[i].SetActive(true);
        //        }
        //        else
        //        {
        //            popUps[i].SetActive(false);
        //        }
        //    }

        //    if(popUpIndex == 0)
        //    {
        //        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A))
        //        {
        //            popUpIndex++;
        //        }
        //    }
        //    else if(popUpIndex == 1)
        //    {
        //        if(Input.GetKeyDown(KeyCode.E))
        //        {
        //            popUpIndex++;
        //        }
        //    }
        //    else if (popUpIndex == 2)
        //    {
        //        if (GameManager.instance.currentScore == 1)
        //        {
        //            popUpIndex++;
        //        }
        //    }
        //    else if (popUpIndex == 3)
        //    {
        //        if (GameManager.instance.currentValue == 1)
        //        {
        //            popUpIndex++;
        //        }
        //    }
        //    else if (popUpIndex == 4)
        //    {
        //        if (GameManager.instance.fishBits == 1)
        //        {
        //            popUpIndex++;
        //        }
        //    }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Main")
        {
            tutorialCanvas = GameObject.FindGameObjectWithTag("Tutorial");
            tutorialUI = tutorialCanvas.GetComponentInChildren<TextMeshProUGUI>();
            if (tutorialCanvas != null)
            {
                tutorialUI.text = tutText[i];
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
