using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("returntomenu", 7.0f);
    }

    void returntomenu()
    {
        SceneManager.LoadScene(0);
    }
}
