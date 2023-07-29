using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public List<int> highScores = new List<int>(); //the first 5 items of this list will be displayed. Undecided if it should save more than that
    public Text scoreText;

    public void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public void SubtractScore(int amount)
    {
        score -= amount;
    }
}
