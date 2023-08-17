using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, highScoreText;

    static List<int> HighScores;


    private void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddScore(int amount)
    {
        ScoreVariables.totalScore += amount;
        UpdateScoreText();
    }


    public void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore1", 0)}";
    }

    public static void UpdateAllOfHighScores()
    {
        // if this needs to be expanded to more than 5 scores, make this a foreach
        HighScores = new List<int>();
        HighScores.Add(PlayerPrefs.GetInt("HighScore1", 0));
        HighScores.Add(PlayerPrefs.GetInt("HighScore2", 0));
        HighScores.Add(PlayerPrefs.GetInt("HighScore3", 0));
        HighScores.Add(PlayerPrefs.GetInt("HighScore4", 0));
        HighScores.Add(PlayerPrefs.GetInt("HighScore5", 0));
        HighScores.Add(ScoreVariables.totalScore);

        // if current score is too low, nothing will change. If it's high, it will replace one of the other high scores
        HighScores.Sort();
        HighScores.Reverse();

        PlayerPrefs.SetInt("HighScore1", HighScores[0]);
        PlayerPrefs.SetInt("HighScore2", HighScores[1]);
        PlayerPrefs.SetInt("HighScore3", HighScores[2]);
        PlayerPrefs.SetInt("HighScore4", HighScores[3]);
        PlayerPrefs.SetInt("HighScore5", HighScores[4]);
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
