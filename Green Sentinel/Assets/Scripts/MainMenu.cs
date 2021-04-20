using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sFirstLevel;

    public void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(sFirstLevel);

        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
