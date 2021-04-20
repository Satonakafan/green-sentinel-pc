using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItems : MonoBehaviour
{
    public bool bIsShield, bisBomb;

    public AudioSource audioSource;
    public AudioClip aCItemPickUp;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(aCItemPickUp, transform.position);

                if (bIsShield)
                {
                    HealthManager.instance.IncreaseShieldNo();
                    Debug.Log("Shield Picked Up");
                }

                if (bisBomb)
                {
                    PlayerBomb.instance.IncreaseBombs();
                    Debug.Log("Bomb Picked Up");
                }

            Destroy(gameObject);
        }
    }
}
