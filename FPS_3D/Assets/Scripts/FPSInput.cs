using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 3.0f;
    public float gravity = -9.8f;
    public float jumpSpeed = 7.5f;
    private CharacterController charController;
    private float verticalSpeed = 0; // track vertical speed separately

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (charController.isGrounded)
        {
            verticalSpeed = 0; // reset vertical speed upon landing
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = jumpSpeed;
            }
        }
        else
        {
            verticalSpeed += gravity * Time.deltaTime;
        }
        movement.y = verticalSpeed; // apply vertical speed 

        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
