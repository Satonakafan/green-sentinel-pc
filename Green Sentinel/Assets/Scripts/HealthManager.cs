using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int iCurrentHealth;
    public int iMaxHealth;

    public GameObject gOPlayerDeathExplosion;

    public float fInvincibilityTime = 3f;
    private float fInvincibilityCounter;

    public SpriteRenderer SRInvincibiltySprite;

    public int iShieldHealth;
    public int iMaxShieldHealth;
    public GameObject gOShield;
    public int iShieldNo;
    public int iMaxShieldNo = 3;
    public bool bCanUseShield;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        iCurrentHealth = iMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(fInvincibilityCounter >= 0)
        {
            fInvincibilityCounter -= Time.deltaTime;

            if(fInvincibilityCounter <= 0)
            {
                SRInvincibiltySprite.color = new Color(SRInvincibiltySprite.color.r, SRInvincibiltySprite.color.g, SRInvincibiltySprite.color.b, 1f);
            }
        }
    }

    public void HurtPlayer()
    {
        if (fInvincibilityCounter <= 0)
        {
            if(gOShield.activeInHierarchy)
            {
                iShieldHealth--;

                if(iShieldHealth <= 0)
                {
                    gOShield.SetActive(false);
                }
            }
            else
            {
                Instantiate(gOPlayerDeathExplosion, transform.position, transform.rotation);
                gameObject.SetActive(false);

                GameManager.instance.KillPlayer();

                WaveManager.instance.bCanWavesSpawn = false;
            }
        }
    }

    public void Respawn()
    {
        gameObject.SetActive(true);

        iCurrentHealth = iMaxHealth;

        fInvincibilityCounter = fInvincibilityTime;

        SRInvincibiltySprite.color = new Color(SRInvincibiltySprite.color.r, SRInvincibiltySprite.color.g, SRInvincibiltySprite.color.b, .5f);
    }

    public void ShieldActivate()
    {
        if (iShieldNo > 0)
        {
            if (!gOShield.activeInHierarchy)
            {
                iShieldNo--;
                UIManager.instance.tShieldText.text = "x " + iShieldNo;
                gOShield.SetActive(true);
                iShieldHealth = iMaxShieldHealth;
                Debug.Log("Barrier Daze");
            }
        }
    }

    public void IncreaseShieldNo()
    {
        Debug.Log("Shield +1");

        iShieldNo++;

        if (iShieldNo > iMaxShieldNo)
        {
            iShieldNo = 3;
            Debug.Log("Max Amount Exceeded");
        }

        UIManager.instance.tShieldText.text = "x " + iShieldNo;
    }
}