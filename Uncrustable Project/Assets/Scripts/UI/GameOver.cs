using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Levels/Scenes/SampleScene");
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

