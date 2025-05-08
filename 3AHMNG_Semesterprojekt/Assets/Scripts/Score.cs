using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI _scoreTXT;
    public TextMeshProUGUI _fishBitsTXT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreTXT.text = "Fish: " + GameManager.instance.currentScore.ToString();
        _fishBitsTXT.text = "Fish Bits: " + GameManager.instance.fishBits.ToString();

    }
}
