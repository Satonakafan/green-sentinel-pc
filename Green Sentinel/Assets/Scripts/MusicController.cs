using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource aSMainMenu, aSLevel1, aSBoss, aSVictoryScreen, aSCredits;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        aSLevel1.Play();
    }

    public void MainMenuMusic()
    {
        StopAllMusic();
        aSMainMenu.Play();

    }

    public void Level1Music()
    {
        StopAllMusic();
        aSLevel1.Play();
    }

    public void BossMusic()
    {
        StopAllMusic();
        aSBoss.Play();

    }

    public void VictoryScreenMusic()
    {
        StopAllMusic();
        aSVictoryScreen.Play();

    }

    public void CreditMusic()
    {
        StopAllMusic();
        aSCredits.Play();

    }

    public void StopAllMusic()
    {
        aSMainMenu.Stop();
        aSLevel1.Stop();
        aSBoss.Stop();
        aSVictoryScreen.Stop();
        aSCredits.Stop();
    }
}
