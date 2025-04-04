using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatteArtManager : MonoBehaviour
{
    public Image[] keyIndicators; // UI elements for key presses
    public Image latteArtDisplay; // Image to display the final latte art
    public Sprite failedTexture; // Texture for failed latte art
    public Sprite heartTexture, rosettaTexture, starTexture, bunnyTexture, catTexture; //Latte art textures

    private List<KeyCode> pressedKeys = new List<KeyCode>();
    private Dictionary<string, Sprite> latteArtPatterns = new Dictionary<string, Sprite>();

    [SerializeField] public GameObject latteArtUI;

    public GameObject successImage;

    void Start()
    {
        //Define the correct key combinations
        latteArtPatterns.Add("ASD", heartTexture);
        latteArtPatterns.Add("WAS", rosettaTexture);
        latteArtPatterns.Add("DWA", starTexture);
        latteArtPatterns.Add("SDW", bunnyTexture);
        latteArtPatterns.Add("ADW", catTexture);
        
    }

    void Update()
    {
        if (pressedKeys.Count < 3)
        {
            if (Input.anyKeyDown)
            {
                KeyCode key = GetPressedKey();
                if (key != KeyCode.None && !pressedKeys.Contains(key))
                {
                    pressedKeys.Add(key);
                    UpdateIndicators();
                }
            }
        }

        if (pressedKeys.Count == 3)
        {
            DetermineLatteArt();
            pressedKeys.Clear();
            Invoke("ArtComplete", 2.0f);
        }
    }

    KeyCode GetPressedKey()
    {
        foreach (KeyCode key in new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.W})
        {
            if (Input.GetKeyDown(key))
                return key;
        }
        return KeyCode.None;

    }

    void UpdateIndicators()
    {
        for (int i = 0; i < keyIndicators.Length; i++)
        {
            keyIndicators[i].enabled = i < pressedKeys.Count;
            if (i < pressedKeys.Count)
                keyIndicators[i].sprite = GetKeySprite(pressedKeys[i]);
        }
    }

    Sprite GetKeySprite(KeyCode key)
    {
        //assign specific sprites for each key if needed
        return null;
    }

    void DetermineLatteArt()
    {
        string keyCombo = string.Join("", pressedKeys.ConvertAll(k => k.ToString().Substring(0, 1)).ToArray());

        if (latteArtPatterns.ContainsKey(keyCombo))
        {
            latteArtDisplay.sprite = latteArtPatterns[keyCombo];
            successImage.SetActive(true);

        }
        else
        {
            latteArtDisplay.sprite = failedTexture;

        }
    }
    private void ArtComplete()
    {
        latteArtUI.SetActive(false);
    }

}
