using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager instance;
    [SerializeField] private Image bgImage;
    [SerializeField] private Image pondImage;
    [SerializeField] private Sprite[] bgSprite;
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
        bgImage.sprite = bgSprite[i];
        pondImage.sprite = bgSprite[i];
    }
}
