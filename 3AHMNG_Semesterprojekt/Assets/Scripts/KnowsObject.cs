using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KnowsObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    private GameObject button;

    private int points;
    private string feedbackTXT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving
        transform.position -= new Vector3(0f, ComboScroller._ComboInstance.beatTempo * Time.deltaTime, 0f);


        if (Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                Destroy(gameObject);
                GameManager.instance.NoteHit(button?.GetComponent<ButtonController>().hitSound, points, feedbackTXT);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Activator")
        {
            float distance = Vector2.Distance(other.gameObject.transform.position, gameObject.transform.position);
            Debug.Log(distance);
            if (distance <= 0.50f)
            {
                points = 1;
                feedbackTXT = "ok...";
            }
            if (distance <= 0.25f)
            {
                points = 3;
                feedbackTXT = "great";
            }
            if (distance <= 0.05f)
            {
                points = 5;
                feedbackTXT = "perfect!";
            }
            
            canBePressed = true;
            button = other.gameObject;
        }
        //else if (other.gameObject.tag == "MissZone")
        //{
        //    Destroy(gameObject);
        //    GameManager.instance.NoteMissed();
        //}
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Activator")
        {
            canBePressed = false;
            StartCoroutine(MissedNote());
        }

    }
    private IEnumerator MissedNote()
    {
        yield return null;
        GameManager.instance.NoteMissed();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
