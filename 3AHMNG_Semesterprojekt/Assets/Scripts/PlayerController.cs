using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 150f;
    public Rigidbody rb;

    [SerializeField] private LayerMask fishArea;
    [SerializeField] private GameObject _interactTXT;
    [SerializeField] private GameObject _exitTXT;
    [SerializeField] private GameObject _fishingOBJ;
    [SerializeField] private GameObject _cameraPos;
    [SerializeField] private Camera _camera;
    private CameraSmoothness _cameraScp;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _interactTXT.SetActive(false);
        _exitTXT.SetActive(false);
        //_camera = GetComponent<Camera>();
        _cameraScp = _camera.GetComponent<CameraSmoothness>();
    }

    IEnumerator StartFishing()
    {
        transform.position = new Vector3(17, -1.2f, -0.5f);
        _interactTXT.SetActive(false);
        _exitTXT.SetActive(true);
        _cameraScp.enabled = false;
        _camera.transform.position = _cameraPos.transform.position;
        _camera.transform.rotation = Quaternion.Euler(90, 0, 0);
        yield return null;
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
            if(Input.GetKeyDown(KeyCode.E) ) 
            {
                StartCoroutine(StartFishing());
                
            }
        }
        else
        {
            _interactTXT.SetActive(false);
        }
    }

    //_exitTXT.SetActive(false);
    //_cameraScp.enabled = true;
    //_camera.transform.position = new Vector3(0, 13.7f, -32.8f);
    //_camera.transform.rotation = Quaternion.Euler(23, 0, 0);

    void FixedUpdate()
    {
        //Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = movement * speed * Time.fixedDeltaTime;
    }


}
