using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Anwar/Alisa
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

    public int maxEnemies;
    public int numEnemies = 0;
    public int EnemiesOnScreen;

    public float spawnRate = 2f;
    private float nextSpawnTime = 0f;

    // Buffs 
    public static BuffSystem BuffSystem;
    //public bool levelDone = false;

    public int enemiesKilled;
    public int totalenemiesset;

    private void Start()
    {
        //levelDone = false;
    }

    private void Update()
    {
        if (EnemiesOnScreen < maxEnemies && Time.time >= nextSpawnTime)
        {
            // Choose a random position on the screen to spawn the enemies
            float xPosition = Random.Range(-5f, 9f);
            float yPosition = Random.Range(-0.01f, 0f);
            Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0f);

            // Choose a random enemy prefab to spawn
            GameObject enemyPrefab = Random.value < 0.5f ? enemyPrefab1 : enemyPrefab2;

            // Spawn the enemy prefab at the chosen position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            EnemiesOnScreen++;
            numEnemies++;
            nextSpawnTime = Time.time + spawnRate;
           
        }

        /* Check if all enemies are dead
        if (EnemiesOnScreen == 0 && !levelDone)
        {
            AllEnemiesDead();
        }*/

    }

    public void DecreaseEn()
    {
        numEnemies -= 1;
        enemiesKilled += 1;
        Debug.Log("Enemy Number - 1");
        if (numEnemies <= 0)
        {
            Debug.Log("Calling AllEnemiesDead");
            SceneEnd();
        }
    }

    public void SceneEnd()
    {
        if (enemiesKilled == totalenemiesset)
        {
            //BuffSystem buffSystem = GameObject.FindObjectOfType<BuffSystem>();
            //buffSystem.buffTrigger();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
