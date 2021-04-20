using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float fMoveSpeed;

    public Rigidbody2D rigidBody;

    public Transform tBottomLeftScreen, tTopRightScreen;

    public Transform tShotPoint;
    public GameObject gOShot;

    public float fTimeBetweenShots;
    public float fShotCounter;

    public GameObject gOBomb;
    public Transform tBombPoint;

    public bool bStopMovement;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //if true then the player will not be able to shoot or move
        if (bStopMovement == false)
        {
            rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * fMoveSpeed;

            //this code tells unity that the transform mentioned belongs to the object this script is attacted to
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, tBottomLeftScreen.position.x, tTopRightScreen.position.x), Mathf.Clamp(transform.position.y, tBottomLeftScreen.position.y, tTopRightScreen.position.y), transform.position.z);

            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(gOShot, tShotPoint.position, tShotPoint.rotation);
                fShotCounter = fTimeBetweenShots;
            }


            if (Input.GetButton("Fire1"))
            {
                //makes shotCounter count down
                fShotCounter -= Time.deltaTime;

                if (fShotCounter <= 0)
                {
                    Instantiate(gOShot, tShotPoint.position, tShotPoint.rotation);
                    fShotCounter = fTimeBetweenShots;
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                GameObject.Find("Bomb").SetActive(true);
                GameObject.Find("Bomb").GetComponent<PlayerBomb>().BombActivate();
            }

            if(Input.GetButtonDown("Fire3"))
            {
                HealthManager.instance.ShieldActivate();
            }
        }
        else
        {
            //stops the player ship from flying off the screen whilst the level complete screen is displayed
            rigidBody.velocity = Vector2.zero;
        }
    }
}
