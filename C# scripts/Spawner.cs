using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnCooldown;
    public float spawnCooldownCountdown;
    public float spawnRadius;

    void Start()
    {
        spawnCooldownCountdown = spawnCooldown;
    }

    void Update()
    {
        if(spawnCooldownCountdown >= 0f) 
        {
            spawnCooldownCountdown-=Time.deltaTime;
        }
        else
        {
            spawnCooldownCountdown = spawnCooldown;
            SpawnObject();
        }
    }


    public void SpawnObject()
    {
        Vector2 randomOffset = Random.onUnitSphere * spawnRadius;
        Vector2 spawnPosition = (Vector2)transform.position + randomOffset;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnerLevelUp()
    {
        spawnCooldown*=0.9f;
    }
}
