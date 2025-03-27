using System.Collections;
using System.Collections.Generic;
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
        PlayerController.instance._interactTXT.SetActive(false);
        missedNote = 0;
        hitNote = 0;
        _rndStartTime = Random.Range(1f, 6f);
        //Start Waiting Sound
        yield return new WaitForSeconds(_rndStartTime);
        
        PlayerController.instance._fishBitTXT.gameObject.SetActive(true);
        // Start bite sound + Stop Waiting Sound
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Fishing_Rythm");
    }

    }
