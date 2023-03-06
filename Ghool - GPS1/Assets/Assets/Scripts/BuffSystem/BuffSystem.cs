using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

//done by: Alisa
public class BuffSystem : MonoBehaviour
{
    public static EnemySpawner enemySpawner;
    public static Player player; //reference to player script
    public static Bullet bullet; //reference to bullet script

    //public GameObject playerObject;
    public GameObject BuffSceen;

    private int levelCounter = 0;
    private bool levelOver;

    public List<GameObject> mbuffList = new List <GameObject>(); //need have duplicate of list for true reset (Master List)
    public List<GameObject> buffList = new List <GameObject>(); //buff list
    public List<GameObject> posList = new List <GameObject>(); //pos list

    private float maxHPStat;
    private float regenStat;
    private float speedStat;
    private float attackStat;
    private float attackSpeed;


    private void Start()
    {
        spawnBuff();
    }


    public void GetStats(float mxHp, float spd, float atkSpd, float regen) //getting stats from PlayerStats
    {
        maxHPStat = mxHp;
        attackSpeed = atkSpd;
        speedStat = spd;
        regenStat = regen;

    }

    public void GetAtk(float atk)
    {
        attackStat = atk;

    }

    //buffs
    public void Vitality()
    {
        maxHPStat += 30;
        sendStats();
        //buffClick();

    }

    public void Strike()
    {
        attackStat += 10;
        sendStats();
        //buffClick();

    }

    public void Boost()
    {
        speedStat += 10;
        sendStats();
        //buffClick();

    }

    public void Pulse()
    {
        attackSpeed -= 1;
        sendStats();
        //buffClick();

    }

    public void LifeSource()
    {
        regenStat += 2;
        sendStats();
        //buffClick();

    }

    public void Carnage()
    {
        attackStat += 15;
        sendStats();
        //buffClick();

    }

    public void spawnBuff()
    {
        List<GameObject> buffHolder = new List<GameObject>(buffList); //makes a new list to hold non-instantiated cards

        for (int i = 0; i < 3; i++) //loop 3 times cuz 3 cards
        {
            //first getting random buff
            GameObject randomBuff = buffHolder[Random.Range(0, buffHolder.Count - 1)]; //randomBuff = random card that has been picked
            buffHolder.Remove(randomBuff); //removes randomBuff from buff holder list

            //then spawn at pos
            GameObject posIndex = posList[i]; //i = index value;
            GameObject spawnBuff = Instantiate(randomBuff, posIndex.transform.position, posIndex.transform.rotation, BuffSceen.transform); //spawns the random buff at the location of the position of the posList
        }
    }

    public void buffTrigger()
    {
        Debug.Log("BuffTrigger");
        //levelOver = l; //getting bool from EnemySpawner

        //if (levelOver == true)
        //{
            if (levelCounter != 2)
            {
                levelCounter++;
                Debug.Log("LEVEL INCREASE BY 1");
            }
            else if (levelCounter == 2)
            {
                //instantiate the buff screen
                Debug.Log("Call BuffScene");
                SceneManager.LoadScene("BuffScene");
                Debug.Log("BuffScene Successful");

                //play transition (Close)
                spawnBuff();//then spawnBuff();
                levelCounter = 0;
             }

            //levelOver = false;
        //}
    }

    /*public void buffClick()
    {
        GameObject buffGained = ; //holds the object in which was gained by player selection

        //apply selected buff effect to player main stats (non default stats)
        player.setStats(maxHPStat, attackSpeed, speedStat, regenStat);
        bullet.setAtk(attackStat);

        //need which index was selected
        int buffIndex = buffList.IndexOf(buffGained);

        //need remove buff (index) from normal list
        buffList.Remove(buffGained);

        //delete instantiated objects

        //play transition
        //new level load (not sure if to be placed here)

    }*/

    public void sendStats()
    {

        //apply selected buff effect to player main stats (non default stats)
        player.setStats(maxHPStat, attackSpeed, speedStat, regenStat);
        bullet.setAtk(attackStat);

        //delete instantiated cards

        //play transition (Open)

        //delete buffscreen
        Destroy(BuffSceen);

        //new level load (not sure if to be placed here)
    }

    public void listRestore() //restore list from Master list (Only happens if player dies)
    {
        mbuffList = buffList;
    }

}
