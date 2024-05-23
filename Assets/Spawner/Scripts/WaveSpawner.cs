using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Waves[] waves;
    private Waves currentWave;

    //[SerializeField]
   // private Transform[] spawnPoints;

    private float timebtwnSpawns;
    private int i = 0;
    private bool stopSpawning = false;

    private void Awake()
    {
        currentWave = waves[i];
        timebtwnSpawns = currentWave.TimeBeforeWave;
    }

    void Update()
    {
        if (stopSpawning)
        {
            return;
        }


        if (Time.time >= timebtwnSpawns)
        {
            SpawnWave();
            IncWave();

            timebtwnSpawns = Time.time + currentWave.TimeBeforeWave;
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
/*            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, spawnPoints.Length);*/

            Instantiate(currentWave.EnemiesInWave[i]);
        }
    }

    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }
}
