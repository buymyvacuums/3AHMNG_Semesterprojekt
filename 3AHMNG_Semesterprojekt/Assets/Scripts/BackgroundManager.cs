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

    public void ChangeBackground()
    {
        GameObject[] bgImage = GameObject.FindGameObjectsWithTag("Space");
        foreach (var GO in bgImage)
        {
            Image bgImageComp = GO.GetComponent<Image>();
            if (FishBehaviour.galaxy == Galaxy.Tutoria)
            {
                bgImageComp.sprite = bgSprite[0];
            }
            if (FishBehaviour.galaxy == Galaxy.Prehistoria)
            {
                bgImageComp.sprite = bgSprite[1];
            }
            if (FishBehaviour.galaxy == Galaxy.Biologica)
            {
                bgImageComp.sprite = bgSprite[2];
            }
            if (FishBehaviour.galaxy == Galaxy.Galaxia)
            {
                bgImageComp.sprite = bgSprite[3];
            }

        }
    }
}
