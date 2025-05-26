using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //FISH VARIBLES
    public int currentScore = 0;
    public int currentValue = 0;
    public int fishBits = 0;
    
    //Rythm stuff
    public int scorePerNote = 100;
    public int hitNote;
    public int missedNote;

    public float _rndStartTime;

    public int fishCode;

    public GameObject _wellDoneTXT;

    private static bool _initialized = false;

    //God fish 
    public bool KingOssisCaught = false;
    public bool QueenVitaeCaught = false;
    public bool UltranovaCaught = false;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (!_initialized)
            {
                FishBehaviour.galaxy = Galaxy.Tutoria;
                _initialized = true;
            }
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {

    }


    // Update is called once per frame
    void Update()
    {
        BackgroundManager.instance.ChangeBackground();
        if (LightChanger.instance != null)
        {
            LightChanger.instance.ChangeLighting();
        }
    }

    public void NoteHit(AK.Wwise.Event hitSound)
    {
        hitNote += 1;
        GlobalAudioScript.instance.PlaySound(hitSound);
        StartCoroutine(ComboFeedback.instance.PerfectHit(ComboFeedback.instance.perfectTXT));
        //Debug.Log("Note Hit");
    }

    public void NoteMissed()
    {
        missedNote += 1;
        StartCoroutine(ComboFeedback.instance.PerfectHit(ComboFeedback.instance.missTXT));
        //Debug.Log("Note Missed");
    }

    private List<int> GetFishPoolForGalaxy(Galaxy galaxy)
    {
        List<int> pool = new List<int>();

        int start = 1, end = 3;

        switch (galaxy)
        {
            case Galaxy.Tutoria: start = 1; end = 3; break;
            case Galaxy.Prehistoria: start = 4; end = 9; break;
            case Galaxy.Biologica: start = 10; end = 16; break;
            case Galaxy.Galaxia: start = 17; end = 24; break;
        }

        for (int i = start; i <= end; i++)
        {
                pool.Add(i);
        }

        return pool;
    }


    public IEnumerator Wait()
    {
        fishCode = 0;

        if (FishBehaviour.galaxy == Galaxy.Tutoria)
        {
            fishCode = Random.Range(1, 4); // Leave unchanged if no God Fish in Tutoria
        }
        else
        {
            List<int> possibleFish = GetFishPoolForGalaxy(FishBehaviour.galaxy);
            if (possibleFish.Count > 0)
            {
                while (true)
                {
                    fishCode = possibleFish[Random.Range(0, possibleFish.Count)];
                    Debug.Log(fishCode);
                    if (fishCode == 9 && KingOssisCaught) { continue; }
                    if (fishCode == 16 && QueenVitaeCaught) { continue; }
                    if (fishCode == 24 && UltranovaCaught) { continue; }
                    else { break; }
                }

            }
            else
            {
                Debug.LogWarning("No fish available in this galaxy!");
                yield break;
            }
        }

        missedNote = 0;
        hitNote = 0;
        _rndStartTime = Random.Range(1f, 6f);
        PlayerController.instance._interactTXT.SetActive(false);

        //Start Waiting Sound
        yield return new WaitForSeconds(_rndStartTime);
        PlayerController.instance._fishBitTXT.gameObject.SetActive(true);

        // Start bite sound + Stop Waiting Sound
        GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akBite);
        
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Fishing_Rythm");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    public bool AllGodsCaught()
    {
        if (KingOssisCaught && QueenVitaeCaught && UltranovaCaught) { return true; }
        return false;
    }
    
    public void ResetAll()
    {
        currentScore = 0;   
        currentValue = 0;
        fishBits = 0;
        KingOssisCaught = false;
        QueenVitaeCaught = false;
        UltranovaCaught = false;
        FishBehaviour.galaxy = Galaxy.Tutoria;
    }

}


