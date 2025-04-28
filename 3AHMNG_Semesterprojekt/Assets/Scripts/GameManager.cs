using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public static GameManager instance;

    public int currentScore;
    
    public int scorePerNote = 100;
    public int hitNote;
    public int missedNote;

    public float _rndStartTime;

    public int fishCode;

    public GameObject _wellDoneTXT;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Debug.LogWarning("Multiple instances of " + instance.GetType().Name + " #1", gameObject);
            //Debug.LogWarning("Destroyed " + this.gameObject.name + " because there must only be one " + instance.GetType().Name);
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        FishBehaviour._instance.galaxy = Galaxy.Tutoria;
        
        
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

    public IEnumerator Wait()
    {
        fishCode = 0;

        if (FishBehaviour._instance.galaxy == Galaxy.Tutoria)
        {
            fishCode = Random.Range(1, 4);
            Debug.Log("Set fishCode to: " + fishCode);  // Debug log here
        }
        if (FishBehaviour._instance.galaxy == Galaxy.Prehistoria)
        {
            fishCode = Random.Range(4, 10);
            Debug.Log("Set fishCode to: " + fishCode);  // Debug log here
        }
        if (FishBehaviour._instance.galaxy == Galaxy.Biologica)
        {
            fishCode = Random.Range(10, 17);
            Debug.Log("Set fishCode to: " + fishCode);  // Debug log here
        }
        if (FishBehaviour._instance.galaxy == Galaxy.Galaxia)
        {
            fishCode = Random.Range(17, 25);
            Debug.Log("Set fishCode to: " + fishCode);  // Debug log here
        }

        PlayerController.instance._interactTXT.SetActive(false);
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
