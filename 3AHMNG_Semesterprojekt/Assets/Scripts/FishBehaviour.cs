using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using Unity.VisualScripting.Dependencies.Sqlite;
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
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
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
    public  Galaxy _galaxy;
    public Difficulty _difficulty;
    public float _size;

    public bool isGodFish;
    public bool hasBeenCaught;
}



public class FishBehaviour : MonoBehaviour
{
    public static FishBehaviour _instance;

    public Difficulty difficulty;

    public static Galaxy galaxy;



    public Dictionary<int, Fish> fishDictionary = new Dictionary<int, Fish>();


    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;


        //Tutoria
        Fish _stardine = new Fish();
        _stardine._fishCode = 1;
        _stardine._rarity = 1;
        _stardine._name = "Stardine";
        _stardine._difficulty = Difficulty.Common;
        _stardine._size = 1;
        fishDictionary.Add(_stardine._fishCode, _stardine);

        Fish _sprayfish = new Fish();
        _sprayfish._fishCode = 2;
        _sprayfish._rarity = 1;
        _sprayfish._name = "Sprayfish";
        _sprayfish._difficulty = Difficulty.Common;
        _sprayfish._size = 1;
        fishDictionary.Add(_sprayfish._fishCode, _sprayfish);

        Fish _hemospheel = new Fish();
        _hemospheel._fishCode = 3;
        _hemospheel._rarity = 1;
        _hemospheel._name = "Hemospheel";
        _hemospheel._difficulty = Difficulty.Common;
        _hemospheel._size = 1.5f;
        fishDictionary.Add(_hemospheel._fishCode, _hemospheel);

        //Prehistoria
        Fish _leedsichthys = new Fish();
        _leedsichthys._fishCode = 4;
        _leedsichthys._rarity = 1;
        _leedsichthys._name = "Leedsichthys";
        _leedsichthys._difficulty = Difficulty.Common;
        _leedsichthys._size = 5f;
        fishDictionary.Add(_leedsichthys._fishCode, _leedsichthys);

        Fish _sacabambaspis = new Fish();
        _sacabambaspis._fishCode = 5;
        _sacabambaspis._rarity = 1;
        _sacabambaspis._name = "Sacabambaspis";
        _sacabambaspis._difficulty = Difficulty.Common;
        _sacabambaspis._size = 2.5f;
        fishDictionary.Add(_sacabambaspis._fishCode, _sacabambaspis);

        Fish _horseshoeCrab = new Fish();
        _horseshoeCrab._fishCode = 6;
        _horseshoeCrab._rarity = 2;
        _horseshoeCrab._name = "Horseshoe Crab";
        _horseshoeCrab._difficulty = Difficulty.Uncommon;
        _horseshoeCrab._size = 3;
        fishDictionary.Add(_horseshoeCrab._fishCode, _horseshoeCrab);

        Fish _regretfulFish = new Fish();
        _regretfulFish._fishCode = 7;
        _regretfulFish._rarity = 2;
        _regretfulFish._name = "Regretful Fish";
        _regretfulFish._difficulty = Difficulty.Uncommon;
        _regretfulFish._size = 4;
        fishDictionary.Add(_regretfulFish._fishCode, _regretfulFish);

        Fish _helicoprion = new Fish();
        _helicoprion._fishCode = 8;
        _helicoprion._rarity = 5;
        _helicoprion._name = "Helicoprion";
        _helicoprion._difficulty = Difficulty.Rare;
        _helicoprion._size = 5;
        fishDictionary.Add(_helicoprion._fishCode, _helicoprion);

        Fish _kingOssis = new Fish();
        _kingOssis._fishCode = 9;
        _kingOssis._rarity = 0;
        _kingOssis._name = "King Ossis";
        _kingOssis._difficulty = Difficulty.God;
        _kingOssis._size = 6;
        //_kingOssis.isGodFish = true;
        //_kingOssis.hasBeenCaught = false;
        fishDictionary.Add(_kingOssis._fishCode, _kingOssis);

        //Biologica
        Fish _floralFlounder = new Fish();
        _floralFlounder._fishCode = 10;
        _floralFlounder._rarity = 1;
        _floralFlounder._name = "Floral Flounder";
        _floralFlounder._difficulty = Difficulty.Common;
        _floralFlounder._size = 3;
        fishDictionary.Add(_floralFlounder._fishCode, _floralFlounder);

