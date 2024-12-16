using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; // UI Text element to display the score
    public Text livesText;
    public static float score = 0; // Player's score
    public float scoreIncrement = 10; // Amount of score to add per second
    public static float lives = 3;

    private void Start()
    {
        // Ensure the score text starts at 0
        UpdateScoreUI();
    }

    private void Update()
    {
        // Increment the score based on time
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneName = currentScene.buildIndex;
        if(sceneName == 0)
        {
            score += scoreIncrement * Time.deltaTime;
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // Update the UI text with the current score
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        livesText.text = "Lives: " + Mathf.FloorToInt(lives).ToString();
    }
}
