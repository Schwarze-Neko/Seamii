using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float smoothTime = 0.3f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (player1 == null || player2 == null) return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint;
        newPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

        float distance = Vector2.Distance(player1.position, player2.position);
        float newZoom = Mathf.Lerp(maxZoom, minZoom, distance / zoomLimiter);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newZoom, Time.deltaTime);
    }

    Vector3 GetCenterPoint()
    {
        return (player1.position + player2.position) / 2f;
    }
}
