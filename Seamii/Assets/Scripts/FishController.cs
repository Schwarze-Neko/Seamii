using UnityEngine;
using UnityEngine.UI; // To access the UI components

public class FishController : MonoBehaviour
{
    public Image[] hearts; // Array to hold heart UI elements
    private int heartIndex = 2; // Start with the last heart (assuming there are 3 hearts in the UI)

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "robe-2_1")
        {
            // Destroy the fish (make it disappear)
            Destroy(gameObject);
            
            // Check if there are still hearts left to disable
            if (heartIndex >= 0)
            {
                // Disable the current heart image
                hearts[heartIndex].enabled = false;
                heartIndex--; // Move to the next heart
            }
        }
    }
}
/*
using UnityEngine;

public class FishController : MonoBehaviour
{
    // Reference to the UIManager to update the hearts
    public UIManager uiManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the fish collides with a rope segment
        if (collision.gameObject.tag == "ropeSegment")
        {
            Destroy(gameObject); // This makes the fish disappear
            uiManager.RemoveHeart(); // This reduces the heart count in the UI
        }
    }
}

*/