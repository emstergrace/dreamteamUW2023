using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreVariables : MonoBehaviour
{
    public static int totalScore;

    public TextMeshProUGUI highScoreText1, highScoreText2, highScoreText3, highScoreText4, highScoreText5;

    public void Update()
    {
        highScoreText1.text = $"{PlayerPrefs.GetInt("HighScore1", 0)}";
        highScoreText2.text = $"{PlayerPrefs.GetInt("HighScore2", 0)}";
        highScoreText3.text = $"{PlayerPrefs.GetInt("HighScore3", 0)}";
        highScoreText4.text = $"{PlayerPrefs.GetInt("HighScore4", 0)}";
        highScoreText5.text = $"{PlayerPrefs.GetInt("HighScore5", 0)}";
    }

    public void ResetTotalScore()
    {
        totalScore = 0;
    } 
}
