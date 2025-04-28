using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Galaxy
{
    Tutoria,
    Prehistoria,
    Biologica,
    Galaxia
}

//Combo
public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    God
}

//Fish
public class Fish
{
    public int _rarity;
    public string _name;
    public int _fishCode;
    public GameObject _combo;
    public Sprite _fishSprite;
    public Galaxy _galaxy;
    public Difficulty _difficulty;
}



public class FishBehaviour : MonoBehaviour
{
    public static FishBehaviour _instance;

    public Difficulty difficulty;

    public Galaxy galaxy;


    public Dictionary<int, Fish> fishDictionary = new Dictionary<int, Fish>();


    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;

        Fish _stardine = new Fish();
        _stardine._fishCode = 1;
        _stardine._rarity = 1;
        _stardine._name = "Stardine";
        _stardine._difficulty = Difficulty.Easy;
        fishDictionary.Add(_stardine._fishCode, _stardine);

        Fish _sprayfish = new Fish();
        _sprayfish._fishCode = 2;
        _sprayfish._rarity = 1;
        _sprayfish._name = "Sprayfish";
        _sprayfish._difficulty = Difficulty.Easy;
        fishDictionary.Add(_sprayfish._fishCode, _sprayfish);

        Fish _hemospheel = new Fish();
        _hemospheel._fishCode = 3;
        _hemospheel._rarity = 1;
        _hemospheel._name = "Hemospeel";
        _hemospheel._difficulty = Difficulty.Easy;
        fishDictionary.Add(_hemospheel._fishCode, _hemospheel);

        Fish _leedsichthys = new Fish();
        _leedsichthys._fishCode = 4;
        _leedsichthys._rarity = 1;
        _leedsichthys._name = "Leedsichthys";
        _leedsichthys._difficulty = Difficulty.Easy;
        fishDictionary.Add(_leedsichthys._fishCode, _leedsichthys);

        Fish _sacabambaspis = new Fish();
        _sacabambaspis._fishCode = 5;
        _sacabambaspis._rarity = 1;
        _sacabambaspis._name = "Sacabambaspis";
        _sacabambaspis._difficulty = Difficulty.Easy;
        fishDictionary.Add(_sacabambaspis._fishCode, _sacabambaspis);

        Fish _horseshoeCrab = new Fish();
        _horseshoeCrab._fishCode = 6;
        _horseshoeCrab._rarity = 1;
        _horseshoeCrab._name = "Horseshoe Crab";
        _horseshoeCrab._difficulty = Difficulty.Easy;
        fishDictionary.Add(_horseshoeCrab._fishCode, _horseshoeCrab);
    }

    // Update is called once per frame
    void Update()
    {
        galaxy = Galaxy.Tutoria;

        


    }

    public string GetFishNameByCode(int code)
    {
        //if (code == 0)
        //{
        //    Debug.LogError("Fish code is 0. It may not be initialized properly.");
        //    return "Unknown Fish";
        //}

        if (fishDictionary.TryGetValue(code, out Fish fish))
        {
            return fish._name;
        }
        else
        {
            return "Unknown Fish";
        }
    }


}
