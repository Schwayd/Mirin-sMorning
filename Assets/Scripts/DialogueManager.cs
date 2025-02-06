using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Articy.UnityImporterTutorial;
using System;


public class DialogueManager : MonoBehaviour, IArticyFlowPlayerCallbacks
{
    [Header("UI")]
    // Reference to Dialog UI
    [SerializeField]
    GameObject dialogueWidget;
    // Reference to dialogue text
    [SerializeField]
    Text dialogueText;
    // Reference to speaker
    [SerializeField]
    Text dialogueSpeaker;
    [SerializeField]
    RectTransform branchLayoutPanel;
    [SerializeField]
    GameObject branchPrefab;
    [SerializeField]
    GameObject closePrefab;

    

    // To check if we are currently showing the dialog ui interface
    public bool DialogueActive { get; set; }


    private ArticyFlowPlayer flowPlayer; 
    void Start()
    {
        //Triggers the flowplayer to traverse through the script
        flowPlayer = GetComponent<ArticyFlowPlayer>();
        
    }

   

    public void StartDialogue(IArticyObject aObject)
    {
        //begins the dialogue
        DialogueActive = true;
        dialogueWidget.SetActive(DialogueActive);
        //method sets the diaogue widget active and flow player object begins
        flowPlayer.StartOn = aObject;
        
        
        
    }

    public void CloseDialogueBox()
    {
        //Hides the dialogue UI 
        DialogueActive = false;
        dialogueWidget.SetActive(DialogueActive);
        
        flowPlayer.FinishCurrentPausedObject();
        
    }

    //These two methods below extracts information from the node it paused on and tell the flow player what to do next
    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        dialogueText.text = string.Empty;
        dialogueSpeaker.text = string.Empty;

        var objectWithText = aObject as IObjectWithLocalizableText;
        if(objectWithText != null)
        {
            dialogueText.text = objectWithText.Text;
        }

        //fetch the speaker property and cast to objectwithspeaker
        var objectWithSpeaker = aObject as IObjectWithSpeaker;
        if (objectWithSpeaker != null)
        {
            var speakerEntity = objectWithSpeaker.Speaker as Entity;
            if (speakerEntity != null)
            {
                dialogueSpeaker.text = speakerEntity.DisplayName;
            }
        }

    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        ClearAllBranches();
        bool dialogueIsFinished = true;
        foreach (var branch in aBranches)
        {
            if (branch.Target is IDialogueFragment)
            {
                dialogueIsFinished = false;
            }

        }

        if (!dialogueIsFinished)
        {
            //If there is more text then we need to create a button for each branch following
            foreach (var branch in aBranches)
            {
                GameObject btn = Instantiate(branchPrefab, branchLayoutPanel);
                btn.GetComponent<BranchChoice>().AssignBranch(flowPlayer, branch);
            }
        }
        else
        {
            GameObject btn = Instantiate(closePrefab, branchLayoutPanel);
            var btnComp = btn.GetComponent<Button>();
            btnComp.onClick.AddListener(CloseDialogueBox);
        }
    }

    void ClearAllBranches()
    {
        foreach(Transform child in branchLayoutPanel)
        {
            Destroy(child.gameObject);
        }
    }

}
