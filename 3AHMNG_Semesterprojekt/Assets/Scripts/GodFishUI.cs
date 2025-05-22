using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodFishUI : MonoBehaviour
{
    [SerializeField] private Image kingOssisImg;
    [SerializeField] private Image queenVitaeImg;
    [SerializeField] private Image ultranovaImg;
    [SerializeField] private GameObject FinishUI;
    // Start is called before the first frame update
    public void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.KingOssisCaught) { kingOssisImg.color = Color.white; }
            if (GameManager.instance.QueenVitaeCaught) { queenVitaeImg.color = Color.white; }
            if (GameManager.instance.UltranovaCaught) { ultranovaImg.color = Color.white; }

            if (GameManager.instance.AllGodsCaught())
            {
                FinishUI.SetActive(true);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(FishBehaviour._instance.HasCaughtFish(9));

    }


}
