using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatteArtManager : MonoBehaviour
{
    public Image[] keyIndicators; // UI elements for key presses
    public Image latteArtDisplay; // Image to display the final latte art
    public Sprite failedTexture; // Texture for failed latte art
    public Sprite heartTexture, rosettaTexture, tulipTexture, bearFaceTexture, spiralTexture; //Latte art textures

    private List<KeyCode> pressedKeys = new List<KeyCode>();
    private Dictionary<string, Sprite> latteArtPatterns = new Dictionary<string, Sprite>();









}
