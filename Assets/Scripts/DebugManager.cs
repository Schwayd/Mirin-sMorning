using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DebugManager : MonoBehaviour
{
    [SerializeField]
    private GameObject RestartingUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            StartCoroutine(RestartScene());
        }
    }


    IEnumerator RestartScene()
    {
        RestartingUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
