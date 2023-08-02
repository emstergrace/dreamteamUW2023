using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, highScoreText;


    private void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddScore(int amount)
    {
        ScoreVariables.totalScore += amount;
        UpdateScoreText();
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (ScoreVariables.totalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            /* this will save the high score on the user's computer, so it is saved between playthroughs. If the player uses a different computer, however,
             * they will not be able to see their previous scores */
            PlayerPrefs.SetInt("HighScore", ScoreVariables.totalScore);

            // update the high score text dynamically
            UpdateHighScoreText();
        }
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void UpdateScoreText()
    {
        scoreText.text = $"Score: {ScoreVariables.totalScore, 0}";
    }

    public void ResetScore()
    {
        ScoreVariables.totalScore = 0;
    }
}
