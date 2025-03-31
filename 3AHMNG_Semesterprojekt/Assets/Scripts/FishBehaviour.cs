using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Fish
{
    public int _rarity;
    public string _name;
    public int _fishPoints;
    public GameObject _combo;
    public Sprite _fishSprite;
}

class KingOssis : Fish
{
    
}
class QueenVitae : Fish
{

}
class Ultranova : Fish
{

}
class NyanCatfish : Fish
{

}
class MagnaLarva : Fish
{

}
class AEX11_N2 : Fish
{

}
class AstralOcta : Fish
{

}
class Glider : Fish
{

}
class MilkywayWorm : Fish
{

}
class CosmicCrab : Fish
{

}
class Megaphoton : Fish
{

}
class LemonShark : Fish
{

}
class Grassmuncher : Fish
{

}
class Bloomster : Fish
{

}
class HoneyCarp : Fish
{

}
class FloralFlounder : Fish
{

}
class Helicoprion : Fish
{

}
class RegretfulFish : Fish
{

}
class HorseshoeCrab : Fish
{

}
class Sacabambaspis : Fish
{

}
class Leedsichthys : Fish
{

}
class Hemospheel : Fish
{

}
class Sprayfish : Fish
{

}
public class FishBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _starComb;

    // Start is called before the first frame update
    void Start()
    {
        Fish _stardine = new Fish();
        _stardine._rarity = 1;
        _stardine._name = "Stardine";
        _stardine._fishPoints = Random.Range(1,5);
        _stardine._combo = _starComb;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
