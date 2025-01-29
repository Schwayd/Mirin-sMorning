using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tampMechanic : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform tampObject;
    [SerializeField] private Slider progressBar;
    [SerializeField] private float maxCompression = -200f;
    [SerializeField] private float resistanceFactor = 5f;
    [SerializeField] private float smoothSpeed = 10f;
    [SerializeField] private float successThreshold = 0.9f;
    [SerializeField] private float failureThreshold = 1.05f;

    private float targetCompression = 0f;
    private float currentCompression = 0f;
    private bool isComplete = false;

    void Start()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isComplete) return;

        float dragAmount = eventData.delta.y * 0.002f;
        float effectiveDrag = dragAmount / (1f + resistanceFactor * Mathf.Abs(targetCompression));

        //Allows tamp to go over 100%
        targetCompression = Mathf.Clamp(targetCompression - effectiveDrag, 0f, 1.1f);

        
    }

    void Update()
    {
      
        if (isComplete) return;

        currentCompression = Mathf.Lerp(currentCompression, targetCompression, Time.deltaTime * smoothSpeed);

        Vector3 tampPosition = tampObject.localPosition;
        tampPosition.y = Mathf.Lerp(0f, maxCompression, currentCompression);
        tampObject.localPosition = tampPosition;

        //Update the progress bar
        progressBar.value = Mathf.Clamp01(currentCompression);


        //check if tamping is unsuccessfull
        if (currentCompression > failureThreshold)
        {
            OnTampingFailure();
        }


    }
    public void OnEndDrag(PointerEventData eventData)
    {
       

        //Checks to see if the player releases mouse in 90-100%
        if (isComplete) return;

        if (targetCompression >= successThreshold && targetCompression <= 1.0f)
        {
            OnTampingSuccess();
        }
        
    }



    private void OnTampingSuccess()
    {
        isComplete = true;
        Debug.Log("Tamping success!");
        //add sounds or effects for success

        //lock tamp at success
        targetCompression = Mathf.Clamp(targetCompression, successThreshold, 1.0f);
        currentCompression = targetCompression;
    }

    private void OnTampingFailure()
    {
        Debug.Log("Tamping failed! Restarting...");
        RestartTamping();
    }

    private void RestartTamping()
    {
        isComplete = false;
        currentCompression = 0f;
        tampObject.localPosition = new Vector3(tampObject.localPosition.x, 0, tampObject.localPosition.z);
        progressBar.value = 0f;
        targetCompression = 0f;
   
    }

}
