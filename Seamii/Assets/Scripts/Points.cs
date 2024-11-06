using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    // Public variable to hold the score
    public int score = 0;

    // This function will be called whenever a trash object is collected
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as "Trash"
        if (other.CompareTag("Trash"))
        {
            // Increase score by 1
            score += 1;

            // Destroy the trash object
            Destroy(other.gameObject);
        }
    }

    // Optional: Display score in the Unity console for testing
    private void Update()
    {
        Debug.Log("Current Score: " + score);
    }
}
