using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixiPotionLogo : MonoBehaviour
{
    public GameObject pixipotionlogo;
    // Start is called before the first frame update
    void Start()
    {
        pixipotionlogo.SetActive(true);
        Invoke("exitlogosequence", 3.0f);
    }

    void exitlogosequence()
    {
        pixipotionlogo.SetActive(false);
    }
}
