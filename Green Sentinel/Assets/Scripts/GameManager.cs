using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int iCurrentLives = 3;

    public float fRespawnTime = 2f;

    private bool bCanPause;

    public string sNextLevel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        iCurrentLives = PlayerPrefs.GetInt("CurrentLives");

        //makes changes to the text that displays the number of lives the player has remaining
        UIManager.instance.tLivesText.text = "x " + iCurrentLives;

        //PlayerBomb.instance.iBombNo = PlayerPrefs.GetInt("CurrentBombs");

        bCanPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if the player has pressed the escape key and they are able to pause the game
        if(Input.GetButtonDown("Pause") && bCanPause)
        {
            PauseMenu();
        }
    }

    public void KillPlayer()
    {
        iCurrentLives--;

        //used to display the amount of lives the player has
        UIManager.instance.tLivesText.text = "x " + iCurrentLives;

        if(iCurrentLives > 0)
        {
            //runs the coroutine function that will respawn the player
            StartCoroutine(RespawnCo());
        }
        else
        {
            //calls the game over screen from the UI manager screen and turns it on
            UIManager.instance.gOGameOverScreen.SetActive(true);

            //stops the waves being able to spawn whilst the game over screen is displayed
            WaveManager.instance.bCanWavesSpawn = false;

            bCanPause = false;
        }
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(fRespawnTime);

        HealthManager.instance.Respawn();

        WaveManager.instance.ContinueSpawning();
    }

    public IEnumerator LevelCompleteCo()
    {
        MusicController.instance.VictoryScreenMusic(); 

        //turns the level complete screen on
        UIManager.instance.gOLevelCompleteScreen.SetActive(true);

        bCanPause = false;

        //stops the player being able to move during the level complete screen by looking in the PlayerController script and making stopMovement true
        PlayerController.instance.bStopMovement = true;

        //PlayerPrefs.SetInt("CurrentBombs", PlayerBomb.instance.iBombNo);

        PlayerPrefs.SetInt("CurrentLives", iCurrentLives);

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(sNextLevel);
    }

    public IEnumerator BossDefeatCo()
    {
        Debug.Log("turning health off");
        UIManager.instance.sBossHealth.gameObject.SetActive(false);
        Debug.Log("turning name off");
        UIManager.instance.tBossName.gameObject.SetActive(false);

        Debug.Log("yielding");
        yield return new WaitForSeconds(.5f);

        Debug.Log("running levelcomplete co");
        StartCoroutine(LevelCompleteCo());
    }

    public void PauseMenu()
    {
        if(UIManager.instance.gOPauseScreen.activeInHierarchy)
        {
            UIManager.instance.gOPauseScreen.SetActive(false);

            Time.timeScale = 1f;

            PlayerController.instance.bStopMovement = false;

        }
        else
        {
            UIManager.instance.gOPauseScreen.SetActive(true);

            //pauses everything in the game when the pause menu is active
            Time.timeScale = 0f;

            //stops the player being able to move or shoot whilst the pause menu is active
            PlayerController.instance.bStopMovement = true;
        }
    }
}
