using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensH = 9.0f;
    public float sensV = 9.0f;

    public float minV = -45f;
    public float maxV = 45f;

    private float verticalRot = 0;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)  //Horiz rotation
        {
            transform.Rotate(0, sensH * Input.GetAxis("Mouse X"), 0);
        } 
        else if (axes == RotationAxes.MouseY)  //Vert rotation
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensV;
            verticalRot = Mathf.Clamp(verticalRot, minV, maxV);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        } 
        else  //Both Horiz and Vert rotation
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensV;
            verticalRot = Mathf.Clamp(verticalRot, minV, maxV);

            float delta = Input.GetAxis("Mouse X") * sensH;
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}
