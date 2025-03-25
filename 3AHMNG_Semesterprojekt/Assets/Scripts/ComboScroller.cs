using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    [SerializeField] private GameObject _goTXT, _combo, _pressTXT;

    public float _rndStartTime;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        
        _goTXT.SetActive(false);
        _combo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                _pressTXT.SetActive(false);
                //_goTXT.gameObject.SetActive(true);
                StartCoroutine(Wait());
                //gameObject.SetActive(true);
                //hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3 (0f, beatTempo * Time.deltaTime, 0f);
        }
    }

   IEnumerator Wait()
    {
        _rndStartTime = Random.Range(1f, 6f);
        _combo.gameObject.SetActive(false);
        yield return new WaitForSeconds(_rndStartTime);
        _goTXT.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _goTXT.gameObject.SetActive(false);
        _combo.gameObject.SetActive(true);
        hasStarted = true;
    }
}
