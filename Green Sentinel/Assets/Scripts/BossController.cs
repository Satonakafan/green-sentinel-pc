using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public static BossController instance;

    public int iCurrentHealth, iMaxHealth;

    public GameObject gOShotToFire;
    public Transform tFirePoint;
    public Transform tFirePoint2;
    public float fTimeBetweenShots;
    public float fTimeBetweenShots2;
    public float fShotCounter;

    public GameObject gODeathEffect;

    public bool bCanShoot;
    private bool bIsAllowedToShoot; 

    public bool bIsBossDead = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fShotCounter = fTimeBetweenShots;
        fShotCounter = fTimeBetweenShots2;

        iCurrentHealth = iMaxHealth;

        UIManager.instance.sBossHealth.maxValue = iMaxHealth;

        UIManager.instance.sBossHealth.value = iCurrentHealth;

        UIManager.instance.sBossHealth.gameObject.SetActive(true);

        MusicController.instance.BossMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsAllowedToShoot)
        {
            fShotCounter -= Time.deltaTime;
            if (fShotCounter <= 0)
            {
                fShotCounter = fTimeBetweenShots;
                Instantiate(gOShotToFire, tFirePoint.position, tFirePoint.rotation);

                fShotCounter = fTimeBetweenShots2;
                Instantiate(gOShotToFire, tFirePoint2.position, tFirePoint2.rotation);
            }
        }

        if(!bIsBossDead)
        {
            WaveManager.instance.bCanWavesSpawn = false;
        }
    }

    public void HurtBoss()
    {

        if (!bIsBossDead)
        {
            iCurrentHealth--;

            UIManager.instance.sBossHealth.value = iCurrentHealth;

            if (iCurrentHealth <= 0)
            {
                bIsBossDead = true;
                Debug.Log("Boss dead");

                Instantiate(gODeathEffect, transform.position, transform.rotation);

                Destroy(gameObject);

            }
        }
            WaveManager.instance.bCanWavesSpawn = true;
    }


    //when the object appears on screen it will run this
    private void OnBecameVisible()
    {
        if (bCanShoot)
        {
            //when the object comes onto the screen they are allowed to start shooting
            bIsAllowedToShoot = true;
        }
    }
}
