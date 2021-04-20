using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fMoveSpeed;

    public int iCurrentHealth;

    public Vector2 vStartingDirection;

    public float fChangeXDirection;
    public bool bShouldChangeDirection;
    public Vector2 vChangedDirection;
    public bool bIsAllowedToChangeDirection = false;

    public GameObject gOShotToFire;
    public Transform tFirePoint;
    public float fTimeBetweenShots;
    public float fShotCounter;

    public GameObject gODeathEffect;

    public bool bCanShoot;
    private bool bIsAllowedToShoot;

    // Start is called before the first frame update
    void Start()
    {
        fShotCounter = fTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
            if (!bShouldChangeDirection)
            {

                //controls the direction the enemy is moving
                transform.position += new Vector3(vStartingDirection.x * fMoveSpeed * Time.deltaTime, vStartingDirection.y * fMoveSpeed * Time.deltaTime);
            }
            else
            {
                if (transform.position.x > fChangeXDirection)
                {
                    transform.position += new Vector3(vStartingDirection.x * fMoveSpeed * Time.deltaTime, vStartingDirection.y * fMoveSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position += new Vector3(vChangedDirection.x * fMoveSpeed * Time.deltaTime, vChangedDirection.y * fMoveSpeed * Time.deltaTime);
                }
            }

        if (bIsAllowedToShoot)
        {
            fShotCounter -= Time.deltaTime;
            if (fShotCounter <= 0)
            {
                fShotCounter = fTimeBetweenShots;
                Instantiate(gOShotToFire, tFirePoint.position, tFirePoint.rotation);
            }
        }
    }

    public void HurtEnemy()
    {
        iCurrentHealth--;

        if (iCurrentHealth <= 0)
        {
            GetComponent<ItemDrop>().SpawnPowerUp();
            Instantiate(gODeathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
 
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
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