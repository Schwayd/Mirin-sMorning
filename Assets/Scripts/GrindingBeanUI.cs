using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindingBeanUI : MonoBehaviour
{
    public GameObject GrindingUI;

    public void Trigger()
    {
        if (GrindingUI.activeInHierarchy == false)
        {
            GrindingUI.SetActive(true);
        }
        else
        {
            GrindingUI.SetActive(false);
        }
    }
}
