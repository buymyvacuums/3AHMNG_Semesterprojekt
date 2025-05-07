using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager instance;
    public Sprite[] bgSprite;
    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackground(int i)
    {
        GameObject[] bgImage = GameObject.FindGameObjectsWithTag("Space");
        foreach (var GO in bgImage)
        {
            Image bgImageComp = GO.GetComponent<Image>();
            bgImageComp.sprite = bgSprite[i];
        }
    }
}
