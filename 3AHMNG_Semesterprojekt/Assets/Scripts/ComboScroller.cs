using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ComboScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    public int _comboLength;

    [SerializeField] private GameObject _failTXT;

    public TextMeshProUGUI _wonTXT;
    private FishSpriteVisualizer _fishSpriteVisualizer;

    public GameObject[] _arrows;



    public static ComboScroller _ComboInstance;

    private void Awake()
    {
        FishBehaviour._instance.FishDifficulty();

        _ComboInstance = this;

        if (FishBehaviour._instance.difficulty == Difficulty.Common)
        {
            ComboScroller._ComboInstance._comboLength = 5;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.Uncommon)
        {
            ComboScroller._ComboInstance._comboLength = 8;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.Rare)
        {
            ComboScroller._ComboInstance._comboLength = 12;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.Epic)
        {
            ComboScroller._ComboInstance._comboLength = 15;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.Legendary)
        {
            ComboScroller._ComboInstance._comboLength = 18;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.God)
        {
            ComboScroller._ComboInstance._comboLength = 21;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _fishSpriteVisualizer = FindObjectOfType<FishSpriteVisualizer>();
        beatTempo = beatTempo / 60f;


        
        _failTXT.SetActive(false);
        _wonTXT.gameObject.SetActive(false);

        //Combo Randomizer
        if (_comboLength == 5)
        {
            for (int i = 0; i < _comboLength; i++)
            {
                int randomIndex = Random.Range(0, _arrows.Length);
                GameObject randomArrow = _arrows[randomIndex];

                Vector3 spawnPos = randomArrow.transform.position;
                spawnPos.y = i + 3;

                Instantiate(randomArrow, spawnPos, randomArrow.transform.rotation);
            }
        }
        if (_comboLength == 8)
        {
            for (int i = 0; i < _comboLength; i++)
            {
                int randomIndex = Random.Range(0, _arrows.Length);
                GameObject randomArrow = _arrows[randomIndex];

                Vector3 spawnPos = randomArrow.transform.position;
                spawnPos.y = i + 3;

                Instantiate(randomArrow, spawnPos, randomArrow.transform.rotation);
            }
        }
        if (_comboLength == 12)
        {
            for (int i = 0; i < _comboLength; i++)
            {
                int randomIndex = Random.Range(0, _arrows.Length);
                GameObject randomArrow = _arrows[randomIndex];

                Vector3 spawnPos = randomArrow.transform.position;
                spawnPos.y = i + 3;

                Instantiate(randomArrow, spawnPos, randomArrow.transform.rotation);
            }
        }
        if (_comboLength == 15)
        {
            for (int i = 0; i < _comboLength; i++)
            {
                int randomIndex = Random.Range(0, _arrows.Length);
                GameObject randomArrow = _arrows[randomIndex];

                Vector3 spawnPos = randomArrow.transform.position;
                spawnPos.y = i + 3;

                Instantiate(randomArrow, spawnPos, randomArrow.transform.rotation);
            }
        }
        if (_comboLength == 18)
        {
            for (int i = 0; i < _comboLength; i++)
            {
                int randomIndex = Random.Range(0, _arrows.Length);
                GameObject randomArrow = _arrows[randomIndex];

                Vector3 spawnPos = randomArrow.transform.position;
                spawnPos.y = i + 3;

                Instantiate(randomArrow, spawnPos, randomArrow.transform.rotation);
            }
        }
        if (_comboLength == 21)
        {
            for (int i = 0; i < _comboLength; i++)
            {
                int randomIndex = Random.Range(0, _arrows.Length);
                GameObject randomArrow = _arrows[randomIndex];

                Vector3 spawnPos = randomArrow.transform.position;
                spawnPos.y = i + 3;

                Instantiate(randomArrow, spawnPos, randomArrow.transform.rotation);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        

        if (GameManager.instance.hitNote == _comboLength)
        {
            
            StartCoroutine(EndFishing());
        }
        else if(GameManager.instance.missedNote == _comboLength)
        {
            
            StartCoroutine(FishFailed());
        }
        
    }

    IEnumerator EndFishing()
    {
        yield return new WaitForSeconds(0.2f);

        string fishName = FishBehaviour._instance.GetFishNameByCode(GameManager.instance.fishCode);
        Debug.Log("Caught fish: " + fishName);

        // Mark the fish as caught!
        FishBehaviour._instance.MarkFishAsCaught(GameManager.instance.fishCode);

        _wonTXT.text = "You caught " + fishName;
        _wonTXT.gameObject.SetActive(true);
        _fishSpriteVisualizer.ChangeFishSprite(GameManager.instance.fishCode);
        // Play Victory Sound

        yield return new WaitForSeconds(1);
        GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akSuccess);
        GameManager.instance.currentScore += 1;
        GameManager.instance.hitNote = 0;
        GameManager.instance.missedNote = 0;
        SceneManager.LoadScene("Main");
    }

    IEnumerator FishFailed()
    {
        _failTXT.gameObject.SetActive(true);
        //Play Fail Sound
        
        yield return new WaitForSeconds(1);
        GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akFail);
        GameManager.instance.hitNote = 0;
        GameManager.instance.missedNote = 0;
        SceneManager.LoadScene("Main");
    }
}