        Fish _honeyCarp = new Fish();
        _honeyCarp._fishCode = 11;
        _honeyCarp._rarity = 1;
        _honeyCarp._name = "Honey Carp";
        _honeyCarp._difficulty = Difficulty.Common;
        _honeyCarp._size = 1;
        fishDictionary.Add(_honeyCarp._fishCode, _honeyCarp);

        Fish _bloomster = new Fish();
        _bloomster._fishCode = 12;
        _bloomster._rarity = 2;
        _bloomster._name = "Bloomster";
        _bloomster._difficulty = Difficulty.Uncommon;
        _bloomster._size = 2;
        fishDictionary.Add(_bloomster._fishCode, _bloomster);

        Fish _grassmuncher = new Fish();
        _grassmuncher._fishCode = 13;
        _grassmuncher._rarity = 2;
        _grassmuncher._name = "Grassmuncher";
        _grassmuncher._difficulty = Difficulty.Uncommon;
        _grassmuncher._size = 1f;
        fishDictionary.Add(_grassmuncher._fishCode, _grassmuncher);

        Fish _lemonShark = new Fish();
        _lemonShark._fishCode = 14;
        _lemonShark._rarity = 5;
        _lemonShark._name = "Lemon Shark";
        _lemonShark._difficulty = Difficulty.Rare;
        _lemonShark._size = 4;
        fishDictionary.Add(_lemonShark._fishCode, _lemonShark);

        Fish _megaphoton = new Fish();
        _megaphoton._fishCode = 15;
        _megaphoton._rarity = 20;
        _megaphoton._name = "Megaphoton";
        _megaphoton._difficulty = Difficulty.Legendary;
        _megaphoton._size = 6;
        fishDictionary.Add(_megaphoton._fishCode, _megaphoton);

        Fish _queenVitae = new Fish();
        _queenVitae._fishCode = 16;
        _queenVitae._rarity = 0;
        _queenVitae._name = "Queen Vitae";
        _queenVitae._difficulty = Difficulty.God;
        _queenVitae._size = 4;
        //_queenVitae.isGodFish = true;
        //_queenVitae.hasBeenCaught = false;
        fishDictionary.Add(_queenVitae._fishCode, _queenVitae);

        //Galaxia
        Fish _cosmicCrab = new Fish();
        _cosmicCrab._fishCode = 17;
        _cosmicCrab._rarity = 1;
        _cosmicCrab._name = "Cosmic Crab";
        _cosmicCrab._difficulty = Difficulty.Common;
        _cosmicCrab._size = 2;
        fishDictionary.Add(_cosmicCrab._fishCode, _cosmicCrab);

        Fish _milkywayWorm = new Fish();
        _milkywayWorm._fishCode = 18;
        _milkywayWorm._rarity = 2;
        _milkywayWorm._name = "Milkyway Worm";
        _milkywayWorm._difficulty = Difficulty.Uncommon;
        _milkywayWorm._size = 1;
        fishDictionary.Add(_milkywayWorm._fishCode, _milkywayWorm);

        Fish _glider = new Fish();
        _glider._fishCode = 19;
        _glider._rarity = 5;
        _glider._name = "Glider";
        _glider._difficulty = Difficulty.Rare;
        _glider._size = 7;
        fishDictionary.Add(_glider._fishCode, _glider);

        Fish _astralOcta = new Fish();
        _astralOcta._fishCode = 20;
        _astralOcta._rarity = 10;
        _astralOcta._name = "Astral Octa";
        _astralOcta._difficulty = Difficulty.Epic;
        _astralOcta._size = 2;
        fishDictionary.Add(_astralOcta._fishCode, _astralOcta);

        Fish _AEX11_N2 = new Fish();
        _AEX11_N2._fishCode = 21;
        _AEX11_N2._rarity = 10;
        _AEX11_N2._name = "AEX11-N2";
        _AEX11_N2._difficulty = Difficulty.Epic;
        _AEX11_N2._size = 1;
        fishDictionary.Add(_AEX11_N2._fishCode, _AEX11_N2);

