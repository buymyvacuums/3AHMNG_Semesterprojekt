using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialUI;
    [SerializeField] private string[] tutText;
    [SerializeField] private GameObject tutorialCanvas;
    private int i = 0;

    private void Start()
    {
        tutorialCanvas.SetActive(true);
        tutorialUI.text = tutText[0];
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            i++;
            tutorialUI.text = tutText[i];
            if (i == 3) { }
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

    public void 
}
