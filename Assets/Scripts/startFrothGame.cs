using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startFrothGame : MonoBehaviour
{
    public GameObject frothGameUI;

    public void frothGameUITrigger()
    {
        if (frothGameUI.activeInHierarchy == false)
        {
            frothGameUI.SetActive(true);
        }
        else
        {
            frothGameUI.SetActive(false);
        }

    }
}
