using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        ScoreVariables.totalScore = 0;
        SceneManager.LoadScene("Levels/Scenes/UPDATEDLEVELONE");
    }
    public void OnHighScoreButton()
    {
        SceneManager.LoadScene("UI/Scenes/High Scores");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}

