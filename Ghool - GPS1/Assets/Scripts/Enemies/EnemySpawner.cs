using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Anwar/Alisa
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

    public int maxEnemies;
    public float spawnRate = 2f;

    private int numEnemies = 0;
    private float nextSpawnTime = 0f;

    // Buffs 
    public BuffSystem BuffSystem;
    //public int EnemiesOnScreen;
    public bool levelDone = false;

    private void Update()
    {
        if (numEnemies < maxEnemies && Time.time >= nextSpawnTime)
        {
            // Choose a random position on the screen to spawn the enemies
            float xPosition = Random.Range(-5f, 9f);
            float yPosition = Random.Range (-0.01f, 0f);
            Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0f);

            // Choose a random enemy prefab to spawn
            GameObject enemyPrefab = Random.value < 0.5f ? enemyPrefab1 : enemyPrefab2;

            // Spawn the enemy prefab at the chosen position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            numEnemies++;
            nextSpawnTime = Time.time + spawnRate;
        }

    }

    public void AllEnemiesDead()
    {
       if (numEnemies == 0)
       {
           levelDone = true;
           BuffSystem.buffTrigger(levelDone);
       }

       levelDone = false;
    }

}
