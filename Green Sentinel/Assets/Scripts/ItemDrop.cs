using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public static ItemDrop instance;

    public GameObject[] gOAPowerUps;
    public int iDropRate = 25;
    private int iItemSpawn;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SpawnPowerUp()
    {
        int iChanceOfDrop = Random.Range(0, 75);

        if (iChanceOfDrop < iDropRate)
        {
            //chooses a number randomly between 0 and the amount of positions in the Power Ups Array
            iItemSpawn = Random.Range(0, gOAPowerUps.Length);
            //spawns the item that was found using the code above in the position of the destroyed enemy
            Instantiate(gOAPowerUps[iItemSpawn], transform.position, transform.rotation);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Space Object" && other.tag == "Player Shot")
        {
            int iChanceOfDrop = Random.Range(0, 24);

            if (iChanceOfDrop < iDropRate)
            {
                //chooses a number randomly between 0 and the amount of positions in the Power Ups Array
                iItemSpawn = Random.Range(0, gOAPowerUps.Length);
                //spawns the item that was found using the code above in the position of the destroyed enemy
                Instantiate(gOAPowerUps[iItemSpawn], transform.position, transform.rotation);
            }
        }
    }
}
