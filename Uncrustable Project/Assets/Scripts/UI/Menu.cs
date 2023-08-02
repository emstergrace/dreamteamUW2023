using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Levels/Scenes/UPDATEDLEVELONE");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

