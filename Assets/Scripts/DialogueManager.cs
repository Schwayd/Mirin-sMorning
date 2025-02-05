using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;


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
    }

    //These two methods below extracts information from the node it paused on and tell the flow player what to do next
    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        dialogueText.text = string.Empty;

        var objectWithText = aObject as IObjectWithLocalizableText;
        if(objectWithText != null)
        {
            dialogueText.text = objectWithText.Text;
        }
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {

    }
}
