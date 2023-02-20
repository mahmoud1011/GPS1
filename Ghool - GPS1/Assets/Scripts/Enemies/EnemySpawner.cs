using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public BuffSystem BuffSystem;
    public int EnemiesOnScreen;
    public bool levelDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void allEnemiesDead()
    {
        if (EnemiesOnScreen == 0)
        {
            levelDone = true;
            BuffSystem.buffTrigger(levelDone);
        }

        levelDone = false;
    }
   
}
