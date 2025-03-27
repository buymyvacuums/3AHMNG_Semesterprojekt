using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public ComboScroller theScroller;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int hitNote;
    public int missedNote;

    public float _rndStartTime;


    public GameObject _fishTXT, _wellDoneTXT;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
        //_fishTXT.gameObject.SetActive(false);
        //_failedTXT.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);

        
    }

    public void NoteHit()
    {
        hitNote += 1;
        Debug.Log("Hit on Time");
        currentScore += scorePerNote;
    }

    public void NoteMissed()
    {
        missedNote += 1;
        Debug.Log("Missed Note");
    }

    public IEnumerator Wait()
    {
        missedNote = 0;
        hitNote = 0;
        _rndStartTime = Random.Range(1f, 6f);
        //Start Waiting Sound
        yield return new WaitForSeconds(_rndStartTime);
        
        _fishTXT.gameObject.SetActive(true);
        // Start bite sound + Stop Waiting Sound
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Fishing_Rythm");
    }

    }
