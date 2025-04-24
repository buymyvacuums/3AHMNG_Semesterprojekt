using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioScript : MonoBehaviour
{
    public static GlobalAudioScript instance;
    [SerializeField] public AK.Wwise.Event _akThrow;
    [SerializeField] public AK.Wwise.Event _akBite;
    [SerializeField] public AK.Wwise.Event _akReel;
    [SerializeField] public AK.Wwise.Event _akFail;
    [SerializeField] public AK.Wwise.Event _akSuccess;

    private void Awake()
    {
        if (instance == null)
        {  instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AK.Wwise.Event sound) { sound?.Post(gameObject); }

}
