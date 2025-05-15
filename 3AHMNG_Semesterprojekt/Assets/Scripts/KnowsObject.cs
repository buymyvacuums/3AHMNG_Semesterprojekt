using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowsObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

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

                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Activator")
        {
            canBePressed = true;
        }
        else if (other.gameObject.tag == "MissZone")
        {
            Destroy(gameObject);
            GameManager.instance.NoteMissed();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Activator")
        {
            canBePressed = false;
        }

    }
}
