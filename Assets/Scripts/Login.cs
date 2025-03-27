using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject accountUI;

   public void startMenu()
    {
        menuUI.SetActive(true);
        accountUI.SetActive(false);
    }


}
