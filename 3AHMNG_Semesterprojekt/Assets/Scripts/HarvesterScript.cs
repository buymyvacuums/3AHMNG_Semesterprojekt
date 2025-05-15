using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalAudioScript.instance.PlaySoundFrom(GlobalAudioScript.instance._akShredderLoop, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
