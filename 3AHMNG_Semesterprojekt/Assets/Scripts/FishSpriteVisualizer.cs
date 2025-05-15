using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishSpriteVisualizer : MonoBehaviour
{
    private Image fishImage;
    [SerializeField] private Sprite[] fishSprite;

    public Image RarityImage;
    [SerializeField] private Sprite[] starSprite;
    // Start is called before the first frame update
    void Awake()
    {
        fishImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeFishSprite(int i, float size,int rarity)
    {

        fishImage.sprite = fishSprite[i-1];
        fishImage.SetNativeSize();
        fishImage.transform.localScale = Vector3.one * size;
        RarityImage.sprite = starSprite[rarity];
        RarityImage.SetNativeSize();

    }
}
