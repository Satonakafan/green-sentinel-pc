using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public static PlayerBomb instance;

    public int iBombNo;
    public int iMaxBombNo;

    public GameObject gOBombEffect;

    private AudioSource aSExplosion;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        aSExplosion = GetComponent<AudioSource>();

       // iBombNo = GameManager.instance.PlayerPrefs.GetInt("CurrentBombs");
    }

    public void BombActivate()
    {
        if (iBombNo > 0)
        {
            aSExplosion.time = 0.1f;
            aSExplosion.Play();

            Instantiate(gOBombEffect, new Vector3(0, 0, 0), transform.rotation);
           
            //goes into the arrayt DestroyEnemies and finds any gameObject with the tag Enemy
                GameObject[] gODestroyEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            //then each object with that tag will be labelled enemyToDestroy
            foreach (GameObject enemyToDestroy in gODestroyEnemies)
            {
                GameObject.Destroy(enemyToDestroy);
            }

            GameObject[] gOEnemyShots = GameObject.FindGameObjectsWithTag("Enemy Shots");

            foreach (GameObject shotsToDestroy in gOEnemyShots)
            {
                GameObject.Destroy(shotsToDestroy);
            }

            iBombNo--;

            UIManager.instance.tBombText.text = "x " + iBombNo;

            Debug.Log("Bomb Activated");
        }
    }

    public void IncreaseBombs()
    {
        Debug.Log("Bomb +1");

        iBombNo++;

        if (iBombNo > iMaxBombNo)
        {
            iBombNo = 3;
            Debug.Log("Max Amount Exceeded");
        }

        UIManager.instance.tBombText.text = "x " + iBombNo;
    }

  /*  public void CurrentBombNo()
    {
        PlayerPrefs.GetInt("CurrentBombs", iBombNo);
    }
    */
}
