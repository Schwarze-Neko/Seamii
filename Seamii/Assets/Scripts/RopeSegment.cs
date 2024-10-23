using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    private HingeJoint2D hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }
    
    // You can add any specific behavior for the rope segment here.
    // For example, if you want to limit the movement or add custom behavior during updates:
    void Update()
    {
        // Example: Adjust joint settings dynamically if needed
        if (hinge != null)
        {
            // Adjust hinge settings or limits if needed
        }
    }
}
