using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class AutoStartDialogue : MonoBehaviour
{
    [Header("Settings")]
    public bool triggerOnStart = true;

    [Header("References")]
    public DialogueManager dialogueManager;
    public ArticyRef dialogueToPlay; //start flow fragment goes here

    [Header("Delay")]
    public float delayBeforeStart = 3f; 

    void Start()
    {
        if (triggerOnStart && dialogueManager != null && dialogueToPlay != null)
        {

            StartCoroutine(StartDialogueWithDelay());

        }
    }

    IEnumerator StartDialogueWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        dialogueManager.StartDialogue(dialogueToPlay.GetObject());
        Debug.Log("Dialogue auto-started after delay. ");


    }
}
