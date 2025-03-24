using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    [SerializeField] private GameObject _3TXT, _2TXT, _1TXT, _goTXT;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        _1TXT.SetActive(false);
        _2TXT.SetActive(false);
        _3TXT.SetActive(false);
        _goTXT.SetActive(false);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            StartCoroutine(StartFishing());
        }

        //if(!hasStarted)
        //{
        //    if (Input.anyKeyDown)
        //    {
        //        hasStarted = true;
        //    }
        //}
        //else
        //{
        //    transform.position -= new Vector3 (0f, beatTempo * Time.deltaTime, 0f);
        //}
    }

    IEnumerator StartFishing()
    {
        yield return new WaitForSeconds (1);
    }
}
