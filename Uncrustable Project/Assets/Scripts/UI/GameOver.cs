using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnPlayButton()
    {
        ScoreVariables.totalScore = 0;
        SceneManager.LoadScene("Levels/Scenes/level1b");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("UI/Scenes/Main Menu");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

