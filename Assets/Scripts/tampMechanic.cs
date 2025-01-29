using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tampMechanic : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform tampObject;
    [SerializeField] private Slider progressBar;
    [SerializeField] private float maxCompression = -200f;
    [SerializeField] private float resistanceFactor = 5f;
    [SerializeField] private float completionThreshold = 0.95f;

    private float currentCompression = 0f;
    private bool isComplete = false;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        if (isComplete) return;

        float dragAmount = eventData.delta.y;
        float effectiveDrag = dragAmount / (1f + resistanceFactor * currentCompression);

        //Update compression (clamp between 0 and 1)
        currentCompression = Mathf.Clamp01(currentCompression - effectiveDrag * Time.deltaTime);

        Vector3 tampPosition = tampObject.localPosition;
        tampPosition.y = Mathf.Lerp(0f, maxCompression, currentCompression);
        tampObject.localPosition = tampPosition;

        //Update the progress bar
        progressBar.value = currentCompression;

        //check if tamping is complete
        if (currentCompression >= completionThreshold)
        {
            OnTampingComplete();
        }

    }

    private void OnTampingComplete()
    {
        isComplete = true;
        Debug.Log("Tamping complete!");
        //add sounds or effects
    }

}
