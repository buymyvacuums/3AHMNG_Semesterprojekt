using System.IO;
using UnityEngine;

public static class SaveManager
{
    private static readonly string savePath = Application.persistentDataPath + "/savefile.json";
    public static SaveData CurrentData { get; private set; } = new SaveData();

    public static void SaveGame()
    {
        // Collect current state
        CurrentData.fishBits = GameManager.instance.fishBits;
        CurrentData.currentGalaxy = (int)FishBehaviour.galaxy;
        //CurrentData.unlockedGalaxies = GameManager.instance.GetUnlockedGalaxyNames();
        CurrentData.caughtFishCodes = FishBehaviour._instance.GetCaughtFishIDs();

        string json = JsonUtility.ToJson(CurrentData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved!");
    }

    public static void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            CurrentData = JsonUtility.FromJson<SaveData>(json);
            ApplyDataToGame();
            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.Log("No save file found. Using defaults.");
        }
    }

    private static void ApplyDataToGame()
    {
        GameManager.instance.fishBits = CurrentData.fishBits;
        FishBehaviour.galaxy = (Galaxy)CurrentData.currentGalaxy;
        //GameManager.instance.ApplyUnlockedGalaxies(CurrentData.unlockedGalaxies);
        FishBehaviour._instance.SetCaughtFish(CurrentData.caughtFishCodes);
    }

    // New method to check if a save file exists
    public static bool SaveExists()
    {
        return File.Exists(savePath);
    }

    // New method to delete the save file
    public static void DeleteSave()
    {
        if (SaveExists())
        {
            File.Delete(savePath);
            Debug.Log("Save file deleted!");
        }
        else
        {
            Debug.Log("No save file to delete.");
        }
    }
}
