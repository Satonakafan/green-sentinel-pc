using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public WaveController[] waves;
    
    public int iCurrentWave;

    public float fTimeTillNextWave;

    public bool bCanWavesSpawn;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fTimeTillNextWave = waves[0].fSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanWavesSpawn)
        {
            //starts a counts down
            fTimeTillNextWave -= Time.deltaTime;

            if (fTimeTillNextWave <= 0)
            {
                //instantiates the enemywave that is stored in that position of the array
                Instantiate(waves[iCurrentWave].enemyWave, transform.position, transform.rotation);

                if (iCurrentWave < waves.Length - 1)
                {
                    iCurrentWave++;

                    //sets the timeTillNextWave to the timer of the next wave in the array that was specified in the inspector
                    fTimeTillNextWave = waves[iCurrentWave].fSpawnTimer;
                }
                else
                {
                    bCanWavesSpawn = false;
                }
            }
        }
    }

    public void ContinueSpawning()
    {
        //if the current wave is less than the wave array length - 1 and the time to the nect wave is greater than 0
        if(iCurrentWave <= waves.Length -1 && fTimeTillNextWave > 0)
        {
            bCanWavesSpawn = true;
        }
    }
}

//creates a Serializable class that is viewable within Unity without having any code that runs
[System.Serializable]
public class WaveController
{
    public float fSpawnTimer;
    public EnemyWave enemyWave;
}
