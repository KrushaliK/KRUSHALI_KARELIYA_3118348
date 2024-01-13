using UnityEngine;

public class BasicCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 500f;

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
}
