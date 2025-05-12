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

    [SerializeField] private List<GalaxyData> galaxies;

    private void Start()
    {
        // Unlock starting galaxy
        galaxies[0].isUnlocked = true;

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
                text.text = $"{data.galaxyName}\n(Select)";
                button.interactable = true;
            }
            else
            {
                text.text = $"{data.galaxyName}\nCost: {data.price}";
                button.interactable = GameManager.instance.fishBits >= data.price;
            }
        }
    }

    public void OnGalaxyButtonClicked(int index)
    {
        var selected = galaxies[index];

        if (selected.isUnlocked)
        {
            FishBehaviour.galaxy = selected.galaxy;
            Debug.Log("Switched to: " + selected.galaxyName);
        }
        else if (GameManager.instance.fishBits >= selected.price)
        {
            GameManager.instance.fishBits -= selected.price;
            selected.isUnlocked = true;
            FishBehaviour.galaxy = selected.galaxy;
            Debug.Log("Unlocked and switched to: " + selected.galaxyName);
        }
        else
        {
            Debug.Log("Not enough Fish Bits to unlock.");
        }

        UpdateGalaxyButtons();
    }
}
