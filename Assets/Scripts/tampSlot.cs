using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tampSlot : MonoBehaviour, IDropHandler
{
    
    [SerializeField]
    private GameObject portaSide;
    [SerializeField]
    private GameObject portaFront;
    [SerializeField]
    private GameObject BrewButton;

    void Start()
    {
        portaFront.SetActive(false);
        BrewButton.SetActive(false);
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData != null)
        {
            //gets the object attached to the pointer dragging and snaps to the location of the tampConnecter eobject
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            portaFront.SetActive(true);
            portaSide.SetActive(false);
            BrewButton.SetActive(true);

        }
    }

   
}
