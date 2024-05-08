using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to access UI components

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager sManager;
    public int playerScore = 0;
    public Text scoreText; // Reference to the UI text component

    void Start()
    {
        sManager = this;
        UpdateScoreText(); // Update the score text when the game starts
    }

    public void IncreaseScore(int Increase)
    {
        playerScore += Increase;
        UpdateScoreText(); // Update the score text whenever score changes
    }

    void UpdateScoreText()
    {
        // Check if the text component is assigned
        if (scoreText != null)
        {
            // Update the text to display the current score
            scoreText.text = "Score: " + playerScore.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text component not assigned!");
        }
    }
}