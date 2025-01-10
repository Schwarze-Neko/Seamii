using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;
    public int lives = 3; // Initial lives
    public Image[] hearts; // Heart UI for lives
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text field
    public GameObject gameOverScreen; // Reference to the Game Over UI Canvas
    public TextMeshProUGUI timerText; // Timer UI Text
    public GameObject scoreScreen; // Final score screen
    public TextMeshProUGUI finalScoreText; // Text to display the final score

    public float timerDuration = 60f; // Duration of the timer in seconds
    private float timer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        InitializeGame();
    }

    private void InitializeGame()
    {
        score = 0;
        lives = hearts.Length; // Reset lives to match the number of hearts
        timer = timerDuration; // Set the timer
        UpdateScoreUI();
        ResetHearts();
        HideGameOverScreen();
        HideScoreScreen();
        UpdateTimerUI();
    }

    private void Update()
    {
        // Decrease the timer
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI();

            if (timer <= 0)
            {
                timer = 0; // Ensure it doesn't go below 0
                ShowScoreScreen();
            }
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
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
            if (hearts[lives] != null)
            {
                hearts[lives].enabled = false; // Disable the heart visually
            }
        }

        if (lives == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Show Game Over screen
        }
        Time.timeScale = 0f; // Pause the game
    }

    private void ShowScoreScreen()
    {
        Debug.Log("Time Up! Showing Score Screen.");
        if (scoreScreen != null)
        {
            scoreScreen.SetActive(true); // Show the score screen
        }
        Time.timeScale = 0f; // Pause the game

        // Display the final score
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + score;
        }
    }

    private void HideScoreScreen()
    {
        if (scoreScreen != null)
        {
            scoreScreen.SetActive(false); // Hide the score screen
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(ResetAfterSceneLoad());
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    private void ResetHearts()
    {
        foreach (var heart in hearts)
        {
            if (heart != null)
            {
                heart.enabled = true; // Re-enable all heart images
            }
        }
    }

    private void HideGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false); // Hide Game Over screen
        }
    }

    private System.Collections.IEnumerator ResetAfterSceneLoad()
    {
        yield return null; // Wait until the scene reloads
        InitializeGame(); // Reinitialize game state
    }
}
