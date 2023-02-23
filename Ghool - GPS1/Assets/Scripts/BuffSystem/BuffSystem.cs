using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    public GameObject Player;
    public int levelCounter = 0;
    public bool levelOver;


    public int maxHPStat;
    public float regenStat;
    public int speedStat;
    public int attackStat;
    public int attackSpeed;

    public void GetStats(int mxHp, int atk, float spd, int atkSpd, float regen) //getting stats from PlayerStats
    {
        mxHp = maxHPStat;
        atk = attackStat;
        atkSpd = attackSpeed;
        spd = speedStat;
        regen = regenStat;

    }

    public void buffTrigger ( bool l )
    {
        l = levelOver;

        if (levelOver == true)
        {
            if (levelCounter != 2)
            {
                levelCounter++;
            }
            else if (levelCounter == 2)
            {
                levelCounter = 0;
                //play transition
                // have rng 
            }

            levelOver = false;
        }
    }


    //buffs
    public void Vitality()
    {
        maxHPStat += 30;
    }

    public void Strike()
    {
        attackStat += 10;
    }

    public void Boost()
    {
        speedStat += 10;
    }

    public void Pulse()
    {
        attackSpeed -= 1;
    }

    public void LifeSource()
    {
        regenStat += 2;
    }

    public void Carnage()
    {
        attackStat += 15;
    }
}
