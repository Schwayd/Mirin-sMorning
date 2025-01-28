using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTamp : MonoBehaviour
{
    public GameObject tampgameUI;

    public void tampUITrigger()
    {
        if (tampgameUI.activeInHierarchy == false)
        {
            tampgameUI.SetActive(true);
        }
        else
        {
            tampgameUI.SetActive(false);
        }
    }

} 


