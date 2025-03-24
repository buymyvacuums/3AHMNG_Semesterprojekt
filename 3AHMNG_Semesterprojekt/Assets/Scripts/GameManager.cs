using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ComboScroller theScroller;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public GameObject _wellDoneTXT;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
        _wellDoneTXT.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore == 500)
        {
            StartCoroutine(EndFishing());
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");
        currentScore += scorePerNote;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }

    IEnumerator EndFishing()
    {
        _wellDoneTXT.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main");
    }
}
