using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Variables to track points and lives
    private int score;
    public int lives = 3; // Set initial lives
    public Image[] hearts; // Array of hearts to represent lives

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeGame();
    }

    private void InitializeGame()
    {
        score = 0;
    }

    // Method to update the score
    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    // Method to handle losing a life
    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            hearts[lives].enabled = false; // Update heart UI
        }
        if (lives == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        // Implement game-over logic here
    }
}
