using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook; // Player 1's Rigidbody2D (Boat 1)
    public Rigidbody2D endAnchor; // Player 2's Rigidbody2D (Boat 2)
    public GameObject ropeSegmentPrefab; // Prefab for each segment of the rope
    public int segmentCount = 8; // Number of segments

    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Vector2 startPosition = hook.position;
        Vector2 endPosition = endAnchor.position;
        Vector2 direction = (endPosition - startPosition).normalized;
        float segmentDistance = Vector2.Distance(startPosition, endPosition) / segmentCount;

        Rigidbody2D previousBody = hook;

        // Create rope segments along the line between hook and endAnchor
        for (int i = 0; i < segmentCount; i++)
        {
            Vector2 segmentPosition = startPosition + direction * segmentDistance * (i + 1);
            GameObject newSegment = Instantiate(ropeSegmentPrefab, segmentPosition, Quaternion.identity, transform);

            HingeJoint2D joint = newSegment.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousBody;

            previousBody = newSegment.GetComponent<Rigidbody2D>();
        }

        // Attach the last segment to the endAnchor (Boat 2)
        HingeJoint2D endJoint = previousBody.gameObject.AddComponent<HingeJoint2D>();
        endJoint.connectedBody = endAnchor;
    }
}
