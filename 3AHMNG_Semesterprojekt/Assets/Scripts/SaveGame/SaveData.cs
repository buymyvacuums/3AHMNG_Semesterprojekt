using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int fishBits = 0;
    public int score = 0;
    public int currentGalaxy = 0; // Cast to Galaxy enum
    public List<string> unlockedGalaxies = new List<string>();
    public List<int> caughtFishCodes = new List<int>();
}