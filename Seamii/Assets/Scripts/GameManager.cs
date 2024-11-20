using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include the TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;
    public int lives = 3; // Initial lives
    public Image[] hearts; // Heart UI for lives

    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text field

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
        UpdateScoreUI();
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
        UpdateScoreUI(); // Update the score UI
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

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
