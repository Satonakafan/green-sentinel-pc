using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //detaches the enemies from the wave spawn object
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
