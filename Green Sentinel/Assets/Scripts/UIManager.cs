using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gOGameOverScreen;
    public GameObject gOLevelCompleteScreen;
    public GameObject gOPauseScreen;

    public Text tLivesText, tShieldText, tBombText;

    public Text tBossName;
    public Slider sBossHealth;

    private void Awake()
    {
        instance = this;
    }

    public void Resume()
    {
        GameManager.instance.PauseMenu();

        Time.timeScale = 1f;
    }

    public void Restart()
    {
        //reloads the scene that is currently active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1f;
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
