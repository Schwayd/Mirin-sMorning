using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrewButton : MonoBehaviour
{
    [SerializeField] private Button triggerButton;
    [SerializeField] private GameObject image1;
    [SerializeField] private GameObject image2;
    [SerializeField] private GameObject image3;

    private void Start()
    {
        //Ensure the images are initally hidden
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);

        //Add button listener
        if (triggerButton != null)
            triggerButton.onClick.AddListener(() => StartCoroutine(ShowImagesWithDelay()));
        else
            Debug.LogError("Button not assigned!");
    }


    private IEnumerator ShowImagesWithDelay()
    {
        Debug.Log("Button clicked! Showing images..");

        yield return new WaitForSeconds(1f);
        image1.SetActive(true);
        Debug.Log("Image 1 shown");

        yield return new WaitForSeconds(1f);
        image2.SetActive(true);
        Debug.Log("Image 2 shown");

        yield return new WaitForSeconds(1f);
        image3.SetActive(true);
        Debug.Log("Image 3 shown");

        yield return new WaitForSeconds(1.5f);
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);


    }




}
