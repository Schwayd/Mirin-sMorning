using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject[] minigames; //Assigns all the UI minigames to an array in order
    private int currentMinigameIndex = 0;

    private void Start()
    {
        //Ensure only the first minigame is active
        for (int i = 1; i < minigames.Length; i++)
        {
            minigames[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (currentMinigameIndex < minigames.Length)
        {
            if (!minigames[currentMinigameIndex].activeSelf) //checks if the current mini game is active
            {
                StartNextMinigame();
            }
                
        }
    }

    void StartNextMinigame()
    {
        currentMinigameIndex++;

        if (currentMinigameIndex < minigames.Length)
        {
            minigames[currentMinigameIndex].SetActive(true);
        }
        else
        {
            Debug.Log("All minigames completed");
        }
    }

}
