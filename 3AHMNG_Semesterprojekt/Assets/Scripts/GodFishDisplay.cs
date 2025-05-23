using UnityEngine;
using UnityEngine.UI;
using TMPro; // Optional if using TextMeshPro

public class GodFishDisplay : MonoBehaviour
{
    [Header("UI Panel")]
    public GameObject godFishPanel;

    [Header("Fish Slot UI Elements")]
    public Image[] fishImages; // 0: Ossis, 1: Vitae, 2: Ultranova
    public TMP_Text[] fishNames; // Or just Text if not using TMP

    [Header("Fish Sprites")]
    public Sprite[] unlockedSprites; // Assign: [0] Ossis, [1] Vitae, [2] Ultranova
    public Sprite lockedSprite;

    private int[] godFishCodes = new int[] { 9, 16, 24 };
    private string[] godFishNames = new string[] { "King Ossis", "Queen Vitae", "Ultranova" };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            bool isActive = godFishPanel.activeSelf;
            godFishPanel.SetActive(!isActive);

            if (!isActive)
                UpdateGodFishUI();
        }
    }

    private void UpdateGodFishUI()
    {
        for (int i = 0; i < godFishCodes.Length; i++)
        {
            bool caught = FishBehaviour._instance.HasCaughtFish(godFishCodes[i]);

            fishImages[i].sprite = caught ? unlockedSprites[i] : lockedSprite;
            fishNames[i].text = caught ? godFishNames[i] : "???";
        }
    }

}