        Fish _magnaLarva = new Fish();
        _magnaLarva._fishCode = 22;
        _magnaLarva._rarity = 10;
        _magnaLarva._name = "Magna Larva";
        _magnaLarva._difficulty = Difficulty.Epic;
        _magnaLarva._size = 3.5f;
        fishDictionary.Add(_magnaLarva._fishCode, _magnaLarva);

        Fish _nyanCatfish = new Fish();
        _nyanCatfish._fishCode = 23;
        _nyanCatfish._rarity = 20;
        _nyanCatfish._name = "Nyan Catfish";
        _nyanCatfish._difficulty = Difficulty.Legendary;
        _nyanCatfish._size = 4;
        fishDictionary.Add(_nyanCatfish._fishCode, _nyanCatfish);

        Fish _ultranova = new Fish();
        _ultranova._fishCode = 24;
        _ultranova._rarity = 0;
        _ultranova._name = "Ultranova";
        _ultranova._difficulty = Difficulty.God;
        _ultranova._size = 7;
        //_ultranova.isGodFish = true;
        //_ultranova.hasBeenCaught = false;
        fishDictionary.Add(_ultranova._fishCode, _ultranova);
    }

    // Update is called once per frame
    void Update()
    {
      


    }

    public string GetFishNameByCode(int code)
    {
        
        if (fishDictionary.TryGetValue(code, out Fish fish))
        {
            return fish._name;
        }
        else
        {
            return "Unknown Fish";
        }
    }
    public int GetFishRarityByCode(int code)
    {

        if (fishDictionary.TryGetValue(code, out Fish fish))
        {
            return fish._rarity;
        }
        else
        {
            return 0;
        }
    }
    public int GetFishRarityAsInt(int code)
    {
        int i = 0;
        if (fishDictionary.TryGetValue(code, out Fish fish))
        {
            if (fish._difficulty == Difficulty.Common)
            {
                i = 0;
            }
            else if (fish._difficulty == Difficulty.Uncommon)
            {
                i = 1;
            }
            else if (fish._difficulty == Difficulty.Rare)
            {
                i = 2;
            }
            else if (fish._difficulty == Difficulty.Epic)
            {
                i = 3;
            }
            else if (fish._difficulty == Difficulty.Legendary)
            {
                i = 4;
            }
            else if (fish._difficulty == Difficulty.God)
            {
                i = 5;
            }
        }
        return i;
    }
    public float GetFishSizeByCode(int code)
    {

        if (fishDictionary.TryGetValue(code, out Fish fish))
        {
            return fish._size;
        }
        else
        {
            return 1;
        }
    }

    public bool HasCaughtFish(int fishCode)
    {
        if (fishDictionary.TryGetValue(fishCode, out Fish fish))
        {
            return fish.hasBeenCaught;
        }
        return false;
    }

    public delegate void GodFishCaughtEvent();
    public static event GodFishCaughtEvent OnGodFishCaught;

    public void MarkFishAsCaught(int fishCode)
    {
        if (fishDictionary.TryGetValue(fishCode, out Fish fish))
        {
            fish.hasBeenCaught = true;
            Debug.Log($"{fish._name} has been marked as caught.");

            if (fish._difficulty == Difficulty.God)
            {
                OnGodFishCaught?.Invoke(); // Notify listeners
            }
        }
    }


    public void FishDifficulty()
    {
        // Get all the keys (fish codes) from the dictionary
        List<int> fishCodes = new List<int>(fishDictionary.Keys);

        // Get the fish
        Fish selectedFish = fishDictionary[GameManager.instance.fishCode];

        // Set the difficulty to the fish's difficulty
        difficulty = selectedFish._difficulty;
    }

    public List<int> GetCaughtFishIDs()
    {
        List<int> ids = new List<int>();
        foreach (var pair in fishDictionary)
        {
            if (pair.Value.hasBeenCaught) // FIXED
                ids.Add(pair.Key);
        }
        return ids;
    }

    public void SetCaughtFish(List<int> caughtIDs)
    {
        foreach (var id in caughtIDs)
        {
            if (fishDictionary.ContainsKey(id))
                fishDictionary[id].hasBeenCaught = true; // FIXED
        }
    }



}
