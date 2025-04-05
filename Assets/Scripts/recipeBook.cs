using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recipeBook : MonoBehaviour
{
    [Header("References")]
    public GameObject recipeBookUI; //Recipe book UI

    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (recipeBookUI.activeInHierarchy == false)
            {
                recipeBookUI.SetActive(true);
            }
            else
            {
                recipeBookUI.SetActive(false);
            }
        }
    }
}
