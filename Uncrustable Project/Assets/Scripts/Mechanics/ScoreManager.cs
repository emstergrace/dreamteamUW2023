using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score; // this is the score for the current game
    public int highScore; // temporarily testing with just one high score stored, instead of 5
    //public List<int> highScores = new List<int>(); //the first 5 items of this list will be displayed. Undecided if it should save more than that
    public TextMeshProUGUI scoreText, highScoreText;


    private void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
    }

    // prob a cleaner way to do this part.
    public void AddScore(int amount)
    {
        score += amount;
        UpdateHighScore();
    }
    public void SubtractScore(int amount)
    {
        score -= amount;
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            /* this will save the high score on the user's computer, so it is saved between playthroughs. If the player uses a different computer, however,
             * they will not be able to see their previous scores */
            PlayerPrefs.SetInt("HighScore", score);

            // update the high score text dynamically
            UpdateHighScoreText();
        }
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void UpdateScoreText()
    {
        scoreText.text = $"Score: {score, 0}";
    }
}
