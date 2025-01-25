using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderMouseRotate : MonoBehaviour
{

    public float rotationSpeed;

    private void OnMouseDrag()
    {
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(Vector3.down, rotX, Space.World);
        transform.Rotate(Vector3.right, rotY, Space.World);
    }



}

