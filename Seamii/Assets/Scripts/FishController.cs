using UnityEngine;

public class FishController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "robe-2_1")
        {
            Destroy(gameObject); // Destroy the fish
            GameManager.Instance.LoseLife(); // Decrease life via GameManager
        }
    }
}
