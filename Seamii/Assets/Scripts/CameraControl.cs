using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player1;  // Reference to Player 1
    public Transform player2;  // Reference to Player 2

    public float smoothSpeed = 0.125f;  // How smoothly the camera follows
    public float minDistance = 5f;      // Minimum distance before the camera zooms out
    public float maxDistance = 15f;     // Maximum distance for zooming
    public float zoomSpeed = 10f;       // Speed of zooming in and out
    public float rotationSpeed = 5f;    // Speed of rotation around the z-axis

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera reference
    }

    void FixedUpdate()
    {
        // Update the camera position, zoom, and rotation based on the players' positions
        UpdateCameraPosition();
        UpdateCameraRotation();
    }

    private void UpdateCameraPosition()
    {
        // Calculate the midpoint between both players
        Vector3 midpoint = (player1.position + player2.position) / 2f;

        // Keep the camera on the same z position since we're in 2D
        midpoint.z = transform.position.z;

        // Move the camera smoothly to the midpoint between players
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, midpoint, smoothSpeed);
        transform.position = smoothedPosition;

        // Adjust camera zoom based on the distance between the two players (x and y only)
        float distanceBetweenPlayers = Vector2.Distance(player1.position, player2.position);
        float newZoom = Mathf.Lerp(maxDistance, minDistance, distanceBetweenPlayers / maxDistance);
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, newZoom, Time.deltaTime * zoomSpeed);
    }

    private void UpdateCameraRotation()
    {
        // Calculate the angle between the two players
        Vector2 direction = player2.position - player1.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Smoothly rotate the camera to match the angle between the two players
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
