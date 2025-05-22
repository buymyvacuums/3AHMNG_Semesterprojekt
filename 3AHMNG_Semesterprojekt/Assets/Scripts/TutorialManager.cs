using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialUI;
    [SerializeField] private string[] tutText;
    [SerializeField] private GameObject tutorialCanvas;
    public static int tutorialIndex = 0;
    private void Awake()
    {

    }
    private void Start()
    {
        tutorialCanvas = GameObject.FindGameObjectWithTag("Tutorial");
        tutorialUI = tutorialCanvas.GetComponentInChildren<TextMeshProUGUI>();
        tutorialCanvas.SetActive(true);

        //SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Update()
    {
        tutorialUI.text = tutText[tutorialIndex];
        if (tutorialIndex == 0 || tutorialIndex == 1 || tutorialIndex == 2 || tutorialIndex == 5 || tutorialIndex == 7)
        {
            tutorialUI.text = tutText[tutorialIndex] + "\n[Space]";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialIndex++;
                if (tutorialIndex == 8)
                {
                    Destroy(tutorialCanvas);
                    Destroy(gameObject);
                }
            }
        }
    }
    //private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    //{
    //    if (scene.name == "Main")
    //    {
    //        tutorialCanvas = GameObject.FindGameObjectWithTag("Tutorial");
    //        tutorialUI = tutorialCanvas.GetComponentInChildren<TextMeshProUGUI>();
    //        if (tutorialCanvas != null)
    //        {
    //            tutorialUI.text = tutText[i];
    //        }
    //    }
    //}

    //private void OnDestroy()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}
}
