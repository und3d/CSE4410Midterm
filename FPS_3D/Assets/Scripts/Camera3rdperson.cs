using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // The target the camera should follow (your character)
    public Vector3 offset = new Vector3(0, 2.5f, -7); // Adjust these values to get the right camera position

    void LateUpdate()
    {
        transform.position = target.position + offset; // Update camera position based on the target's position
        transform.LookAt(target); // Make sure the camera always looks at the target
    }
}

