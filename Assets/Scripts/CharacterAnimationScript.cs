using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationScript : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public float rotationSpeed = 500f;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement and rotate direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 rotateDirection = new Vector3(horizontalInput, 0f, verticalInput);

        // Move the character
        MoveCharacter(movement);

        // Rotate the character
        RotateCharacter(rotateDirection);

        // Update the animator parameters based on movement
        UpdateAnimatorParameters(movement.magnitude);
    }

    void MoveCharacter(Vector3 movement)
    {
        // Translate the character based on input
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    void RotateCharacter(Vector3 rotateDirection)
    {
        // Rotate the character to face the direction of movement
        if (rotateDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rotateDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void UpdateAnimatorParameters(float speed)
    {
        // Update animator parameters for character animation
        animator.SetFloat("Speed", speed);

        // Example: If you have an "IsRunning" parameter in your animator controller
        // animator.SetBool("IsRunning", speed > 0.1f);
    }
}
