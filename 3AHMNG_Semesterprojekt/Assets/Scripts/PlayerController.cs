using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    public static PlayerController instance;
    [Header("Fish")]
    [SerializeField] private LayerMask fishArea;
    [SerializeField] private LayerMask fishHarvister;
    [SerializeField] private LayerMask fishUpgrade;
    [SerializeField] public GameObject _harvisterInteractTXT;
    [SerializeField] public GameObject _interactTXT;
    [SerializeField] public GameObject _upgradeInteractTXT;

    [SerializeField] public GameObject _fishBitTXT;
    [SerializeField] private GameObject _fishingOBJ;
    [SerializeField] private GameObject _harvisterOBJ;
    [SerializeField] private GameObject _upgradeOBJ;

    [SerializeField] private GameObject _upgradeUI;

    [SerializeField] private GameObject _cameraPos;
    [SerializeField] private Camera _camera;

    public Animator animator;
    public GameObject rodGO;
    private CameraSmoothness _cameraScp;

    enum PlayerState
    {
        Free,
        Fishing
    }

    private PlayerState _state;

    // Use this for initialization
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        _interactTXT.SetActive(false);
        _harvisterInteractTXT.SetActive(false);
        _upgradeUI.SetActive(false);
        _cameraScp = _camera.GetComponent<CameraSmoothness>();
        _state = PlayerState.Free;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (_state == PlayerState.Free)
        {
            //Raycast-Fishing Area open
            Vector3 rayOrigin = transform.position;
            Vector3 rayDirection = _fishingOBJ.transform.position - transform.position;
            float maxRayDistance = 3;
            RaycastHit rayHit;
            if (Physics.Raycast(rayOrigin, rayDirection, out rayHit, maxRayDistance, fishArea))
            {
                _interactTXT.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _state = PlayerState.Fishing;
                    GlobalAudioScript.instance.WalkSounds(0); animator.SetBool("isMoving", false);
                    animator.SetBool("isFishing", true);
                    rodGO.SetActive(true);
                    GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akThrow);
                    StartCoroutine(GameManager.instance.Wait());
                }
            }
            else
            {
                _interactTXT.SetActive(false);
            }
        }

        //Harvister Raycast
        Vector3 rayOrigin2 = transform.position;
        Vector3 rayDirection2 = _harvisterOBJ.transform.position - transform.position;
        float maxRayDistance2 = 3;
        RaycastHit rayHit2;
        if (Physics.Raycast(rayOrigin2, rayDirection2, out rayHit2, maxRayDistance2, fishHarvister))
        {
            _harvisterInteractTXT.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GlobalAudioScript.instance.PlaySoundFrom(GlobalAudioScript.instance._akShredderActivate, _harvisterOBJ);
                GameManager.instance.currentScore = 0;
                GameManager.instance.fishBits += GameManager.instance.currentValue;
                GameManager.instance.currentValue = 0;
                //GameManager.instance.SaveProgress();

                Debug.Log("Fish: " + GameManager.instance.currentScore);
                Debug.Log("Fish Bits: " + GameManager.instance.fishBits);
                Debug.Log("Fish Value: " + GameManager.instance.currentValue);
            }
        }
        else
        {
            _harvisterInteractTXT.SetActive(false);
        }

        //Upgrade Machine Raycast
        Vector3 rayOrigin3 = transform.position;
        Vector3 rayDirection3 = _upgradeOBJ.transform.position - transform.position;
        float maxRayDistance3 = 3;
        RaycastHit rayHit3;
        if (Physics.Raycast(rayOrigin3, rayDirection3, out rayHit3, maxRayDistance3, fishUpgrade))
        {
            _upgradeInteractTXT.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _upgradeUI.SetActive(true);
                GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akGalaxyMenuOpen);
            }
        }
        else
        {
            _upgradeInteractTXT.SetActive(false);
        }
    }
    public void ExitGalaxyMenu()
    {
        _upgradeUI.SetActive(false);
        GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akGalaxyMenuClose);
    }

    void FixedUpdate()
    {
        if (_state == PlayerState.Free)
        {
            //Movement
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rb.velocity = movement * speed * Time.fixedDeltaTime;

            if (Input.GetAxisRaw("Horizontal") > 0) { transform.localScale = new Vector3(-3.5f, transform.localScale.y, transform.localScale.z); }
            else if (Input.GetAxisRaw("Horizontal") < 0) { transform.localScale = new Vector3(3.5f, transform.localScale.y, transform.localScale.z); }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                GlobalAudioScript.instance.WalkSounds(1);
                animator.SetBool("isMoving", true);
            }
            else { GlobalAudioScript.instance.WalkSounds(0); animator.SetBool("isMoving", false); }
        }
    }


}
