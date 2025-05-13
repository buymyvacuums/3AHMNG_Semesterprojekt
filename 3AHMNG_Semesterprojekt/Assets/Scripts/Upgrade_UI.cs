using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class GalaxyData
{
    public Galaxy galaxy;
    public string galaxyName;
    public int price;
    public bool isUnlocked;
}

public class Upgrade_UI : MonoBehaviour
{
    [SerializeField] private GameObject galaxySelectionPanel;
    [SerializeField] private Button[] galaxyButtons;
    [SerializeField] private TextMeshProUGUI[] galaxyButtonTexts;
    [SerializeField] private TextMeshProUGUI currentGalaxyTXT;

    [SerializeField] private List<GalaxyData> galaxies;

    private void Start()
    {
        // Unlock starting galaxy
        galaxies[0].isUnlocked = true;
        currentGalaxyTXT.text = "[Current Galaxy: " + FishBehaviour.galaxy.ToString() + "]";

        LoadUnlockedGalaxies();
        UpdateGalaxyButtons();
    }

    public void OpenGalaxySelection()
    {
        galaxySelectionPanel.SetActive(true);
        UpdateGalaxyButtons();
    }

    public void CloseGalaxySelection()
    {
        galaxySelectionPanel.SetActive(false);
    }

    private void UpdateGalaxyButtons()
    {
        for (int i = 0; i < galaxies.Count; i++)
        {
            var data = galaxies[i];
            var button = galaxyButtons[i];
            var text = galaxyButtonTexts[i];

            if (data.isUnlocked)
            {
                text.text = $"{data.galaxyName}\n[Select]";
                button.interactable = true;
            }
            else
            {
                text.text = $"{data.galaxyName}\n[{data.price}]";
                button.interactable = GameManager.instance.fishBits >= data.price;
            }
        }
    }

    private void SaveUnlockedGalaxies()
    {
        for (int i = 0; i < galaxies.Count; i++)
        {
            PlayerPrefs.SetInt("GalaxyUnlocked_" + galaxies[i].galaxy.ToString(), galaxies[i].isUnlocked ? 1 : 0);
        }

        PlayerPrefs.SetString("CurrentGalaxy", FishBehaviour.galaxy.ToString());
        PlayerPrefs.Save();
    }

    private void LoadUnlockedGalaxies()
    {
        for (int i = 0; i < galaxies.Count; i++)
        {
            string key = "GalaxyUnlocked_" + galaxies[i].galaxy.ToString();
            galaxies[i].isUnlocked = PlayerPrefs.GetInt(key, i == 0 ? 1 : 0) == 1; // default: first is unlocked
        }

        string savedGalaxy = PlayerPrefs.GetString("CurrentGalaxy", galaxies[0].galaxy.ToString());
        if (System.Enum.TryParse(savedGalaxy, out Galaxy currentGalaxy))
            FishBehaviour.galaxy = currentGalaxy;
    }

    public void OnGalaxyButtonClicked(int index)
    {
        var selected = galaxies[index];

        if (selected.isUnlocked)
        {
            FishBehaviour.galaxy = selected.galaxy;
            currentGalaxyTXT.text = "[Current Galaxy: " + FishBehaviour.galaxy.ToString() + "]";
            SaveUnlockedGalaxies();
            Debug.Log("Switched to: " + selected.galaxyName);
        }
        else if (GameManager.instance.fishBits >= selected.price)
        {
            GameManager.instance.fishBits -= selected.price;
            selected.isUnlocked = true;
            FishBehaviour.galaxy = selected.galaxy;
            currentGalaxyTXT.text = "[Current Galaxy: " + FishBehaviour.galaxy.ToString() + "]";
            SaveUnlockedGalaxies();
            Debug.Log("Unlocked and switched to: " + selected.galaxyName);
        }
        else
        {
            Debug.Log("Not enough Fish Bits to unlock.");
        }

        UpdateGalaxyButtons();
    }
}