using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public static LightChanger instance;
    private Light lightComp;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        lightComp = GetComponent<Light>();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLighting()
    {
        if (FishBehaviour.galaxy == Galaxy.Tutoria) { lightComp.color = new Color(0.4745098f, 0.3960784f, 0.6588235f); }
        if (FishBehaviour.galaxy == Galaxy.Prehistoria) { lightComp.color = new Color(0.6588235f, 0.4823529f, 0.3960784f); }
        if (FishBehaviour.galaxy == Galaxy.Biologica) { lightComp.color = new Color(0.5882353f, 0.7647059f, 0.6666667f); }
        if (FishBehaviour.galaxy == Galaxy.Galaxia) { lightComp.color = new Color(0.9137255f, 0.7647059f, 0.8901961f); }
    }

}
