using UnityEngine;
using UnityEngine.EventSystems;

public class GrinderHandle : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 centerPoint;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // Calculate the center of the handle in screen space
        centerPoint = RectTransformUtility.WorldToScreenPoint(null, rectTransform.position);
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
        rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
