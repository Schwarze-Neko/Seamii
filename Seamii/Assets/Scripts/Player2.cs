using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed = 4f; // Movement speed
    private Camera mainCamera;

    void Start()
    {
        // Get the main camera reference
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        // Get input for left/right (Left/Right arrows) and up/down (Up/Down arrows) movement
        float moveX = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = moveSpeed * Time.deltaTime;
        }

        float moveY = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY = moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -moveSpeed * Time.deltaTime;
        }

        // Calculate movement relative to the camera's rotation
        Vector2 movementInput = new Vector2(moveX, moveY);
        Vector2 cameraRight = mainCamera.transform.right;
        Vector2 cameraUp = mainCamera.transform.up;

        // Apply camera-relative movement
        Vector3 movement = (cameraRight * movementInput.x) + (cameraUp * movementInput.y);
        movement.z = 0; // Ensure the player stays in the 2D plane

        // Update the player's position
        Vector3 newPosition = transform.position + movement;

        // Clamp the player's position within the camera's view
        newPosition = ClampPositionToCameraBounds(newPosition);

        // Set the clamped position
        transform.position = newPosition;
    }

    private Vector3 ClampPositionToCameraBounds(Vector3 position)
    {
        // Get the camera's orthographic size (half of the camera's height)
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        // Calculate camera boundaries in world space
        float minX = mainCamera.transform.position.x - camWidth;
        float maxX = mainCamera.transform.position.x + camWidth;
        float minY = mainCamera.transform.position.y - camHeight;
        float maxY = mainCamera.transform.position.y + camHeight;

        // Clamp the player's position within the camera bounds
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        return position;
    }
}
