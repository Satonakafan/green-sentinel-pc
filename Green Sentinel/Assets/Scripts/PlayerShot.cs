using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float fShotSpeed = 7f;

    public GameObject gOObjectExplosion;

    // Update is called once per frame
    void Update()
    {
        //how fast the shot travels across the screen
        transform.position += new Vector3(fShotSpeed * Time.deltaTime, 0f, 0f);
    }

    //function that runs when the gameobject this script is attached to collides with another object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Space Object")
        {
            //tells unity to place the particle effects at the position of the destroyed object
            Instantiate(gOObjectExplosion, other.transform.position, other.transform.rotation);

            //tells unity to destroy the gameObject that the shot hits
            Destroy(other.gameObject);
        }

        //if the shot hits an object with the Enemy tag it will call the Hurt Enemy function that will damage that object
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().HurtEnemy();
        }

        
        //if the shot hits the boss then it will call the HurtBoss function from the BossManager script and the boss will take damage
        if (other.tag == "Boss")
        {
            BossController.instance.HurtBoss();
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
