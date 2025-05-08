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

        FishBehaviour._instance.galaxy = Galaxy.Tutoria;

    }


    // Update is called once per frame
    void Update()
    {
        
        //GALAXY TESTER
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FishBehaviour._instance.galaxy = Galaxy.Tutoria;
            BackgroundManager.instance.ChangeBackground(0);
            Debug.Log("Galaxy: Tutoria");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FishBehaviour._instance.galaxy = Galaxy.Prehistoria;
            BackgroundManager.instance.ChangeBackground(1);
            Debug.Log("Galaxy: Prehistoria");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FishBehaviour._instance.galaxy = Galaxy.Biologica;
            BackgroundManager.instance.ChangeBackground(2);
            Debug.Log("Galaxy: Biologica");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FishBehaviour._instance.galaxy = Galaxy.Galaxia;
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
            if(FishBehaviour._instance.HasCaughtFish(9))
            {
                Debug.Log("GOTT IST TOT");
                fishCode = Random.Range(4, 9);
                Debug.Log("Set fishCode to: " + fishCode);
            }

            else
            {
                fishCode = Random.Range(4, 10);
                Debug.Log("Set fishCode to: " + fishCode);
            }
        }
        if (FishBehaviour._instance.galaxy == Galaxy.Biologica)
        {
            if (FishBehaviour._instance.HasCaughtFish(16) == false)
            {
                fishCode = Random.Range(10, 17);
                Debug.Log("Set fishCode to: " + fishCode);
            }

            else if (FishBehaviour._instance.HasCaughtFish(16))
            {
                fishCode = Random.Range(10, 16);
                Debug.Log("Set fishCode to: " + fishCode);
            }
        }
        if (FishBehaviour._instance.galaxy == Galaxy.Galaxia)
        {
            if (FishBehaviour._instance.HasCaughtFish(24) == false)
            {
                fishCode = Random.Range(17, 25);
                Debug.Log("Set fishCode to: " + fishCode);
            }

            else if (FishBehaviour._instance.HasCaughtFish(24))
            {
                fishCode = Random.Range(17, 24);
                Debug.Log("Set fishCode to: " + fishCode);
            }
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
