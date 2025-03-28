using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject accountUI;
    public GameObject title;
    public GameObject soundplayer;

   public void startMenu()
    {
        menuUI.SetActive(true);
        title.SetActive(true);
        accountUI.SetActive(false);
        soundplayer.SetActive(true);

    }


}
