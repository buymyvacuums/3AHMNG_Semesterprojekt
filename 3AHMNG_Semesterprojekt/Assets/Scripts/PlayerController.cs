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

    public static PlayerController instance;

    [SerializeField] private LayerMask fishArea;
    [SerializeField] public GameObject _interactTXT;
    [SerializeField] public GameObject _fishBitTXT;
    [SerializeField] private GameObject _fishingOBJ;
    [SerializeField] private GameObject _cameraPos;
    [SerializeField] private Camera _camera;
    private CameraSmoothness _cameraScp;

    // Use this for initialization
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        _interactTXT.SetActive(false);
        _cameraScp = _camera.GetComponent<CameraSmoothness>();
        
    }

    //IEnumerator StartFishing()
    //{
    //    transform.position = new Vector3(17, -1.2f, -0.5f);
    //    _interactTXT.SetActive(false);
    //    _cameraScp.enabled = false;
    //    _camera.transform.position = _cameraPos.transform.position;
    //    _camera.transform.rotation = Quaternion.Euler(90, 0, 0);
    //    yield return null;
    //}

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
                GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akThrow);
                StartCoroutine(GameManager.instance.Wait());
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
        if (Input.GetAxisRaw("Horizontal") > 0) { transform.localScale = new Vector3(-3.5f, transform.localScale.y, transform.localScale.z); }
        else if (Input.GetAxisRaw("Horizontal") < 0) { transform.localScale = new Vector3(3.5f, transform.localScale.y, transform.localScale.z); }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            GlobalAudioScript.instance.WalkSounds(1);
        }
        else { GlobalAudioScript.instance.WalkSounds(0); }
    }


}
