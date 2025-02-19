using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class milkFrothingGame : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("UI Elements")]
    [SerializeField] private RectTransform jug; //jug will be draggable
    [SerializeField] private GameObject targetSlider; //The slider that will move randomly
    [SerializeField] private Image milkVisualCue; //Image that changes color as a warning

    [Header("Settings")]
    [SerializeField] private float badMilkThreshold = 50f; //Max distance allowed before the milk will start to spoil
    [SerializeField] private float warningThreshold = 30f; //Distance where the cue starts to tell player they are close to spoiling
    [SerializeField] private float targetMoveSpeed = 0.5f; //Max speed that the slider can move

    private float jugStartY;
    private bool isDragging = false;

    void Start()
    {
        //Start the slider movement
        StartCoroutine(MoveSliderRandomly());

        //Set's the initial jug position to the targetslider position
        Vector2 initialPosition = jug.anchoredPosition;
        initialPosition.y = targetSlider.GetComponent<RectTransform>().anchoredPosition.y;
        jug.anchoredPosition = initialPosition;

        //Resets the visual cue 
        milkVisualCue.color = Color.white;
    }

    void Update()
    {
        CheckMilkStatus();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Move the jug in Y axis based on where the mouse is
        Vector2 newPosition = jug.anchoredPosition;
        newPosition.y += eventData.delta.y;
        jug.anchoredPosition = newPosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }

    private IEnumerator MoveSliderRandomly()
    {
        while (true)
        {
            //generates a new random Y position for the slider on the right
            float targetY = Random.Range(-100f, 100f); //this is what can be adjusted to fit the UI
            float startY = targetSlider.GetComponent<RectTransform>().anchoredPosition.y;
            float elapsedTime = 0f;

            while (elapsedTime < 2f) // move over 2 seconds
            {
                float newY = Mathf.Lerp(startY, targetY, elapsedTime / 2f);
                Vector2 newPos = targetSlider.GetComponent<RectTransform>().anchoredPosition;
                newPos.y = newY;
                targetSlider.GetComponent<RectTransform>().anchoredPosition = newPos;

                elapsedTime += Time.deltaTime * targetMoveSpeed;
                yield return null;



            }


        }



    }

    private void CheckMilkStatus()
    {
        //Calculte the distance between the jug and the slider on the right

        float distance = Mathf.Abs(jug.anchoredPosition.y - targetSlider.GetComponent<RectTransform>().anchoredPosition.y);

        if (distance > badMilkThreshold)
        {
            //Player failed and milk has gone bad
            Debug.Log("Milk spoilt");
            milkVisualCue.color = Color.red; //Turn indicator red
        }
        else if(distance > warningThreshold)
        {
            //Show a warning that milk is getting spoilt
            milkVisualCue.color = Color.yellow;
        }

        else
        {
            //Resets the colour back to normal
            milkVisualCue.color = Color.green;
        }


    }

}
