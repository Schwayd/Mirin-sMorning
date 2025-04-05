using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabCupMinigame : MonoBehaviour
{
    [Header("References")]
    public Button grabCupButton;

    void Start()
    {
        grabCupButton.onClick.AddListener(EndMinigame);
    }


    void EndMinigame()
    {
        Debug.Log("Cup grabbed! Ending minigame.");
        gameObject.SetActive(false); //Triggers the MinigameManager to move on

    }
}
