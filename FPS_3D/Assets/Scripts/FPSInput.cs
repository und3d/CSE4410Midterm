using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float sprintSpeed = 8.0f; 
    public float crouchSpeed = 1.5f; 
    public float gravity = -9.8f;
    public float jumpSpeed = 7.5f;
    public float crouchHeight = 1.0f; 
    public float standHeight = 2.0f; 
    private CharacterController charController;
    private float verticalSpeed = 0; 

    void Start()
    {
        charController = GetComponent<CharacterController>();
        charController.height = standHeight; // initial height for crouching
    }

    void Update()
    {
        float currentSpeed = speed;

        // check if shift key is pressed, if so apply sprint force
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }

        // check if left ctrl clicked to apply crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = crouchSpeed;
            charController.height = crouchHeight; 
        }
        else
        {
            charController.height = standHeight; // when ctrl releases, return to normal player height
        }

        float deltaX = Input.GetAxis("Horizontal") * currentSpeed;
        float deltaZ = Input.GetAxis("Vertical") * currentSpeed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // check if player is on ground for jump
        if (charController.isGrounded)
        {
            verticalSpeed = gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = jumpSpeed; 
            }
        }
        else
        {
            verticalSpeed += gravity * Time.deltaTime; // if not on ground, apply gravity to player
        }

        movement.y = verticalSpeed;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
