using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Upgrade_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _galaxyPriceTXT;
    [SerializeField] private TextMeshProUGUI _galaxyToBuy;

    [SerializeField] private int _galaxyPrice;


    // Start is called before the first frame update
    void Start()
    {
        //_galaxyPrice = 10;
        //_galaxyPriceTXT.text = "Costs " + _galaxyPrice.ToString() + " Fish Bits";
        //_galaxyToBuy.text = "Prehistoria";
    }

    // Update is called once per frame
    void Update()
    {
        if(FishBehaviour._instance.galaxy == Galaxy.Tutoria)
        {
            _galaxyPrice = 10;
            _galaxyPriceTXT.text = "Costs " + _galaxyPrice.ToString() + " Fish Bits";
            _galaxyToBuy.text = "Prehistoria";
        }
        if (FishBehaviour._instance.galaxy == Galaxy.Prehistoria)
        {
            _galaxyPrice = 40;
            _galaxyPriceTXT.text = "Costs " + _galaxyPrice.ToString() + " Fish Bits";
            _galaxyToBuy.text = "Biologica";
        }
        if (FishBehaviour._instance.galaxy == Galaxy.Biologica)
        {
            _galaxyPrice = 80;
            _galaxyPriceTXT.text = "Costs " + _galaxyPrice.ToString() + " Fish Bits";
            _galaxyToBuy.text = "Galaxia";
        }
    }

    public void UpgradeGalaxy()
    {
        if(GameManager.instance.fishBits >= _galaxyPrice)
        {
            FishBehaviour._instance.galaxy = Galaxy.Prehistoria;
            GameManager.instance.fishBits -= _galaxyPrice;
        }
        if(GameManager.instance.fishBits < _galaxyPrice)
        {
            Debug.Log("Cannot buy");
        }
    }
}
