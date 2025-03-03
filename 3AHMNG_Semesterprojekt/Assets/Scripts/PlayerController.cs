using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 150f;
    public Rigidbody rb;

    [SerializeField] private LayerMask fishArea;
    [SerializeField] private GameObject _interactTXT;
    [SerializeField] private GameObject _fishingOBJ;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _interactTXT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast-Fishing Area open
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = _fishingOBJ.transform.position - transform.position;
        float maxRayDistance = 3;
        RaycastHit rayHit;
        if(Physics.Raycast(rayOrigin, rayDirection, out rayHit, maxRayDistance, fishArea))
        {
            _interactTXT.SetActive(true);
            if(Input.GetKey(KeyCode.E) ) 
            {
                SceneManager.LoadScene("Fishing");
            }
        }
        else
        {
            _interactTXT.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        //Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = movement * speed * Time.fixedDeltaTime;
    }


}
