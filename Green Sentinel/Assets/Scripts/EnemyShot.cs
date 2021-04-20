using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float fShotSpeed = 7f;

    // Update is called once per frame
    void Update()
    {
        //makes the shot move across the screen in a negative direction and how fast the shot travels across the screen
        transform.position -= new Vector3(fShotSpeed * Time.deltaTime, 0f, 0f);
    }

    //function that runs when the gameobject this script is attached to collides with another object
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Instantiate(gImpactEffect, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            HealthManager.instance.HurtPlayer();
        }

        //destroys the shot
        Destroy(this.gameObject);
    }

    //function that destroys objects once they disappear off the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
