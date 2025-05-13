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
    [SerializeField] public AK.Wwise.Event _akWalkLoop;
    [SerializeField] public AK.Wwise.Event _akShredderLoop;
    [SerializeField] public AK.Wwise.Event _akShredderActivate;
    [SerializeField] private AK.Wwise.RTPC _akPWalk;

    [SerializeField] private AK.Wwise.Event _spaceMusic;

    private void Awake()
    {
        if (instance == null)
        {  instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        
    }

    private void Start()
    {
       PlaySound(_akWalkLoop);
        PlaySound(_spaceMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AK.Wwise.Event sound) { sound?.Post(this.gameObject); }

    public void PlaySoundFrom(AK.Wwise.Event sound, GameObject GO) { sound?.Post(GO.gameObject); }
    public void WalkSounds(float value)
    {
        _akPWalk.SetValue(gameObject, value);
    }

}
