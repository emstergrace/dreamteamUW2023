using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Levels/Scenes/SampleScene");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

