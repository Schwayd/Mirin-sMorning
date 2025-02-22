using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLatteArtBook : MonoBehaviour
{

    public GameObject latteBook;
    public void LatteArtBookTrigger()
    {
        if (latteBook.activeInHierarchy == false)
        {
            latteBook.SetActive(true);
        }
        else
        {
            latteBook.SetActive(false);
        }
    }
}
