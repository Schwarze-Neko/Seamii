using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D player1; // Player 1's Rigidbody2D
    public Rigidbody2D player2; // Player 2's Rigidbody2D
    public GameObject ropeSegmentPrefab; // Prefab for each segment of the rope
    public int segmentCount = 10; // Number of segments in the rope

    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Vector2 direction = (player2.position - player1.position).normalized;
        float segmentDistance = Vector2.Distance(player1.position, player2.position) / segmentCount;

        Rigidbody2D previousBody = player1;

        // Create rope segments along the line between player1 and player2
        for (int i = 0; i < segmentCount; i++)
        {
            Vector2 segmentPosition = player1.position + direction * segmentDistance * (i + 1);
            GameObject newSegment = Instantiate(ropeSegmentPrefab, segmentPosition, Quaternion.identity, transform);
            HingeJoint2D joint = newSegment.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousBody;

            previousBody = newSegment.GetComponent<Rigidbody2D>();
        }

        // Attach the last segment to Player 2
        HingeJoint2D endJoint = previousBody.gameObject.AddComponent<HingeJoint2D>();
        endJoint.connectedBody = player2;
    }
}
