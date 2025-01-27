using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GrinderHandle : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 centerPoint;

    //smoothing the handle
    [SerializeField] private float rotationSpeed = 5f;
    private Quaternion targetRotation;

    //progress of rotation
    [SerializeField] private Slider progressbar; //refers to the progressbar in the UI
    [SerializeField] private float requiredRotations = 3f; //max number of rotations needed until progress bar is full


    private float totalRotations = 0f;
    private float previousAngle;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // Calculate the center of the handle in screen space
        centerPoint = RectTransformUtility.WorldToScreenPoint(null, rectTransform.position);
        targetRotation = rectTransform.rotation; //Starts with the initial rotation
        previousAngle = GetHandleAngle();

    }

    void Update()
    {
        //adds interpolation to the mouse rotation
        rectTransform.rotation = Quaternion.Lerp(rectTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        UpdateProgressBasedOnHandle();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calculate the direction vector from the center to the mouse position
        Vector2 direction = eventData.position - centerPoint;

        // Calculate the angle in degrees (relative to the upward vector)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        //Ensure the angle is wrapped between 0 - 360
        angle = NormalizeAngle(angle);

        //calculate rotation of handle
        float rotationDelta = Mathf.DeltaAngle(previousAngle, angle);
        totalRotations += Mathf.Abs(rotationDelta) / 360f; //increments based on full rotations

        // set the target rotation
        targetRotation = Quaternion.Euler(0, 0, angle);

    }

    private void UpdateProgressBasedOnHandle()
    {
        //Get the current angle of the handle
        float currentAngle = GetHandleAngle();

        //calculate the rotation delta (ensures smooth transitions across 0 and 360 degrees)
        float rotationDelta = Mathf.DeltaAngle(previousAngle, currentAngle);


        //Counts only if the handle is moving forward
        if (Mathf.Abs(rotationDelta) > 0.1f)
        {
            //Convert the rotation delta into progress and add to the totalRotations
            totalRotations += Mathf.Abs(rotationDelta) / 360f;

            //Update the progress bar 
            progressbar.value = Mathf.Clamp01(totalRotations / requiredRotations);

        }

        previousAngle = currentAngle;
    }


    private float NormalizeAngle(float angle)
    {
        //normalise angle to the range pf 0 and 360
        return (angle + 360f) % 360f;
    }

    private float GetHandleAngle()
    {
        //Get the current angle of the RectTransform in degrees
        return NormalizeAngle(rectTransform.eulerAngles.z);
    }

}
