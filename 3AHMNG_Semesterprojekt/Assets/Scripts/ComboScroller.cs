using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComboScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    [SerializeField] private GameObject _failTXT, _wonTXT;


    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        
        _failTXT.SetActive(false);
        _wonTXT.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //if(!hasStarted)
        //{
        //    if (Input.anyKeyDown)
        //    {
        //        //_pressTXT.SetActive(false);
        //        //_goTXT.gameObject.SetActive(true);
        //        //StartCoroutine(GameManager.instance.Wait());
        //        //gameObject.SetActive(true);
        //        //hasStarted = true;
        //    }
        //}
        
        
        transform.position -= new Vector3 (0f, beatTempo * Time.deltaTime, 0f);
        
        //if(GameManager.instance.currentScore == 500)
        //{
        //    SceneManager.LoadScene("Main");
        //}

        if(GameManager.instance.missedNote + GameManager.instance.hitNote == 10)
        {
            if(GameManager.instance.missedNote > 0)
            {
                StartCoroutine(FishFailed());
            }
            else
            {
                StartCoroutine(EndFishing());
            }
        }
    }

    IEnumerator EndFishing()
    {
        _wonTXT.gameObject.SetActive(true);
        //Play Victory Sound?
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main");
    }

    IEnumerator FishFailed()
    {
        _failTXT.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main");
    }
}
