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
        previousAngle = GetAngleFromPosition(centerPoint); // Initialize Previous angle

    }

    void Update()
    {
        //adds interpolation to the mouse rotation
        rectTransform.rotation = Quaternion.Lerp(rectTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calculate the direction vector from the center to the mouse position
        Vector2 direction = eventData.position - centerPoint;

        // Calculate the angle in degrees (relative to the upward vector)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        //Ensure the angle is wrapped between 0 - 360
        angle = NormalizeAngle(angle);

        //calculate rotation
        float rotationDelta = Mathf.DeltaAngle(previousAngle, angle);
        totalRotations += Mathf.Abs(rotationDelta) / 360f; //increments based on full rotations

        //Update progress bar
        progressbar.value = Mathf.Clamp01(totalRotations / requiredRotations);

        // set the target rotation and change the previous angle
        targetRotation = Quaternion.Euler(0, 0, angle);
        previousAngle = angle;

    }

    private float GetAngleFromPosition(Vector2 position)
    {
        Vector2 direction = position - centerPoint;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        return NormalizeAngle(angle);
    }

    private float NormalizeAngle(float angle)
    {
        return (angle + 360f) % 360f; // Wraps angle to be 0 - 360
    }

}
