using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public int maxHealth = 100;
    public float currentHealth=100;
    public float regenHealth= 1;
    float time;
    float timeDelay;
    void Start()
    {
        Debug.Log("Health" + currentHealth);
        time = 0f;
        timeDelay = 2f;
    }

    void Update()
    {
        time=time+1f*Time.deltaTime;
        if (time >= timeDelay)
        {
            time= 0f;
            Regeneration();
        }  
        healthAdjustment();
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
        currentHealth--;
    }
 
}
