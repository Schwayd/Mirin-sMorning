using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine.UI;

public class BranchChoice : MonoBehaviour
{
    private Branch branch;
    private ArticyFlowPlayer flowPlayer;
    [SerializeField]
    Text buttonText;

    public void AssignBranch(ArticyFlowPlayer aFlowPlayer, Branch aBranch)
    {
        branch = aBranch;
        flowPlayer = aFlowPlayer;
        IFlowObject target = aBranch.Target;
        buttonText.text = string.Empty;

        var objectWithMenuText = target as IObjectWithMenuText;
        if (objectWithMenuText != null)
        {
            //if we have menu text then we display it
            buttonText.text = objectWithMenuText.MenuText;
        }

        if (string.IsNullOrEmpty(buttonText.text))
        {
            //If the dialogue is empty then it will show the >>> text to fill in the empty string
            buttonText.text = ">>>";
        }
    }

    public void OnBranchSelected()
    {
        flowPlayer.Play(branch);
    }

}
