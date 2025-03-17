using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowsObject : MonoBehaviour
{
    public bool canBePressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.gameObject.tag == "Activator")
    //    {
    //        canBePressed = true;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Activator")
        {
            canBePressed = false;
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
