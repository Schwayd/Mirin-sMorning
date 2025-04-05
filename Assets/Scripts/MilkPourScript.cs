using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkPourScript : MonoBehaviour
{
    [Header("Settings")]
    public int requiredPours = 2;

    [Header("Reference")]
    public Button pourButton;
    public Button confirmButton;
    public GameObject successScreen;
    public GameObject failScreen; //Fail UI

    [Header("Pour Visuals")]
    public GameObject milkCartonIdle;
    public GameObject milkCartonPouring;
    public float pourEffecctDuration = 0.5f;

    private int currentPours = 0;
    private bool gameEnded = false;

    void Start()
    {
        pourButton.onClick.AddListener(PourMilk);
        confirmButton.onClick.AddListener(ConfirmPours);
        successScreen.SetActive(false);
        failScreen.SetActive(false);
    }
    
    void PourMilk()
    {
        if (gameEnded) return;

        currentPours++;
        Debug.Log("Poured! Total: " + currentPours);

        StartCoroutine(PlayPourEffect());
    }

    void ConfirmPours()
    {
        if (gameEnded) return;

        gameEnded = true;

        if (currentPours == requiredPours)
        {
            successScreen.SetActive(true);
            Debug.Log("SUCCESS!");
        }
        else
        {
            failScreen.SetActive(true);
            Debug.Log("Fail!");

        }

        StartCoroutine(EndAfterDelay(2f));
    }

    IEnumerator PlayPourEffect()
    {
        milkCartonIdle.SetActive(false);
        milkCartonPouring.SetActive(true);

        yield return new WaitForSeconds(pourEffecctDuration);

        //Revert to original image
        milkCartonPouring.SetActive(false);
        milkCartonIdle.SetActive(true);
    }

    IEnumerator EndAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false); //Tells minigamemanager to mvoe to next game

    }

}
