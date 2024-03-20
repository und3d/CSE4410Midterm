using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafingShooter : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Movement speed of the character
    private CharacterController characterController;

    void Start()
    {
        // Get the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input from horizontal and vertical axes
        // Horizontal input for strafing, Vertical for forward/backward movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        moveDirection.Normalize(); // Normalize vector to ensure consistent movement speed in all directions

        // Move the character
        characterController.Move(moveSpeed * Time.deltaTime * moveDirection);
    }
}
