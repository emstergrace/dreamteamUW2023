using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        ScoreVariables.totalScore = 0;
        SceneManager.LoadScene("Levels/Scenes/level1b");
    }
    public void OnHighScoreButton()
    {
        SceneManager.LoadScene("UI/Scenes/High Scores");
    }

    public void OnAboutButton()
    {
        SceneManager.LoadScene("UI/Scenes/About");
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene("UI/Scenes/Credits");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}

