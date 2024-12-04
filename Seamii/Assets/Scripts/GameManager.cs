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

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
        InitializeGame();
    }

    private void InitializeGame()
    {
        score = 0;
        lives = hearts.Length; // Reset lives to match the number of hearts
        UpdateScoreUI();
        ResetHearts();
        HideGameOverScreen();
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
