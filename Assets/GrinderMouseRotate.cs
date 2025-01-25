using UnityEngine;
using UnityEngine.EventSystems;

public class GrinderHandle : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 centerPoint;

    //smoothing
    [SerializeField] private float rotationSpeed = 5f;
    private Quaternion targetRotation;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // Calculate the center of the handle in screen space
        centerPoint = RectTransformUtility.WorldToScreenPoint(null, rectTransform.position);
        targetRotation = rectTransform.rotation; //Starts with the initial rotation
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Correct the angle to match the initial handle orientation
        angle -= 90; // Adjust this based on your handle's initial rotation in the Scene

        // Apply the rotation to the handle
        targetRotation = Quaternion.Euler(0, 0, angle);
    }
}
