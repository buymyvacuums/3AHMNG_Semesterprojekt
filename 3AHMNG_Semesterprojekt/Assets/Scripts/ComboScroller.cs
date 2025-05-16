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
    [SerializeField] private TextMeshProUGUI _timer;

    public TextMeshProUGUI _wonTXT;
    public GameObject fishImage;
    public GameObject rarityDisplay;
    [SerializeField] private GameObject buttons;
    private FishSpriteVisualizer _fishSpriteVisualizer;

    public GameObject[] _arrows;
    private float Tempo;



    public static ComboScroller _ComboInstance;

    private void Awake()
    {
        FishBehaviour._instance.FishDifficulty();

        _ComboInstance = this;

        if (FishBehaviour._instance.difficulty == Difficulty.Common)
        {
            ComboScroller._ComboInstance._comboLength = 5;
            beatTempo = 3;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.Uncommon)
        {
            ComboScroller._ComboInstance._comboLength = 8;
            beatTempo = 4;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.Rare)
        {
            ComboScroller._ComboInstance._comboLength = 12;
            beatTempo = 5;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.Epic)
        {
            ComboScroller._ComboInstance._comboLength = 15;
            beatTempo = 5.5f;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.Legendary)
        {
            ComboScroller._ComboInstance._comboLength = 18;
            beatTempo = 6.5f;
        }

        if (FishBehaviour._instance.difficulty == Difficulty.God)
        {
            ComboScroller._ComboInstance._comboLength = 21;
            beatTempo = 8f;
        }
        hasStarted = false;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _fishSpriteVisualizer = FindObjectOfType<FishSpriteVisualizer>();

        
        _failTXT.SetActive(false);
        _wonTXT.gameObject.SetActive(false);
        fishImage.SetActive(false);
        rarityDisplay.SetActive(false);

        StartCoroutine(StartSequence());
    }


    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            for (int i = 0; i < _comboLength; i++)
            {
                int randomIndex = Random.Range(0, _arrows.Length);
                GameObject randomArrow = _arrows[randomIndex];

                Vector3 spawnPos = randomArrow.transform.position;
                spawnPos.y = (i * 1.5f) + 10;

                Instantiate(randomArrow, spawnPos, randomArrow.transform.rotation);
            }
            hasStarted = false;
        }

        if (GameManager.instance.hitNote + GameManager.instance.missedNote == _comboLength)
        {
            if (GameManager.instance.hitNote >= _comboLength -3)
            {
                EndFishing();
            }
            else { StartCoroutine(FishFailed()); }
        } 
    }

    public void EndFishing()
    {
        string fishName = FishBehaviour._instance.GetFishNameByCode(GameManager.instance.fishCode);

        // Mark the fish as caught!
        FishBehaviour._instance.MarkFishAsCaught(GameManager.instance.fishCode);

        GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akSuccess);
        _wonTXT.text = "You caught a " + fishName + "!";
        _fishSpriteVisualizer.ChangeFishSprite(GameManager.instance.fishCode, FishBehaviour._instance.GetFishSizeByCode(GameManager.instance.fishCode),FishBehaviour._instance.GetFishRarityAsInt(GameManager.instance.fishCode));
        _wonTXT.gameObject.SetActive(true);
        fishImage.SetActive(true);
        rarityDisplay.SetActive(true);
        buttons.SetActive(false);

        //God Check
        if(GameManager.instance.fishCode == 9)
        {
            GameManager.instance._god += 1;
        }

        //Return to main
        
        GameManager.instance.currentScore += 1;
        GameManager.instance.currentValue += FishBehaviour._instance.GetFishRarityByCode(GameManager.instance.fishCode);
        Debug.Log("Value = " + GameManager.instance.currentValue);
        GameManager.instance.hitNote = 0;
        GameManager.instance.missedNote = 0;
        //GameManager.instance.SaveProgress();
        Debug.Log("God progress: " + GameManager.instance._god);
    }

    IEnumerator FishFailed()
    {
        yield return null;
        
        _failTXT.gameObject.SetActive(true);
        //Play Fail Sound
        yield return new WaitForSeconds(1);
        GlobalAudioScript.instance.PlaySound(GlobalAudioScript.instance._akFail);
        GameManager.instance.hitNote = 0;
        GameManager.instance.missedNote = 0;
        //GameManager.instance.SaveProgress();
        SceneManager.LoadScene("Main");
    }
    IEnumerator StartSequence()
    {
        yield return null;
        
        _timer.text = "1";
        yield return new WaitForSeconds(0.5f);
        _timer.text = "2";
        yield return new WaitForSeconds(0.5f);
        _timer.text = "3";
        yield return new WaitForSeconds(0.5f);
        _timer.gameObject.SetActive(false);
        hasStarted = true;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
}
