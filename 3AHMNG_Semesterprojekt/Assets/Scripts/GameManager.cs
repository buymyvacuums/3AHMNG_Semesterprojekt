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

    //God fish collection
    public bool _godCheck = false;
    public int _god = 0;

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
    }


    // Update is called once per frame
    void Update()
    {
        
        //GALAXY SWITCHER
        if (FishBehaviour.galaxy == Galaxy.Tutoria)
        {
            BackgroundManager.instance.ChangeBackground(0);
            Debug.Log("Galaxy: Tutoria");
        }
        if (FishBehaviour.galaxy == Galaxy.Prehistoria)
        {
            BackgroundManager.instance.ChangeBackground(1);
            Debug.Log("Galaxy: Prehistoria");
        }
        if (FishBehaviour.galaxy == Galaxy.Biologica)
        {
            BackgroundManager.instance.ChangeBackground(2);
            Debug.Log("Galaxy: Biologica");
        }
        if (FishBehaviour.galaxy == Galaxy.Galaxia)
        {
            BackgroundManager.instance.ChangeBackground(3);
            Debug.Log("Galaxy: Galaxia");
        }
    }

    public void NoteHit()
    {
        hitNote += 1;
        Debug.Log("Hit on Time");
        
    }

    public void NoteMissed()
    {
        missedNote += 1;
        Debug.Log("Missed Note");
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
            bool isGodFish = FishBehaviour._instance.fishDictionary[i]._difficulty == Difficulty.God;
            bool alreadyCaught = FishBehaviour._instance.HasCaughtFish(i);

            if (!isGodFish || !alreadyCaught)
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
                fishCode = possibleFish[Random.Range(0, possibleFish.Count)];
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
        
        //Start Waiting Sound
        yield return new WaitForSeconds(_rndStartTime);
        PlayerController.instance._fishBitTXT.gameObject.SetActive(true);

        // Start bite sound + Stop Waiting Sound
        GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akBite);
        
        yield return new WaitForSeconds(0.3f);
        GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akReel);
        SceneManager.LoadScene("Fishing_Rythm");
    }

    

}


