using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewTrigger : MonoBehaviour
{
    public GameObject brewGame;

    public void brewUITrigger()
    {
        if (brewGame.activeInHierarchy == false)
        {
            brewGame.SetActive(true);
        }
        else
        {
            brewGame.SetActive(false);
        }
    }

}
