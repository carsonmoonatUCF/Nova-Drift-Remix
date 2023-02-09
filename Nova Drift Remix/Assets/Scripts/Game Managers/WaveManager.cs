using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles spawning in set waves with delays.

public class WaveManager : MonoBehaviour
{
    // Wave Spawn Delay
    [Header("Spawn Delay")]
    public float spawnDelay = 0.0f;
    private float spawnCooldown = 0.0f;
    private bool moreWaves = true;

    // Waves
    [Header("Waves")]
    public GameObject[] waves;
    private int numberOfWaves = 0;
    private int currentWave = 0;


    private void Awake() {
        spawnCooldown = spawnDelay / 4;
        numberOfWaves = waves.Length;


    }

    private void Update() {
        if(spawnCooldown <= 0 && moreWaves){
            waves[currentWave].SetActive(true);

            currentWave++;

            if(currentWave == numberOfWaves){
                moreWaves = false;
            }

            spawnCooldown = spawnDelay;
        }

        if(moreWaves)
            spawnCooldown -= Time.deltaTime;
    }
}
