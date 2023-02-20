using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public BuffSystem buffSystem; //needed to transfer speed value to BuffSystem Script

    public int maxHealth = 100;
    public float currentHealth = 100;
    public float regenHealth = 1;
    float time;
    float timeDelay;

    public int maxSpeed = 100;
    public float speed;
    public int attack = 10;
    public int atkSpeed = 10;
    public int size = 10;

    bool tookDamage = false;

    void Start()
    {
        buffSystem.GetStats(maxHealth, attack, speed, atkSpeed, regenHealth); //fuction to transfer

        Debug.Log("Health" + currentHealth);
        time = 0f;
        timeDelay = 2f;
    }

    void Update()
    {
        time = time+ 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            time= 0f;
            Regeneration();
        }  
        healthAdjustment();
    }

    public void GetSpeed( float s) //fuction to refer in PlayerMovement
    {
        s = speed;
    }

    private void Regeneration()
    {
       if (currentHealth <= maxHealth)
        {
            currentHealth += regenHealth;
        }
    }

    private void healthAdjustment()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void Damage()
    {
        tookDamage = true;
        currentHealth--;

        if (tookDamage == true)
        {
            tookDamage = !tookDamage;
        }
    }

    public void SlimeSize()
    {
        if (currentHealth != 0 && currentHealth < maxHealth)
        {
            if (tookDamage)
            {
                size -= size;
                speed += speed;
            }
        }
    }
 
}
